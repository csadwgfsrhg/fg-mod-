using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;

namespace Fgmod.Items.Magic
{
	public class ManaScepter : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Magic;
			Item.width = 36;
			Item.mana = 35;
			Item.height = 36;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 1;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shootSpeed = 7f;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<ManaBomb>();
			Item.staff[Type] = true;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaStealAlloy>(), 7);
			recipe.AddIngredient(ItemID.ManaCrystal, 1);
			recipe.AddIngredient(ItemID.Leather, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}