using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Items
{
	public class ManaStealAlloy: ModItem
	{

			public override void SetDefaults() {
			Item.width = 30;
			Item.height = 24;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(2);
			recipe.AddIngredient(ItemID.FallenStar, 1);
			recipe.AddRecipeGroup ("SilverBar", 2 );
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}