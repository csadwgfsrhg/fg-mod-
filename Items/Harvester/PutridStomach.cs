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
    public class PutridStomach : ModItem

    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.DamageType = ModContent.GetInstance<HarvestDamage>();
            Item.rare = 2;
            Item.damage = 15;
            Item.consumable = false;
            Item.shoot = ModContent.ProjectileType<Belch>();
            Item.shootSpeed = 12f;
            Item.useTime = 3;
            Item.useAnimation = 60;
            Item.UseSound = SoundID.NPCDeath13;
            Item.useStyle = 4;
            Item.reuseDelay = 3;
            Item.noUseGraphic = true;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddIngredient(ItemID.VilePowder, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }


        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<HarvestCharge>().Hunger >= 20)
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

            player.GetModPlayer<HarvestCharge>().Hunger -= 1;

           
                Projectile.NewProjectile(source, position, velocity.RotatedByRandom(.7f), type, damage, 8f, player.whoAmI);
            
            return false;
        }
    }
}


   