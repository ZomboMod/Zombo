using System.Collections.Generic;
using JetBrains.Annotations;

namespace ZomboMod.Permission
{
    public interface IPermissible
    {
        HashSet<string> Permissions { get; }

        HashSet<PermissionGroup> Groups { get; }

        bool HasPermission( string permission );
    }
}