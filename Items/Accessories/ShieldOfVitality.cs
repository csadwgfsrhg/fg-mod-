﻿using Terraria;
using Terraria.ID;
using Fgmod;
using Terraria.Localization;
using Terraria.ModLoader;
﻿using ReLogic.Content;
using Terraria.DataStructures;
using Fgmod.Buffs;

namespace Fgmod.Items.Accessories
{
	public class ShieldOfVitality : ModItem
	{
			public override void SetDefaults() {
			Item.width = 26;
            Item.rare = 4;
            Item.height = 30;
			Item.accessory = true;
        }
		public override void UpdateEquip(Player player)
		{
            if ((player.statLifeMax) <= (player.statLife))
            {
                player.AddBuff(BuffID.Panic, 1);
                player.AddBuff(ModContent.BuffType<MeatBarrier>(), 1);
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statLifeMax2 += 10;
		

        }

	
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ModContent.ItemType<MeatSheild>());
        recipe.AddIngredient(ItemID.PanicNecklace, 1);
        recipe.AddTile(TileID.TinkerersWorkbench);
        recipe.Register();
    }
}
}
