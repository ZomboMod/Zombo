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

namespace ZomboMod.Configuration
{
    public interface IConfig
    {
        string FileName { get; }

        void LoadDefaults();

        void Load( string filePath );

        void Save( string filePath );
    }
}