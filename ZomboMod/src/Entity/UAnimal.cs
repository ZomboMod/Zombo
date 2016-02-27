using UnityEngine;

namespace ZomboMod.Entity
{
    public class UAnimal : IEntity, ILivingEntity
    {
        public uint Health { get; set; }

        public Vector3 Position { get; set; }

        public float Rotation { get; set; }

        public bool IsUnderWater { get; set; }
        
        public bool IsOnGround { get; set; }

        public bool IsDead { get; set; }

        public void Kill()
        {
            throw new System.NotImplementedException();
        }
    }
}