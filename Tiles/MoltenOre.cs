using Fgmod.Items;
using Fgmod.Items.Placeable;
using Fgmod.Particles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Tiles
{
    public class MoltenOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            HitSound = SoundID.Tink;
            MinPick = 65;
            MineResist = 3f;
            Main.tileBlendAll[Type] = true;


            AddMapEntry(new Color(64, 43, 113));
        }
        public override void DrawEffects(int i, int j, SpriteBatch spriteBatch, ref TileDrawInfo drawData)
        {
            if (Main.rand.NextBool(200))
            {
                Dust dust = Dust.NewDustDirect(new Vector2(i * 16 + 2, j * 16 - 4), 4, 8, ModContent.DustType<HellEmber>(), 0f, 0f, 100);
            }
        }
      
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Tile tile = Main.tile[i, j];
            tile.LiquidType = LiquidID.Lava;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
                r = 0.2f;
        }
    }
}
          