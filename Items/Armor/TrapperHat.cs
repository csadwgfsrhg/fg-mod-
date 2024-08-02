﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using Fgmod.Projectiles.Minions;
using Fgmod.Buffs;
using Fgmod.GlobalClasses;

namespace Fgmod.Items.Armor
{
		[AutoloadEquip(EquipType.Head)]
	public class TrapperHat: ModItem

    {


        public override void UpdateEquip(Player player)
        {

            player.GetModPlayer<HarvestCharge>().CleaverMax += 1;
        }
			public override void SetDefaults() {
			
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 1; 
			Item.value = 100;
			Item.defense = 1;
            Item.rare = 0;
            ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
			}
    
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Leather, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

    }
}
