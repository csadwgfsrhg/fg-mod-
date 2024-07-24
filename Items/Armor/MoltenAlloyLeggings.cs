﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Legs)]
	public class MoltenAlloyLeggings: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
			player.GetDamage(DamageClass.Generic) += 6f/100f;
				player.maxMinions += 1; 
        }
			public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.maxStack = 1;
			Item.value = 100;
			Item.defense = 6;
			Item.rare = 3;
			
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MoltenAlloy>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}