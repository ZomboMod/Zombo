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
using System.Collections.Generic;
using System.Linq;

namespace ZomboMod.Plugin
{
    public class PluginManager
    {
        public PluginLoader             Loader      { get; }
        public IEnumerable<PluginBase>  Plugins     => _plugins.Values;

        public PluginManager( PluginLoader loader )
        {
            _plugins = new Dictionary<string, PluginBase>();
            Loader = loader;
        }

        public PluginBase GetPlugin( string name )
        {
            return _plugins.ContainsKey( name ) ? _plugins[name] : null;
        }

        public PluginBase GetPlugin( Type type )
        {
            return Plugins.FirstOrDefault( p => p.GetType() == type );
        }
        
        public void UnloadPlugin( PluginBase plugin )
        {
            plugin.Unload();
        }
        
        public void LoadPlugin( PluginBase plugin )
        {
            plugin.Load();
        }

        public T GetPlugin<T>() where T : PluginBase
        {
            return (T) GetPlugin( typeof (T) );
        }

        private Dictionary<string, PluginBase> _plugins;
    }
}