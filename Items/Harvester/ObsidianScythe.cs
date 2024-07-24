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
    public class ObsidianScythe : Scythe
    {
        public override void SetStaticDefaults()
        {
            Item.width = 54;
            Item.damage = 20;
            Item.height = 42;
        
        }




        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 100);
            recipe.AddIngredient(ItemID.ShadowScale, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
    public class ObsidianScytheProjectile : ScytheProj
    {
        public override void SetStaticDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 42;
         
        }

    }
}