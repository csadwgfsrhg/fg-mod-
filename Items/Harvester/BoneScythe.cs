﻿using Microsoft.Xna.Framework;
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
    public class BoneScythe : Scythe
    {
        public override void SetStaticDefaults()
        {
            Item.width = 60;
            Item.damage = 55;
            Item.height = 52;
            Item.rare = 4;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.shoot = ModContent.ProjectileType<BoneScytheProjectile>();

        }




        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 120);
            recipe.AddTile(TileID.BoneWelder);
            recipe.Register();
        }
    }
    public class BoneScytheProjectile : ScytheProj
    {
        public override string Texture => "Fgmod/Items/Harvester/BoneScythe";
        public override void SetStaticDefaults()
        {
            Projectile.width = 60;
            Projectile.height = 52;
            Projectile.timeLeft = 50;
        }

    }
}