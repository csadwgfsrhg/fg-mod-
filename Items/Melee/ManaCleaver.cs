using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Terraria.Audio;

namespace Fgmod.Items.Melee
{
	public class ManaCleaver : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Swing;
			//Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			//Item.noMelee = true; 
			//Item.noUseGraphic = true; 
			//Item.shoot = ModContent.ProjectileType<ManaCleaverSwing>();
		}
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Particles.ManaSpark>());
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            SoundEngine.PlaySound(SoundID.MaxMana, target.Center);
            Item.damage = (10 + player.statManaMax2/10);
			player.statMana += (player.statManaMax2/20);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaStealAlloy>(), 10);
			recipe.AddIngredient(ItemID.Leather, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}