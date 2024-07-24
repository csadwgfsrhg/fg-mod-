﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Body)]
	public class MoltenAlloyChestplate: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
			player.GetDamage(DamageClass.Generic) += 8f/100f;
			player.GetAttackSpeed(DamageClass.Melee) += 8f / 100f;
        }
			public override void SetDefaults() {
			Item.width = 30;
			Item.height = 20;
			Item.maxStack = 1;
			Item.value = 100;
			Item.defense = 7;
			Item.rare = 3;
			
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MoltenAlloy>(), 20);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}