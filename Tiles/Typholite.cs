using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Tiles
{
	public class Typholite : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;

            MinPick = 65;
            Main.tileBlendAll[Type] = true;
       
        

            AddMapEntry(new Color(64, 43, 113));
		}

	}
}