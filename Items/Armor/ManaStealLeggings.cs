﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Legs)]
	public class ManaStealLeggings: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
			//player.GetDamage(DamageClass.Magic) += 1f;
			//player.manaCost += 1f;
			player.statManaMax2 += 25;
        }
			public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.maxStack = 1;
			Item.value = 100;
			Item.defense = 3;
			Item.rare = 1;
			
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaStealAlloy>(), 15);
			recipe.AddIngredient(ItemID.Leather, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}