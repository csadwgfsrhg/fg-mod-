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

namespace Fgmod.Items.Harvester
{
    public class EnchantedScythe : Scythe
    {
        public override void SetStaticDefaults()
        {
            Item.width = 42;
            Item.damage = 16;
            Item.height = 34;
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<EnchantedScytheProj>();
            Item.useTime = 20;
            Item.useAnimation = 20;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 3; i++)
            {


                if (Main.rand.NextBool(3))
                {
                    Projectile.NewProjectile(source, position, velocity.RotatedByRandom(3f), ModContent.ProjectileType<Projectiles.EnchantedSpark>(), damage / 2, knockback, player.whoAmI);
                }
            }
            return true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f, 1f);

        }



       
    }
    public class EnchantedScytheProj : ScytheProj
    {
        public override string Texture => "Fgmod/Items/Harvester/EnchantedScythe";
        public override void SetStaticDefaults()
        {
            
            Projectile.width = 42;
            Projectile.height = 34;
            Projectile.timeLeft = 20;


        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f, 1f);

        }
        
    }
}