using System.Collections.Generic;

namespace ZomboMod.Permission
{
    public class PermissionGroup
    {
        public string Name { get; internal set; }

        public HashSet<string> Permissions { get; internal set; }

        public HashSet<ulong> Players { get; internal set; }

        public HashSet<PermissionGroup> Parents { get; internal set; }

        public PermissionGroup( string name, HashSet<string> permissions, HashSet<ulong> players, HashSet<PermissionGroup> parents )
        {
            Name = name;
            Permissions = permissions;
            Players = players;
            Parents = parents;
        }
    }
}