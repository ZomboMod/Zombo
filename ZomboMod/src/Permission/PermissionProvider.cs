using System.Collections.Generic;
using ZomboMod.Entity;

namespace ZomboMod.Permission
{
    internal class PermissionProvider : IPermissionProvider
    {
        internal PermissionStorage Storage;

        public PermissionProvider()
        {
            Storage = new PermissionStorage();
        }

        public List<string> GetPermissions( UPlayer player )
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetPermissions( ulong playerId )
        {
            throw new System.NotImplementedException();
        }

        public bool HasPermission( UPlayer player )
        {
            throw new System.NotImplementedException();
        }

        public bool HasPermission( ulong playerId )
        {
            throw new System.NotImplementedException();
        }

        public PermissionGroup GetGroup( string name )
        {
            throw new System.NotImplementedException();
        }

        public PermissionPlayer GetPlayer( ulong playerId )
        {
            throw new System.NotImplementedException();
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
