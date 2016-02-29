using System.Collections.Generic;
using JetBrains.Annotations;

namespace ZomboMod.Permission
{
    public interface IPermissible
    {
        List<string> Permissions { get; }

        List<PermissionGroup> Groups { get; set; }

        bool HasPermission( string permission );
    }
}