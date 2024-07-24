using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Fgmod.Tiles;
namespace Fgmod.Items.Melee
{
    public class test : ModItem
    {
        public override void SetDefaults()
        {
            // This method quickly sets the whip's properties.
            // Mouse over to see its parameters.
            Item.shoot = ModContent.ProjectileType<Elekwhip>();
            Item.rare = ItemRarityID.Green;
            Item.useStyle = 1;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.shootSpeed = 4;
            Item.damage = 20;
            Item.noUseGraphic = true;
        }
        public override bool? UseItem(Player player)
        {

          //  WorldGen.TileRunner((int)(Main.MouseWorld.X / 16f), (int)(Main.MouseWorld.Y / 16f), 32, 5, ModContent.TileType<Basalt>, true, 0, 0, false, true);
            return base.UseItem(player);
        }
        public override bool MeleePrefix()
        {
            return true;
        }
    }
}