﻿using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Items.Placeable
{
	public class Basalt : ModItem
	{
			public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Basalt>());
			Item.width = 12;
			Item.height = 12;
			Item.value = 0;
		}
	}
}