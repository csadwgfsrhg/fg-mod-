﻿using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;

namespace Fgmod.Items.Ranged
{
	public class BarbedArrow : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 0; 
			Item.DamageType = DamageClass.Ranged;
			Item.width = 10;
			Item.crit = 4;
			Item.height = 34;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true; 
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = 0;
			Item.shoot = ModContent.ProjectileType<Projectiles.BarbedArrow>(); 
			Item.ammo = AmmoID.Arrow; 
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddRecipeGroup("IronBar", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}