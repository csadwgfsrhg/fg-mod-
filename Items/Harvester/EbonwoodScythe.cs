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
    public class EbonwoodScythe : Scythe
    {
        public override void SetStaticDefaults()
        {
            Item.width = 42;
            Item.damage = 12;
            Item.height = 38;
            Item.rare = 0;
            Item.shoot = ModContent.ProjectileType<EbonwoodScytheProj>();
            Item.useTime = 40;
            Item.useAnimation = 40;
        }




        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Shadewood, 25);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
    public class EbonwoodScytheProj : ScytheProj
    {
        public override string Texture => "Fgmod/Items/Harvester/EbonwoodScythe";
        public override void SetStaticDefaults()
        {

            Projectile.width = 42;
            Projectile.height = 38;
            Projectile.timeLeft = 40;


        }
       

    }
}