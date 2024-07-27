using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Microsoft.CodeAnalysis;
using Terraria.DataStructures;
using System;
using  Fgmod.GlobalClasses;
using Microsoft.Build.Tasks;

namespace Fgmod.Items.Harvester
{
    public class BeatingHeart : ModItem

    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.DamageType = ModContent.GetInstance<HarvestDamage>();
            Item.rare = 1;
            Item.consumable = false;
            Item.maxStack = 5;
            Item.shoot = ModContent.ProjectileType<MiniHeart>();
            Item.shootSpeed = 6f;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.UseSound = SoundID.Item9;
            Item.useStyle = 4;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<HarvestCharge>().Hunger >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.GetModPlayer<HarvestCharge>().Hunger -= 10;
            for (int i = 0; i < Item.stack; i++)
            {
                Projectile.NewProjectile(source, position, velocity.RotatedByRandom(4f), type, damage, 8f, player.whoAmI);
            }
            return false;
        }
    }
}


   