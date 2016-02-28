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

        public bool IsUnderWater { get; set; }

        public bool IsOnGround { get; set; }

        public List<Player> Passagers { get; set; }

        public int Seats { get; set; }

        public void Explode()
        {
            throw new NotImplementedException();
        }
    }
}