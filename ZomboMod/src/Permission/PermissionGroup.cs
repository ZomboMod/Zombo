using System.Collections.Generic;
using System.Linq;
using ZomboMod.Common;

namespace ZomboMod.Permission
{
    public class PermissionGroup
    {
        public string Name { get; }

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

        public bool IsParentOf( PermissionGroup other )
        {
            return Parents.Any( g => g.Name.EqualsIgnoreCase( other.Name ) );
        }
    }
}