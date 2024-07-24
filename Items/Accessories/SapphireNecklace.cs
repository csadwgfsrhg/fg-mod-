﻿using Terraria;
using Terraria.ID;
using Fgmod;
using Terraria.Localization;
using Terraria.ModLoader;
﻿using ReLogic.Content;
using Terraria.DataStructures;

namespace Fgmod.Items.Accessories
{
	public class SapphireNecklace : ModItem
	{
			public override void SetDefaults() {
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetCritChance(DamageClass.Generic) += 1;
            player.GetModPlayer<MyPlayer>().SapphireNecklace = true;

        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Sapphire, 1);
			recipe.AddIngredient(ItemID.Rope, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}