using System.Collections.Generic;
using ZomboMod.Entity;

namespace ZomboMod.Permission
{
    /// <summary>
    /// TODO: Explain how implement it.
    /// </summary>
    public interface IPermissionProvider
    {
        IEnumerable<PermissionGroup> Groups { get; }

        /// <see cref="HasPermission(ulong, string)"/>
        bool HasPermission( UPlayer player, string permission );

        /// <summary>
        /// Check if player has the given permission.
        /// </summary>
        /// <param name="playerId">Id of player.</param>
        /// <param name="permission">Permission to check.</param>
        /// <returns>If player has the given permission.</returns>
        bool HasPermission( ulong playerId, string permission );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        PermissionGroup GetGroup( string name );

        IEnumerable<string> GetPermssions( UPlayer player ); 

        IEnumerable<string> GetPermssions( ulong playerId ); 

        /// <summary>
        /// Load permissions
        /// </summary>
        void Load();

        /// <summary>
        /// Save permissions
        /// </summary>
        void Save();
    }
}