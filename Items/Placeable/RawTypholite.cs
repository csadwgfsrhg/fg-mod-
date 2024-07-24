using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Items.Placeable
{
    public class RawTypholite : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Typholite>());
            Item.width = 12;
            Item.height = 12;
            Item.value = 0;
            Item.rare = 1;
        }
        public override void ExtractinatorUse(int extractinatorBlockType, ref int resultType, ref int resultStack)
        { // Calls upon use of an extractinator. Below is the chance you will get ExampleOre from the extractinator.
            if (Main.rand.NextBool(10))
            {
                resultType = ModContent.ItemType<Typholite>();
                resultStack = Main.rand.Next(2);
            }
            else
            {
                if (Main.rand.NextBool(3))
                {
                    resultType = ItemID.AshBlock;
                    resultStack = Main.rand.Next(2);
                }
                else
                {
                    if (Main.rand.NextBool(2))
                    {
                        resultType = ModContent.ItemType<Basalt>();
                        resultStack = Main.rand.Next(2);
                    }
                    else
                    {
                        resultType = ItemID.CopperCoin;
                        resultStack = Main.rand.Next(99);
                    }
                }
            }
           
        }
    }
}