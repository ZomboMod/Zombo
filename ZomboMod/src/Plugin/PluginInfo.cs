/*
 *
 *   This file is part of ZomboMod Project.
 *     https://www.github.com/ZomboMod
 *   
 *   Copyright (C) 2016 Leonardosnt
 *   
 *   ZomboMod is licensed under CC BY-NC-SA.
 *   
 */

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