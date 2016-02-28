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
using SDG.Unturned;
using Steamworks;

using Player = ZomboMod.Entity.Player;

namespace ZomboMod
{
    public class UServer
    {
        public byte MaxPlayers
        {
            get { return Provider.maxPlayers; }
            set { Provider.maxPlayers = value; }
        }

        public uint Ip
        {
            get { return Provider.ip; }
        }

        public ushort Port
        {
            get { return Provider.port; }
            private set { Provider.port = value; }
        }

        public string Name
        {
            get { return Provider.serverName; }
            set { Provider.serverName = value; }
        }

        public string Password
        {
            get { return Provider.serverPassword; }
            set { Provider.serverPassword = value; }
        }

        public string Map
        {
            get { return Provider.map; }
            private set { Provider.map = value; }
        }

        public bool IsPvp
        {
            get { return Provider.isPvP; }
            set { Provider.isPvP = value; }
        }

        public EGameMode GameMode
        {
            get { return Provider.mode; }
            set { Provider.mode = value; }
        }

        public ECameraMode CameraMode
        {
            get { return Provider.camera; }
            set { Provider.camera = value; }
        }

        public ESteamSecurity SecurityMode
        {
            get { return Dedicator.security; }
            set { Dedicator.security = value; }
        }

        public float Timeout
        {
            get { return Provider.timeout; }
            set { Provider.timeout = value; }
        }

        public IEnumerable<Player> OnlinePlayers
        {
            get { return ConnectedPlayers.AsEnumerable(); } 
        }


        internal UServer( ushort port, string map )
        {
            ConnectedPlayers = new List<Player>();

            Port = port;
            Map = map;

            Provider.onServerConnected += PlayerConnectedCallback;
            Provider.onServerDisconnected += PlayerDisconnectedCallback;
        }

        public void Broadcast( params string[] messages )
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer( CSteamID id )
        {
            throw new NotImplementedException();  
        }

        public Player GetPlayer( string name )
        {
            throw new NotImplementedException();  
        }

        public Player GetPlayer( SteamPlayer steamPlayer )
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer( SDG.Unturned.Player sdgPlayer )
        {
            throw new NotImplementedException();
        }


        private static void PlayerDisconnectedCallback( CSteamID player )
        {
            Console.WriteLine( "disconnected>>" + player );
        }

        private static void PlayerConnectedCallback( CSteamID player )
        {
            Console.WriteLine( "connected>>" + player );
        }


        internal List<Player> ConnectedPlayers;
    }
}