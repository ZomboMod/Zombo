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

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZomboMod.Entity
{
    public class Vehicle : IEntity
    {
        public uint Health { get; set; }

        public Vector3 Position { get; set; }

        public float Rotation { get; set; }

        public bool IsUnderWater { get; }

        public bool IsOnGround { get; }

        public IEnumerable<Player> Passagers { get; }

        public int Seats { get; }

        public void Explode()
        {
            throw new NotImplementedException();
        }
    }
}