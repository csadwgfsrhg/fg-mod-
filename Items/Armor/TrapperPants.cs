﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fgmod.GlobalClasses;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Legs)]
	public class TrapperPants: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<HarvestCharge>().CleaverMax += 1;
            player.moveSpeed += 5f / 100f;
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
			recipe.AddIngredient(ItemID.Leather, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}