using Fgmod.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Tiles
{
	public class TypholiteVar : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;
            MinPick = 65;
            RegisterItemDrop(ModContent.ItemType<Items.Placeable.RawTypholite>());
       
            Main.tileBlendAll[Type] = true;

          
            AddMapEntry(new Color(136, 71, 49));
		}
       

    }
}