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

using SDGPlayer = SDG.Unturned.Player;

namespace ZomboMod.Steam
{
    public class SteamProfile
    {
        public CSteamID SteamID { get; }

        public CSteamID GroupID { get; }

        public string Name { get; }

        public SteamProfile( SDGPlayer player )
        {
            SteamID = player.channel.owner.playerID.steamID;
            GroupID = player.channel.owner.playerID.group;
        }
    }
}