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
using SDG.Unturned;
using Steamworks;
using UnityEngine;
using ZomboMod.Steam;

using SDGPlayer = SDG.Unturned.Player;

namespace ZomboMod.Entity
{
    public class Player : IEntity, ILivingEntity
    {
        public uint Health { get; set; }

        public uint Hunger { get; set; }

        public uint Thirst { get; set; }

        public uint Stamina { get; set; }

        public uint Experience { get; set; }

        public string Name { get; }

        public SteamChannel Channel { get; }

        public Item Hat { get; set; }

        public Item Glasses { get; set; }

        public Item Shirt { get; set; }

        public Item Pants { get; set; }

        public Item Backpack { get; set; }

        public Item ItemInHand { get; set; }

        private bool IsAdmin { get; set; }

        public PlayerInventory Inventory { get; set; }

        public InteractableVehicle CurrentVehicle { get; set; }

        public SteamProfile SteamProfile { get; set; }

        public float Ping { get; }

        public bool IsInVehicle { get; }

        public bool IsDead { get; }

        public bool IsBleeding { get; set; }

        public bool IsLegBroken { get; set; }

        public bool IsFreezing { get; set; }

        public bool IsPro { get; }

        public bool IsUnderWater { get; }

        public bool IsOnGround { get; }

        public float Rotation { get; set; }

        public Vector3 Position { get; set; }

        internal Player( SDGPlayer sdgPlayer )
        {
            SDGPlayer = sdgPlayer;

            SteamProfile = new SteamProfile( sdgPlayer );
            Channel = sdgPlayer.channel;

       //     Name = 
        }

        public void Kick( string reason = "Undefined" )
        {
            throw new NotImplementedException();
        }

        public Vector3? GetEyePosition( float distance, int masks )
        {
            throw new NotImplementedException();
        }

        public Vector3? GetEyePosition( float distance )
        {
            throw new NotImplementedException();
        }

        public Skill GetSkill( Skill.Type Type )
        {
            throw new NotImplementedException();
        }

        public void SendMessage( params string[] messages )
        {
            throw new NotImplementedException();
        }

        public void Chat( params string[] messages )
        {
            throw new NotImplementedException();
        }

        public void Suicide()
        {
            throw new NotImplementedException();
        }

        public void Kill()
        {
            throw new NotImplementedException();
        }

        internal SDGPlayer SDGPlayer;
    }
}