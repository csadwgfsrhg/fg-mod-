﻿using Terraria;
using Terraria.ID;
using Fgmod;
using Terraria.Localization;
using Terraria.ModLoader;
﻿using ReLogic.Content;
using Terraria.DataStructures;

namespace Fgmod.Items.Accessories
{
	public class LuminescentNecklace : ModItem
	{
			public override void SetDefaults() {
			Item.width = 22;
			Item.height = 24;
			Item.accessory = true;
            Item.rare = 3;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetCritChance(DamageClass.Generic) += 3;
            player.GetModPlayer<MyPlayer>().LuminescentNecklace = true;
			

        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TopazNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AmethystNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EmeraldNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SapphireNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DiamondNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RubyNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AmberNecklace>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Typholite>(), 10);

            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}