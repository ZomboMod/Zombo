﻿ /*
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
using System.IO;
using Newtonsoft.Json.Linq;
using SDG.Unturned;
using Steamworks;
using ZomboMod.Configuration;
using ZomboMod.Entity;
using ZomboMod.Plugin;

namespace ZomboMod
{
    public static class Zombo
    {
        /// <summary>
        /// Singleton instance of Unturned Server.
        /// </summary>
        public static UServer Server { get; private set; }

        /// <summary>
        /// Singleton instance of Unturned world.
        /// </summary>
        public static UWorld  World { get; private set; }

        /// <summary>
        /// Singleton instance of Zombo plugin manager.
        /// </summary>
        public static PluginManager PluginManager { get; private set; }

        /// <summary>
        /// Server instance name.
        /// </summary>
        public static string InstanceName { get; private set; }

        /// <summary>
        /// Zombo folder.
        /// </summary>
        public static string Folder { get; private set; }
        
        /// <summary>
        /// Plugins folder.
        /// </summary>
        public static string PluginsFolder { get; private set; }

        /// <summary>
        /// Settings
        /// </summary>
        public static ZomboSettngs Settings { get; private set; }

        /// <summary>
        /// Called dinamically by ZomboCore.
        /// </summary>
        private static void Init()
        {
            if ( Server != null )
            {
                throw new InvalidOperationException( "Zombo already initalized!" );
            }

            InstanceName    = Dedicator.serverID;
            Folder          = $"Servers/{InstanceName}/Zombo/";
            PluginsFolder   = Folder + "/Plugins/";

            if ( !Directory.Exists( Folder ) )
            {
                Directory.CreateDirectory( Folder );
            }

            if ( !Directory.Exists( PluginsFolder ) )
            {
                Directory.CreateDirectory( PluginsFolder );
            }

            Settings = new ZomboSettngs();

            var settingsFile = Folder + "Settings.json";

            if ( File.Exists( settingsFile ) )
            {
                Settings.Load( settingsFile );
            }
            else
            {
                Settings.LoadDefault();
                Settings.Save( settingsFile );
            }

            Server  = new UServer( Settings.Server.Port, Settings.Server.Map );
            World   = new UWorld();

            Server.IsPvp = Settings.Server.EnablePvp;
            Server.GameMode = Settings.Server.GameMode;
            Server.CameraMode = Settings.Server.CameraMode;
            Server.SecurityMode = Settings.Server.Security;
            Server.MaxPlayers = Settings.Server.MaxPlayers;
            Server.Name = Settings.Server.Name;
            Server.Password = Settings.Server.Password;
            Server.Timeout = Settings.Server.Timeout;

            PluginManager = new PluginManager();
            PluginManager.Init();
        }
    }

    public class ZomboSettngs : JsonConfig
    {
        public ServerSettings Server { get; set; }

        public override void Load( string filePath )
        {
            try
            {
                var json = JObject.Parse( File.ReadAllText( filePath ) );
                
                // Only for validation.
                EGameMode gamemode;
                ESteamSecurity security;
                ECameraMode camera;
                int maxPlayers, port;
                
                if ( !TryParseEnum( json["Server"]["GameMode"]?.ToString(), out gamemode ) || gamemode == EGameMode.ANY )
                {
                    throw new ArgumentException( $"Invalid GameMode '{json["GameMode"]}'. Expected 'EASY, NORMAL, HARD or PRO'." );
                }
                
                if ( !TryParseEnum( json["Server"]["Security"]?.ToString(), out security ) )
                {
                    throw new ArgumentException( $"Invalid Security '{json["Security"]}'. Expected 'SECURE, INSECURE or LAN'." );
                }
                
                if ( !TryParseEnum( json["Server"]["CameraMode"]?.ToString(), out camera ) || camera == ECameraMode.ANY )
                {
                    throw new ArgumentException( $"Invalid CameraMode '{json["CameraMode"]}'. Expected 'FIRST, THIRD or BOTH'." );
                }
                
                
                if ( !int.TryParse( json["Server"]["MaxPlayers"]?.ToString(), out maxPlayers ) || (maxPlayers < byte.MinValue || maxPlayers > byte.MaxValue) )
                {
                    throw new ArgumentException( $"Invalid MaxPlayers '{json["MaxPlayers"]}'. Expected a number between 0 and 255.");
                }
                
                if ( !int.TryParse( json["Server"]["Port"]?.ToString(), out port ) || (port < ushort.MinValue || maxPlayers > ushort.MaxValue) )
                {
                    throw new ArgumentException( $"Invalid Port '{json["Port"]}'. Expected a number between 0 and 65535.");
                }
                
                base.Load( filePath );
            }
            catch (Exception ex)
            {
                Console.WriteLine( $"Invalid configuration '{FileName}'.");
                Console.WriteLine( ex );
                LoadDefault();
            }
        }

        public void LoadDefault()
        {
            Server = new ServerSettings {
                GameMode = EGameMode.NORMAL,
                CameraMode = ECameraMode.BOTH,
                Security = ESteamSecurity.SECURE,
                Name = "Zombo Server",
                Password = string.Empty,
                Map = "PEI",
                EnablePvp = true,
                Port = 27015,
                MaxPlayers = 32,
                Timeout = .75f
            };
        }

        public struct ServerSettings
        {
            public bool EnablePvp;
            public ushort Port;
            public byte MaxPlayers;
            public float Timeout;
            public string Name;
            public string Password;
            public string Map;
            public EGameMode GameMode;
            public ECameraMode CameraMode;
            public ESteamSecurity Security;
        }

        private static bool TryParseEnum<T>( string raw, out T ret )
        {
            try
            {
                ret =  (T) Enum.Parse( typeof (T), raw, true );
                return true;
            }
            catch (Exception)
            {
                ret = default(T);
                return false;
            }
        }
    }
}