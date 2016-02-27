using System;

namespace ZomboMod.Plugin
{
    [AttributeUsage( AttributeTargets.Class, Inherited = false )]
    public sealed class PluginInfo : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; } = "0.0.0.0";

        /// <summary>
        /// 
        /// </summary>
        public string Author { get; set; } = "Undefined";

        /// <summary>
        /// 
        /// </summary>
        public PluginLoadFlags LoadFlags { get; set; } = PluginLoadFlags.AUTO_REGISTER_COMMANDS | PluginLoadFlags.AUTO_REGISTER_EVENTS;
    }
}