using System;
using System.Collections.Generic;
using SDG.Unturned;
using Steamworks;
using ZomboMod.Entity;

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

        public IEnumerable<UPlayer> OnlinePlayers
        {
            get;
            set;
        }

        internal UServer( ushort port, string map )
        {
            ConnectedPlayers = new List<UPlayer>();

            Port = port;
            Map = map;
        }

        public void Broadcast( params string[] messages )
        {
            throw new NotImplementedException();
        }

        public void GetPlayer( CSteamID id )
        {
            throw new NotImplementedException();  
        }

        public void GetPlayer( string name )
        {
            throw new NotImplementedException();  
        }

        internal List<UPlayer> ConnectedPlayers;
    }
}