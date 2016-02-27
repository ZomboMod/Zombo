using UnityEngine;

namespace ZomboMod.Entity
{
    public interface IEntity
    {
        uint Health { get; set; }

        Vector3 Position { get; set; }

        float Rotation { get; set; }

        bool IsUnderWater { get; set; }

        bool IsOnGround { get; set; }
    }
}