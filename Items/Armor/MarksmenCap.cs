﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fgmod;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Head)]
	public class MarksmenCap: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
			player.GetCritChance(DamageClass.Generic) += 2;
        }
			public override void SetDefaults() {
			Item.width = 20;
			Item.height = 30;
			Item.maxStack = 1; 
			Item.value = 100;
			Item.defense = 2;
			Item.rare = 0;
			ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
			
		}
			public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MarksmenChestplate>() && legs.type == ModContent.ItemType<MarksmenLeggings>();
		}

		
		public override void UpdateArmorSet(Player player ) {
            player.GetModPlayer<MyPlayer>().Marksmenset = true;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("IronBar", 5 );
			recipe.AddIngredient(ItemID.Chain, 60);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}