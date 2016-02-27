using System;

namespace ZomboMod.Plugin
{
    [AttributeUsage( AttributeTargets.Class, Inherited = false )]
    public sealed class PluginInfo : Attribute
    {
        /// <summary>
        /// Name of module
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Version of module
        /// </summary>
        public string Version { get; set; } = "0.0.0.0";

        /// <summary>
        /// Author of module
        /// </summary>
        public string Author { get; set; } = "Undefined";

        /// <summary>
        /// Flags of module
        /// </summary>
        public PluginLoadFlags LoadFlags { get; set; } = PluginLoadFlags.AUTO_REGISTER_COMMANDS | PluginLoadFlags.AUTO_REGISTER_EVENTS;
    }
}