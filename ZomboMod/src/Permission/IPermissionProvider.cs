using ZomboMod.Entity;

namespace ZomboMod.Permission
{
    public interface IPermissionProvider
    {
        bool HasPermission( UPlayer player, string permission );

        bool HasPermission( ulong playerId, string permission );

        PermissionGroup GetGroup( string name );

        PermissionPlayer GetPlayer( UPlayer player );

        PermissionPlayer GetPlayer( ulong playerId );

        void Load();

        void Save();
    }
}