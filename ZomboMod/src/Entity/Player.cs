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
        public SteamProfile SteamProfile { get; }

        public SteamChannel Channel { get; }

        public string Name { get; }

        public bool IsPro { get; }

        public uint Health
        {
            get { return SDGPlayer.life.health; }
            set { throw new NotImplementedException(); }
        }

        public uint Hunger
        {
            get { return SDGPlayer.life.food; }
            set { throw new NotImplementedException(); }
        }

        public uint Thirst
        {
            get { return SDGPlayer.life.water; }
            set { throw new NotImplementedException(); }
        }

        public uint Stamina
        {
            get { return SDGPlayer.life.stamina; }
            set { throw new NotImplementedException(); }
        }

        public uint Experience
        {
            get { return SDGPlayer.skills.experience; }
            set { throw new NotImplementedException(); }
        }

        public Item Hat { get; set; }

        public Item Glasses { get; set; }

        public Item Shirt { get; set; }

        public Item Pants { get; set; }

        public Item Backpack { get; set; }

        public Item ItemInHand { get; set; }

        private bool IsAdmin
        {
            get { return SteamPlayer.isAdmin; }
            set { SteamPlayer.isAdmin = value; }
        }

        public PlayerInventory Inventory
        {
            get { return SDGPlayer.inventory; }
        }

        public InteractableVehicle CurrentVehicle
        {
            get { return SDGPlayer.movement.getVehicle(); }
        }

        public float Ping
        {
            get { return Channel.owner.ping * 1000; } 
        }

        public bool IsInVehicle
        {
            get { return CurrentVehicle != null; }
        }

        public bool IsDead { get; }

        public bool IsBleeding { get; set; }

        public bool IsLegBroken { get; set; }

        public bool IsFreezing { get; set; }



        public bool IsUnderWater { get; }

        public bool IsOnGround { get; }

        public float Rotation { get; set; }

        public Vector3 Position { get; set; }

        internal Player( SDGPlayer sdgPlayer )
        {
            SDGPlayer = sdgPlayer;

            SteamProfile = new SteamProfile( sdgPlayer );

            Channel = sdgPlayer.channel;
            SteamPlayer = Channel.owner;
            IsPro = SteamPlayer.isPro;

            Name = SteamPlayer.playerID.characterName;
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
        internal SteamPlayer SteamPlayer;
    }
}