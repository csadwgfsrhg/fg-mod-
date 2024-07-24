﻿using Terraria;
using Terraria.ID;
using Fgmod;
using Terraria.Localization;
using Terraria.ModLoader;
﻿using ReLogic.Content;
using Terraria.DataStructures;
using Fgmod.Buffs;

namespace Fgmod.Items.Accessories
{
	public class MeatSheild : ModItem
	{
			public override void SetDefaults() {
			Item.width = 24;
            Item.rare = 3;
            Item.height = 26;
			Item.accessory = true;
        }
		public override void UpdateEquip(Player player)
		{
            if ((player.statLifeMax) <= (player.statLife))
            {
                player.AddBuff(ModContent.BuffType<MeatBarrier>(), 1);
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.statLifeMax2 += 10;
		

        }

	}
}