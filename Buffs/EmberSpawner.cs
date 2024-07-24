﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Fgmod.Projectiles;
using System.Diagnostics.Metrics;

namespace Fgmod.Buffs
{
    public class EmberSpawner : ModBuff
    {
        public override void SetStaticDefaults()
        {

            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        int counter = 0;


        public override void Update(Player player, ref int buffIndex)
        {
            counter++;
            if (counter % 70 == 0)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y - 10, 0, 0, ModContent.ProjectileType<MoltenEmber>(), (5+ player.numMinions *5), 0, Main.myPlayer, 0.0f, 1);
            }
        }
        }
    }