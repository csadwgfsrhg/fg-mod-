using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Terraria.DataStructures;

namespace Fgmod.Items.Ranged
{
	public class PrismaticMist : ModItem
	{
        public static int shoot = 0;
        public override void SetDefaults()
		{
			Item.damage = 8;
			Item.crit = 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = 3;
			Item.UseSound = SoundID.DD2_BetsyFlameBreath;
			Item.autoReuse = true;
			Item.noMelee = true;
			Item.useTime = 3;
			Item.useAnimation = 21;
			Item.reuseDelay = 30;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.shoot = ModContent.ProjectileType<GemFire>();
            Item.useAmmo = AmmoID.Gel;

        }
      
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			for (int i = 0; i < Main.rand.Next(3); i++)
			{
				shoot = 30 + Main.rand.Next(10);
				Item.shootSpeed = shoot;
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(8));
                Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }


            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6f, -2f);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.Amber, 3);
            recipe.AddIngredient(ItemID.Ruby, 3);
            recipe.AddIngredient(ItemID.Sapphire, 3);
            recipe.AddIngredient(ItemID.Topaz, 3);
            recipe.AddIngredient(ItemID.Amethyst, 3);
            recipe.AddIngredient(ItemID.Emerald, 3);
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}