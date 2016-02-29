using System.Collections.Generic;

namespace ZomboMod.Permission
{
    public interface IPermissible
    {
        IEnumerable<string> Permissions { get; }

        bool HasPermission( string permission );
    }
}