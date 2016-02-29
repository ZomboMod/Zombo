using System.Collections.Generic;
using ZomboMod.Entity;

namespace ZomboMod.Permission
{
    public interface IPermissionProvider
    {
        List<string> GetPermissions( UPlayer player );

        List<string> GetPermissions( ulong playerId );

        bool HasPermission( UPlayer player, string permission );

        bool HasPermission( ulong playerId, string permission );

        PermissionGroup GetGroup( string name );

        PermissionPlayer GetPlayer( ulong playerId );

        void Load();

        void Save();
    }
}