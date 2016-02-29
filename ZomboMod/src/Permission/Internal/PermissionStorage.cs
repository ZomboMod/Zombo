using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZomboMod.Common;

namespace ZomboMod.Permission.Internal
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
        internal Dictionary<ulong, PermissionPlayer> Players;
        internal Dictionary<string, PermissionGroup> Groups;

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
                    Groups = new List<string> { "vip" }  
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

            Players = new Dictionary<ulong, PermissionPlayer>();
            Groups = new Dictionary<string, PermissionGroup>();
        }

        internal void Save()
        {
            var all = new {
                Groups = Groups.ToDictionary( g => g.Key, g => new {
                    Permissions = g.Value.Permissions.Where( p => {
                        return !g.Value.Parents.SelectMany( par => par.Permissions ).Contains( p );
                    } ),
                    g.Value.Players,
                    Parents = g.Value.Parents.Select( gp => gp.Name )
                } ),
                Players = Players.ToDictionary( g => g.Key, p => new {
                    p.Value.Permissions,
                    Groups = p.Value.Groups.Select( g => g.Name )
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

                    var permissions         = new HashSet<string>();
                    var players             = new HashSet<ulong>();

                    if ( groupPermissions != null )
                    {
                        permissions = groupPermissions.ToObject<HashSet<string>>();
                    }

                    if ( groupPlayers != null )
                    {
                        players = groupPlayers.ToObject<HashSet<ulong>>();
                    }

                    if ( groupParents != null )
                    {
                        parentsToResolve.Add( groupName, groupParents.ToObject<List<string>>() );
                    }

                    Groups.Add( groupName, new PermissionGroup( groupName, permissions, players, null ) );
                }

                /*
                    Resolve parent groups... what?

                    After all groups was loaded, he will resolve the parents of each group,
                    that is stored in parentsToResolve that consists in { groupName, [ list, of, parents ] }
                */

                foreach ( var pair in parentsToResolve )
                {
                    var group = Groups[pair.Key];
                    var parents = new HashSet<PermissionGroup>();
                    
                    foreach ( var parentName in pair.Value )
                    {
                        if ( !Groups.ContainsKey( parentName ) )
                        {
                            //TODO Logger
                            Console.WriteLine( $"Invalid parent '{parentName}'(Not exist) in group '{group.Name}'." );
                            return;
                        }

                        parents.Add( Groups[parentName] );
                    }

                    group.Parents = parents;
                    parents.SelectMany( p => p.Permissions ).ForEach( p => group.Permissions.Add(p) );
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

                    var permissions         = new HashSet<string>();
                    var groups              = new HashSet<PermissionGroup>();
                    
                    if ( playerPermissions != null )
                    {
                        permissions = playerPermissions.ToObject<HashSet<string>>();
                    }

                    playerGroups?.ToObject<HashSet<string>>().ForEach( gName => 
                    {
                        if ( !Groups.ContainsKey( gName ) )
                        {
                            //TODO Logger
                            Console.WriteLine( $"Invalid player group '{gName}'(Not exist) in player '{playerId}'." );
                            return;
                        }
                        groups.Add( Groups[gName.ToLowerInvariant()] );
                    } );

                    Players.Add( playerId, new PermissionPlayer( playerId, permissions, groups ) );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex );
            }
        }
    }
}