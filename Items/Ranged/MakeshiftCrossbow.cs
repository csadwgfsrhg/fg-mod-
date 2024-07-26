using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;

namespace Fgmod.Items.Ranged
{
	public class MakeshiftCrossbow : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.crit = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.useTime =  40;
			Item.useAnimation = 40;
			Item.shoot = 1;
		}
		
		public override Vector2? HoldoutOffset() {
			return new Vector2(-6f, -2f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Cobweb, 10);
			recipe.AddRecipeGroup("Wood", 20);
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}