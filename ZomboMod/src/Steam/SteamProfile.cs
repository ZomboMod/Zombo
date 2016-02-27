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


using Steamworks;

namespace ZomboMod.Steam
{
    public class SteamProfile
    {
        public CSteamID SteamID { get; set; }

        public CSteamID GroupID { get; set; }
    }
}