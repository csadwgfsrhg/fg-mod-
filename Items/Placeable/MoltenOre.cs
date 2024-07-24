using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Items.Placeable
{
	public class MoltenOre : ModItem
	{
			public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f, 1f);

        }
        public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MoltenOre>());
			Item.width = 12;
			Item.height = 12;
			Item.value = 0;
            Item.rare = 2;
        }
	}
}