using System.Collections.Generic;

namespace ZomboMod.Permission
{
    public class PermissionPlayer : IPermissible
    {
        public ulong Id { get; set; }

        public HashSet<string> Permissions { get; }

        public HashSet<PermissionGroup> Groups { get; set; }

        public bool HasPermission( string permission )
        {
            throw new System.NotImplementedException();
        }

        public PermissionPlayer( ulong id, HashSet<string> permissions, HashSet<PermissionGroup> groups )
        {
            Id = id;
            Permissions = permissions;
            Groups = groups;
        }
    }
}