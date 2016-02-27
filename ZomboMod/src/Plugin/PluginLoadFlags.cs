
using System;

namespace ZomboMod.Plugin
{
    [Flags]
    public enum PluginLoadFlags
    {
        /// <summary>
        /// Nothing
        /// </summary>
        NONE                   = 0,

        /// <summary>
        /// Dynamically register all commands in Module.
        /// </summary>
        AUTO_REGISTER_COMMANDS = 1 << 0,

        /// <summary>
        /// Dynamically register all events (handlers) in Module.
        /// </summary>
        AUTO_REGISTER_EVENTS   = 1 << 1
    }
}
