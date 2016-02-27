using System;

namespace ZomboMod
{
    public static class Zombo
    {
        /// <summary>
        /// Singleton instance of Unturned Server.
        /// </summary>
        public static UServer Server { get; set; }

        /// <summary>
        /// Singleton instance of Unturned world.
        /// </summary>
        public static UWorld  World  { get; set; }

        /// <summary>
        /// Called dinamically by ZomboCore.
        /// </summary>
        private static void Init()
        {
            if ( Server != null )
            {
                throw new InvalidOperationException( "Zombo already initalized!" );
            }

            Server  = new UServer();
            World   = new UWorld();

            // read settings
            // IP, port, pvp etc.
        }
    }
}