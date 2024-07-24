﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Body)]
	public class MarksmenChestplate: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
			player.GetCritChance(DamageClass.Generic) += 3;
        }
			public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.maxStack = 1;
			Item.value = 100;
			Item.defense = 2;
			Item.rare = 0;
			
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddIngredient(ItemID.Leather, 3);
			recipe.AddIngredient(ItemID.Chain, 80);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}