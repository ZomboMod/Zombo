using System.Collections.Generic;
using UnityEngine;

namespace ZomboMod.Entity
{
    public class UVehicle : IEntity
    {
        public uint Health { get; set; }

        public Vector3 Position { get; set; }

        public float Rotation { get; set; }

        public bool IsUnderWater { get; set; }

        public bool IsOnGround { get; set; }

        public List<UPlayer> Passagers { get; set; }

        public int Seats { get; set; }

        public void Explode()
        {
            
        }
    }
}