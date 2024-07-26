using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using Terraria.ID;
using Fgmod.Tiles;

namespace Fgmod.Gen
{
    internal class HellGen : GenPass
    {
        public HellGen(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Altering Hell";


            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile = Main.tile[i, j];
                    if (tile.TileType == TileID.Ash )
                        tile.TileType = (ushort)ModContent.TileType<Basalt>();
                }
            }


                int maxToSpawn = (Main.maxTilesX / 8);
            int numSpawned = 0;
         
            while (numSpawned < maxToSpawn)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX );
                int y = WorldGen.genRand.Next(Main.maxTilesY - 200, Main.maxTilesY);

                Tile tile = Framing.GetTileSafely(x, y);


                if (tile.TileType == ModContent.TileType<Basalt>())
                {
                  


                        WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 15), WorldGen.genRand.Next(10, 20), ModContent.TileType<TypholiteVar>());
                    }

                if (tile.TileType == ModContent.TileType<TypholiteVar>())
                
                    {
                        WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(9, 15), ModContent.TileType<Typholite>());
                    }
                if (tile.TileType == ModContent.TileType<Typholite>())

                {
                    WorldGen.digTunnel(x, y, 0, 0, WorldGen.genRand.Next(2, 3), WorldGen.genRand.Next(1, 3), true);
                }

                numSpawned++;
                }

             
            }
        }
    }





    