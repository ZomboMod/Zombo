using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZomboMod.Permission
{
    /*
        TODO: abstraction

        PermissionStorage
            -> JsonPermissionStorage
            -> XmlPermssionStorage !?!?
            -> ?
    */
    internal class PermissionStorage
    {
        internal List<PermissionPlayer> Players;
        internal List<PermissionGroup> Groups;

        private readonly string _permissionsFilePath;

        public PermissionStorage()
        {
            _permissionsFilePath = Zombo.Folder + "Permissions.json";

            // Load defaults
            if ( !File.Exists( _permissionsFilePath ) )
            {
                var defaultGroup = new  {
                    Permissions = new List<string> { "defaultcommands.zombo" },
                    Players = new List<ulong>(),
                    Parents = new List<string>()
                };

                var vipGroup = new  {
                    Permissions = new List<string> { "an.command"},
                    Players = new List<ulong>(),
                    Parents = new List<string> { "default" }
                };

                var me = new {
                    Permissions = new List<string>(),
                    Groups = new List<string>() { "vip" }  
                };

                var all = new {
                    Groups = new Dictionary<string, object> {
                        { "default", defaultGroup },
                        { "vip", vipGroup}
                    },
                    Players = new Dictionary<string, object> {
                        { "76561198144490276", me }
                    }
                };

                File.WriteAllText( _permissionsFilePath,
                                   JsonConvert.SerializeObject( all, Formatting.Indented ) );
            }

            Players = new List<PermissionPlayer>();
            Groups = new List<PermissionGroup>();
        }

        internal void Save()
        {
            var all = new {
                Groups = Groups.ToDictionary( g => g.Name, g => new {
                    g.Permissions,
                    g.Players,
                    Parents = g.Parents.Select( gp => gp.Name )
                } ),
                Players = Players.ToDictionary( p => p.Id, p => new {
                    p.Permissions,
                    Groups = p.Groups.Select( g => g.Name )
                } )
            };

            File.WriteAllText( _permissionsFilePath,
                               JsonConvert.SerializeObject( all, Formatting.Indented ) );
        }

        internal void Load()
        {
            try
            {
                const StringComparison igcase = StringComparison.InvariantCultureIgnoreCase;

                var json = JObject.Parse( File.ReadAllText( _permissionsFilePath ) );
                var groupsArray = json.GetValue( "Groups", igcase );
                var playersArray = json.GetValue( "Players", igcase );
                var parentsToResolve = new Dictionary<string, List<string>>();

                if ( groupsArray == null )
                {
                    throw new JsonReaderException("Invalid permissions: Missing 'Groups'.");
                }

                if ( playersArray == null )
                {
                    throw new JsonReaderException("Invalid permissions: Missing 'Players'.");
                }

                foreach ( var obj in groupsArray )
                {
                    var jObj                = (JObject) obj.First;
                    var groupName           = ((JProperty) obj).Name.ToLowerInvariant();
                    var groupPermissions    = jObj.GetValue( "Permissions", igcase ) as JArray;
                    var groupPlayers        = jObj.GetValue( "Players", igcase ) as JArray;
                    var groupParents        = jObj.GetValue( "Parents", igcase ) as JArray;

                    var permissions         = new List<string>();
                    var players             = new List<ulong>();

                    if ( groupPermissions != null )
                    {
                        permissions = groupPermissions.ToObject<List<string>>();
                    }

                    if ( groupPlayers != null )
                    {
                        players = groupPlayers.ToObject<List<ulong>>();
                    }

                    if ( groupParents != null )
                    {
                        parentsToResolve.Add( groupName, groupParents.ToObject<List<string>>() );
                    }

                    Groups.Add( new PermissionGroup( groupName, permissions, players, null ) );
                }

                /*
                    Resolve parent groups... what?

                    After all groups was loaded, he will resolve the parents of each group,
                    that is stored in parentsToResolve that consists in { groupName, [ list, of, parents ] }
                */

                var mapGroup = Groups.ToDictionary( x => x.Name );

                foreach ( var pair in parentsToResolve )
                {
                    var group = mapGroup[pair.Key];
                    var parents = new List<PermissionGroup>();
                    
                    foreach ( var parentName in pair.Value )
                    {
                        if ( !mapGroup.ContainsKey( parentName ) )
                        {
                            //TODO Logger
                            Console.WriteLine( $"Invalid parent '{parentName}'(Not exist) in group '{group.Name}'." );
                            return;
                        }
                        
                        parents.Add( mapGroup[parentName] );
                    }

                    group.Parents = parents;
                }

                foreach ( var obj in playersArray )
                {
                    var jObj                = (JObject) obj.First;
                    var rawPlayerId         = ((JProperty) obj).Name;
                    var playerId            = 0UL;

                    if ( rawPlayerId == null || !ulong.TryParse( rawPlayerId, out playerId ) )
                    {
                        throw new JsonReaderException( $"Invalid playerId {playerId}" );
                    }

                    var playerPermissions   = jObj.GetValue( "Permissions", igcase ) as JArray;
                    var playerGroups        = jObj.GetValue( "Groups", igcase ) as JArray;

                    var permissions         = new List<string>();
                    var groups              = new List<PermissionGroup>();
                    
                    if ( playerPermissions != null )
                    {
                        permissions = playerPermissions.ToObject<List<string>>();
                    }

                    playerGroups?.ToObject<List<string>>().ForEach( gName => 
                    {
                        if ( !mapGroup.ContainsKey( gName ) )
                        {
                            //TODO Logger
                            Console.WriteLine( $"Invalid player group '{gName}'(Not exist) in player '{playerId}'." );
                            return;
                        }

                        groups.Add( mapGroup[gName.ToLowerInvariant()] );
                    } );

                    Players.Add( new PermissionPlayer( playerId, permissions, groups ) );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex );
            }
        }
    }
}