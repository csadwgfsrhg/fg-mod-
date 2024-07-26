using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Fgmod.Projectiles;
using Terraria.DataStructures;
using Mono.Cecil;

namespace Fgmod.Items.Ranged
{
	public class ShittyBlunderBuss : ModItem
	{
        /* public override void SetStaticDefaults() => Tooltip.SetDefault("Shoots elemental bullets and bombs that inflict powerful burns\n" +
              "Right click while holding for a shotgun blast\n" +
              "33% chance to not consume ammo\n" +
              "'Nature goes out with a bang'"); */
        public override void SetDefaults()
		{
			Item.damage = 8;
			Item.crit = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item14;
			Item.autoReuse = true;
			Item.shootSpeed = 5f;
			Item.noMelee = true;
			Item.useAmmo = ModContent.ItemType<Rubble>();
            Item.useTime =  50;
			Item.useAnimation = 50;
			Item.shoot = 1;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < Main.rand.Next(3, 5); i++)
            {
                Projectile.NewProjectile(source, position, velocity.RotatedByRandom(.4f), type, damage, 8f, player.whoAmI);
            }
            return false;
        }

    public override Vector2? HoldoutOffset() {
			return new Vector2(-6f, -2f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
		
			recipe.AddRecipeGroup("Wood", 10);
            recipe.AddRecipeGroup("CopperBar", 10);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}