using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;

namespace Fgmod.Items.Melee
{
	public class Dagger : ModItem
	{
		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee;
			Item.width = 28;
			Item.height = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.damage = 10;
			Item.autoReuse = true;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.crit = 20;
			Item.shoot = 0;
				}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (hit.Crit) {
                Projectile.NewProjectile(Item.GetSource_OnHit(target), target.position, Vector2.Zero, ModContent.ProjectileType<Cut>(), Item.damage, Main.myPlayer);
    }
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 7);
            recipe.AddIngredient(ItemID.Leather, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}