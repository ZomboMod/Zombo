using System.Collections.Generic;

namespace ZomboMod.Permission
{
    public class PermissionGroup
    {
        public string Name { get; internal set; }

        public List<string> Permissions { get; internal set; }

        public List<ulong> Players { get; internal set; }

        public List<PermissionGroup> Parents { get; internal set; }

        public PermissionGroup( string name, List<string> permissions, List<ulong> players, List<PermissionGroup> parents )
        {
            Name = name;
            Permissions = permissions;
            Players = players;
            Parents = parents;
        }
    }
}