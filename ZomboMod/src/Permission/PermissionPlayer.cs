using System.Collections.Generic;

namespace ZomboMod.Permission
{
    public class PermissionPlayer : IPermissible
    {
        public ulong Id { get; set; }

        public List<string> Permissions { get; }

        public List<PermissionGroup> Groups { get; set; }

        public bool HasPermission( string permission )
        {
            throw new System.NotImplementedException();
        }

        public PermissionPlayer( ulong id, List<string> permissions, List<PermissionGroup> groups )
        {
            Id = id;
            Permissions = permissions;
            Groups = groups;
        }
    }
}