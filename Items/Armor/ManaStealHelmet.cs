﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Head)]
	public class ManaStealHelmet: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
			//player.GetDamage(DamageClass.Magic) += 1f;
			//player.manaCost += 1f;
			player.statManaMax2 += 25;
        }
			public override void SetDefaults() {
			Item.width = 42;
			Item.height = 26;
			Item.maxStack = 1;
			Item.value = 100;
			Item.defense = 3;
			Item.rare = 1;
			ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
			
		}
			public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<ManaStealChestplate>() && legs.type == ModContent.ItemType<ManaStealLeggings>();
		}

		
		public override void UpdateArmorSet(Player player) {
			player.GetDamage(DamageClass.Magic) *= 1f + (50f / 100f);
			player.manaCost *= 1f + (50f / 100f);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ManaStealAlloy>(), 10);
			recipe.AddIngredient(ItemID.Feather, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}