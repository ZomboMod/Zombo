using System.Collections.Generic;
using JetBrains.Annotations;

namespace ZomboMod.Permission
{
    public interface IPermissible
    {
        HashSet<string> Permissions { get; }

        HashSet<PermissionGroup> Groups { get; set; }

        bool HasPermission( string permission );
    }
}