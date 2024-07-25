
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Fgmod.Items.Ranged
{
	public class ObsidianArrow : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 2; 
			Item.DamageType = DamageClass.Ranged;
			Item.width = 10;
			Item.crit = 4;
			Item.height = 34;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true; 
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = 1;
			Item.shoot = ModContent.ProjectileType<Projectiles.ObsidianArrow>(); 
			Item.ammo = AmmoID.Arrow; 
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(50);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(ItemID.Obsidian, 2);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}