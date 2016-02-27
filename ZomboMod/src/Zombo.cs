using System;
using SDG.Unturned;
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
        /// Zombo directory.
        /// </summary>
        public static string Directory { get; private set; }

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
            Directory       = $"Servers/{InstanceName}/Zombo";

            Server          = new UServer();
            World           = new UWorld();

            // read settings
            // IP, port, pvp etc.
        }
    }
}