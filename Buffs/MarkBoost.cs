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
    public class MarkBoost : ModBuff
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
            Projectile.NewProjectile(npc.GetSource_Buff(buffIndex), npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2, 0, 0, ModContent.ProjectileType<Marked>(), 1, 0, Main.myPlayer, 0.0f, 1);

        }
        }
    }