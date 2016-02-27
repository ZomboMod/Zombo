using System;
using System.Reflection;

namespace ZomboMod.Plugin
{
    public class PluginLoader
    {
        public PluginBase LoadFrom( string path )
        {
            throw new NotImplementedException();
        }

        public PluginBase LoadFrom( Assembly asm )
        {
            throw new NotImplementedException(); 
        }
    }
}