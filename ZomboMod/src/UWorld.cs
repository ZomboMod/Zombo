using System.Collections.Generic;
using ZomboMod.Entity;

namespace ZomboMod
{
    public class UWorld
    {
        public IEnumerable<UVehicle> Vehicles { get; }

        public IEnumerable<UZombie> Zombies { get; }
    }
}