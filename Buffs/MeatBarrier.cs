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
    public class MeatBarrier : ModBuff
    {
        public override void SetStaticDefaults()
        {

            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

     


        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 15f / 100f;
            }
        }
        }
    