using System.Collections.Generic;
using System.Linq;
using ZomboMod.Common;
using ZomboMod.Entity;

namespace ZomboMod.Permission.Internal
{
    internal class PermissionProvider : IPermissionProvider
    {
        internal PermissionStorage Storage;

        internal PermissionProvider()
        {
            Storage = new PermissionStorage();
        }

        public List<string> GetPermissions( UPlayer player )
        {
            return GetPermissions( player.SteamProfile.SteamID.m_SteamID );
        }

        public List<string> GetPermissions( ulong playerId )
        {
            var ret = new List<string>();
            PermissionPlayer permPlayer;
            var groupFound = false;

            if ( Storage.Players.TryGetValue( playerId, out permPlayer ) )
            {
                ret.AddRange( permPlayer.Permissions );

                permPlayer.Groups.ForEach( g => {
                    ret.AddRange( g.Permissions );
                    groupFound = true;
                } );
            }

            if ( !groupFound )
            {
                Storage.Groups.Values
                        .Where( g => g.Players.Contains( playerId ) )
                        .ForEach( g => ret.AddRange( g.Permissions ));
            }
            
            return ret;
        }

        public bool HasPermission( UPlayer player, string permission )
        {
            throw new System.NotImplementedException();
        }

        public bool HasPermission( ulong playerId, string permission )
        {
            throw new System.NotImplementedException();
        }

        public PermissionGroup GetGroup( string name )
        {
            return Storage.Groups.GetOrDefault( name, null );
        }

        public PermissionPlayer GetPlayer( ulong playerId )
        {
            return Storage.Players.GetOrDefault( playerId, null );
        }

        public void Load()
        {
            Storage.Load();
        }

        public void Save()
        {
            Storage.Save();
        }
    }
}
