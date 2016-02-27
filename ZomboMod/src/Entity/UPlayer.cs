using System;
using SDG.Unturned;
using UnityEngine;
using ZomboMod.Steam;

namespace ZomboMod.Entity
{
    public class UPlayer : IEntity, ILivingEntity
    {
        public int Hunger { get; set; }

        public int Thirst { get; set; }

        public int Stamina { get; set; }

        public int Experience { get; set; }

        public int Name { get; set; }

        public SteamChannel Channel { get; set; }

        public Item Hat { get; set; }

        public Item Shirt { get; set; }

        public Item Pants { get; set; }

        public Item Backpack { get; set; }

        public Item ItemInHand { get; set; }

        private bool IsAdmin { get; set; }

        public PlayerInventory Inventory { get; set; }

        public float Ping { get; set; }

        public InteractableVehicle CurrentVehicle { get; set; }

        public bool IsInVehicle { get; set; }

        public SteamProfile SteamProfile { get; set; }

        public bool IsDead { get; set; }

        public bool IsBleeding { get; set; }

        public bool IsLegBroken { get; set; }

        public bool IsFreezing { get; set; }

        public bool IsPro { get; set; }

        public uint Health { get; set; }

        public Vector3 Position { get; set; }

        public float Rotation { get; set; }

        public bool IsUnderWater { get; set; }

        public bool IsOnGround { get; set; }

        public float Yaw { get; set; }

        public float Pitch { get; set; }


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

        public USkill GetSkill( USkill.Type Type )
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
    }
}