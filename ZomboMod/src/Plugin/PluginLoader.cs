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