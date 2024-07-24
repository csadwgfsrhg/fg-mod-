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
    public class MarkStrike : ModBuff
    {
        public override void SetStaticDefaults()
        {

            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }



    
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen -= 30;

        }
        }
    }