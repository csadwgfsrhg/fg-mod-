using Fgmod.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Items
{
	public class MoltenAlloy: ModItem
	{

			public override void SetDefaults() {
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 2;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.Obsidian, 2);
            recipe.AddIngredient(ModContent.ItemType<MoltenOre>(), 3);
            recipe.AddRecipeGroup ("CopperBar", 1 );
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}