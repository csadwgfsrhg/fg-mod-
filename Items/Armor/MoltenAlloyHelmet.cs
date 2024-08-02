﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using Fgmod.Projectiles.Minions;
using Fgmod.Buffs;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Head)]
	public class MoltenAlloyHelmet: ModItem

    {


        public override void UpdateEquip(Player player)
        {

            player.AddBuff(ModContent.BuffType<EmberSpawner>(), 1);
            player.maxMinions += 1;
        }
			public override void SetDefaults() {
			
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 1; 
			Item.value = 100;
			Item.defense = 4;
			Item.rare = 3;
			ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
			}
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<MoltenAlloyChestplate>() && legs.type == ModContent.ItemType<MoltenAlloyLeggings>();
        }


        public override void UpdateArmorSet(Player player)
        {
            player.GetModPlayer<MyPlayer>().MoltenSet = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MoltenAlloy>(), 17);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }
}
