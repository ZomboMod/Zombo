﻿/*
 *
 *   This file is part of ZomboMod Project.
 *     https://www.github.com/ZomboMod
 *   
 *   Copyright (C) 2016 Leonardosnt
 *   
 *   ZomboMod is licensed under CC BY-NC-SA.
 *   
 */


using System.Collections.Generic;
using ZomboMod.Entity;

namespace ZomboMod
{
    public class World
    {
        public IEnumerable<Vehicle> Vehicles { get; }

        public IEnumerable<Zombie> Zombies { get; }
    }
}