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
	public class LifeDrainMask: ModItem
	{
		  public override void UpdateEquip(Player player)
        {
            player.AddBuff(ModContent.BuffType<VampireAura>(), 1);
        }
			public override void SetDefaults() {
			
			Item.width = 26;
			Item.height = 28;
			Item.maxStack = 1; 
			Item.value = 100;
			Item.defense = 2;
            Item.rare = ItemRarityID.Expert;
            ArmorIDs.Head.Sets.IsTallHat[Item.headSlot] = true;
			}
    }
}
