using System.Collections.Generic;

namespace ZomboMod.Permission
{
    public class PermissionPlayer
    {
        public ulong Id { get; set; }

        public HashSet<string> Permissions { get; }

        public HashSet<PermissionGroup> Groups { get; set; }

        public PermissionPlayer( ulong id, HashSet<string> permissions, HashSet<PermissionGroup> groups )
        {
            Id = id;
            Permissions = permissions;
            Groups = groups;
        }
    }
}