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
    public class VampireAura : ModBuff
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
            Lighting.AddLight(player.position, 1f, .3f, .4f);
            counter++;
            if (counter % 10 == 0)
            {
                Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.position.X + player.width / 2, player.position.Y, 0, 0, ModContent.ProjectileType<LifeSteal>(), (1), 0, Main.myPlayer, 0.0f, 1);
            }
        }
        }
    }