using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Items
{
	public class Typholite: ModItem
	{

			public override void SetDefaults() {
			Item.width = 10;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 2;
		}
		
	}
}