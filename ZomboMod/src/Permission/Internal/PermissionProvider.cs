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

        public bool HasPermission( UPlayer player, string permission )
        {
            return HasPermission( player.SteamProfile.SteamID.m_SteamID, permission );
        }

        public bool HasPermission( ulong playerId, string permission )
        {
            return GetPlayer( playerId ).Permissions.Any( p => p.EqualsIgnoreCase( permission ) );
        }

        public PermissionGroup GetGroup( string name )
        {
            return Storage.Groups.GetOrDefault( name, null );
        }

        public PermissionPlayer GetPlayer( UPlayer player )
        {
            return GetPlayer( player.SteamProfile.SteamID.m_SteamID );
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
