


using Fgmod.Items.Accessories;
using Fgmod.Items.Harvester;
using Fgmod.Items.Ranged;
using Fgmod.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;




namespace Fgmod.GlobalClasses
{

    public class EnchantedSword : GlobalItem
    {

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.EnchantedSword)
            {
              
                item.damage = 15;
                item.useTime = 54;
                item.shootSpeed = 12;
                item.useAnimation = 27;
                 item.shoot = ModContent.ProjectileType<Projectiles.EnchantedSword>();
            }

        }
    }
    public class Starfury : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Starfury)
            {
                item.damage = 13;
                item.useTime = 60;
                item.useAnimation = 20;

          //      item.shoot = 0;
           
            }

        }
    
        public override void OnHitNPC(Item item, Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (item.type == ItemID.Starfury)
            {

               
            }
         
        }
        
          

        }
    
    public class IceBlade : GlobalItem
    {
       
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.IceBlade)
            {
                //  TextureAssets.Item[item.type] = ModContent.Request<Texture2D>(Fgmod.Items.Melee.IceBlade).Value;
            //    Texture2D texture = "Fgmod/Items/Harvester/BoneScythe";
                item.shootSpeed = 0;
                item.damage = 18;
                item.useTime = 80;
               item.useAnimation = 40;
                item.shoot = ModContent.ProjectileType<Projectiles.IceAura>();
            }

        }
      
          
        }
    public class rangedweapons : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
            if (Item.type == ItemID.Minishark)
            {
                Item.damage = 9;
            }
            if (Item.type == ItemID.FlintlockPistol)
            {
                Item.damage = 15;
            }
            if (Item.type == ItemID.Blowpipe)
            {
                Item.damage = 12;
            }
            if (Item.type == ItemID.Handgun)
            {
                Item.damage = 30;
            }
            if (Item.type == ItemID.PhoenixBlaster)
            {
                Item.damage = 35;
            }
        }
    }
    public class ammo : GlobalItem
    {
        public override void SetDefaults(Item Item)
        {
        
                if (Item.type == ItemID.WoodenArrow || Item.type == ItemID.FlamingArrow || Item.type == ItemID.UnholyArrow || Item.type == ItemID.JestersArrow ||
                Item.type == ItemID.MusketBall || Item.type == ItemID.MeteorShot || Item.type == ItemID.HellfireArrow || Item.type == ItemID.Seed ||
                 Item.type == ItemID.HolyArrow || Item.type == ItemID.CursedArrow || Item.type == ItemID.FrostburnArrow || Item.type == ItemID.ChlorophyteArrow ||
                 Item.type == ItemID.ChlorophyteBullet || Item.type == ItemID.HighVelocityBullet || Item.type == ItemID.PoisonDart || Item.type == ItemID.IchorArrow ||
                 Item.type == ItemID.IchorBullet || Item.type == ItemID.VenomArrow || Item.type == ItemID.VenomBullet || Item.type == ItemID.PartyBullet ||
                 Item.type == ItemID.NanoBullet || Item.type == ItemID.ExplodingBullet || Item.type == ItemID.GoldenBullet || Item.type == ItemID.BoneArrow ||
                 Item.type == ItemID.CrystalDart || Item.type == ItemID.IchorDart || Item.type == ItemID.EndlessQuiver || Item.type == ItemID.EndlessMusketPouch ||
                 Item.type == ItemID.ShimmerArrow || Item.type == ItemID.CursedBullet || Item.type == ItemID.CrystalBullet || Item.type == ItemID.CursedDart)
            {
                Item.damage = 0;
            }
            if (Item.type == ItemID.SilverBullet || Item.type == ItemID.TungstenBullet)

            {
                Item.damage = 2;
            }
        }
    }





    public class NpcLoot : GlobalNPC
    {

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Zombie)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BeatingHeart>(), 10));
            }
                if (npc.type == NPCID.EyeofCthulhu)
            {
              
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EnchantedScythe>()));
            }
        }
    }


}


