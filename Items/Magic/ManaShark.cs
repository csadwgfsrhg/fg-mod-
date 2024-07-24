using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;

namespace Fgmod.Items.Magic
{
	public class ManaShark : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.crit = 15;
			Item.DamageType = DamageClass.Magic;
			Item.width = 44;
			Item.mana = 4;
			Item.height = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.shoot = ModContent.ProjectileType<ManaBullet>();
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Item.useTime = (25 - (player.statMana/15) + 1);
			Item.useAnimation = (25 - (player.statMana/15) + 1);
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(player.statMana/25));
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-6f, -2f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaStealAlloy>(), 12);
			recipe.AddIngredient(ItemID.Minishark, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}