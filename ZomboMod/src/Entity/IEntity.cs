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

using UnityEngine;

namespace ZomboMod.Entity
{
    /*
        TODO:
            teleport(Vec3) ?

    */
    public interface IEntity
    {
        uint Health { get; set; }

        Vector3 Position { get; set; }

        float Rotation { get; set; }

        bool IsUnderWater { get; }

        bool IsOnGround { get; }
    }
}