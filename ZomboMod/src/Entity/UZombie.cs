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
    public class UZombie : IEntity, ILivingEntity
    {
        public uint Health { get; set; }

        public Vector3 Position { get; set; }

        public float Rotation { get; set; }

        public bool IsUnderWater { get; }

        public bool IsOnGround { get; }

        public bool IsDead { get; }

        public void Kill()
        {
            throw new System.NotImplementedException();
        }
    }
}