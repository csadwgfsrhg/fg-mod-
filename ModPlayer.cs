
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Fgmod.Items.Accessories;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Fgmod.Buffs;
using System.Linq;
using Fgmod;
using Fgmod.NPCs;
using Fgmod.Projectiles;
using Terraria.Audio;
using Microsoft.CodeAnalysis;
using Terraria.DataStructures;
using tModPorter;
using FullSerializer;
using Terraria.GameInput;

namespace Fgmod
{
    public class MyPlayer : ModPlayer
    {
        public bool HarvestWeapon = false;
        public bool AmethystNecklace = false;
        public bool LuminescentNecklace = false;
        public bool TopazNecklace = false;
        public bool SapphireNecklace = false;
        public bool RubyNecklace = false;
        public bool EmeraldNecklace = false;
        public bool DiamondNecklace = false;
        public bool AmberNecklace = false;
        public bool Marksmenset = false;
        public bool MoltenSet = false;
        public bool MeatSheild = false;


        public override void OnHitNPCWithItem(Item item, NPC target, NPC.HitInfo hit, int damageDone){
            if (MoltenSet && Main.rand.NextBool(2))
            {
                Projectile.NewProjectile(item.GetSource_OnHit(target), target.position, Vector2.Zero, ModContent.ProjectileType<InfernalCut>(), item.damage/2, 0f, Player.whoAmI, Player.whoAmI);

            }
            MoltenSet = false;

        }
 
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (Player.ZoneCrimson && Main.rand.NextBool(7))
            {
                itemDrop = 0;
            npcSpawn = ModContent.NPCType<FleshWatcher>();
   
             return;
         }
            if (Player.ZoneCorrupt && Main.rand.NextBool(7))
            {
                itemDrop = 0;
                npcSpawn = ModContent.NPCType<TheSludge>();

                return;
            }



        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (target.HasBuff(ModContent.BuffType<MarkBoost>())){
                SoundEngine.PlaySound(SoundID.DD2_SkeletonHurt, target.Center);
                target.AddBuff(ModContent.BuffType<MarkStrike>(), 35);
            }
            if (Marksmenset && hit.Crit)
            {
                target.AddBuff(ModContent.BuffType<MarkBoost>(), 100);
            }
            if (LuminescentNecklace && hit.Crit)
            {
                if (Main.rand.NextBool(7))
                {
                    TopazNecklace = true;
                } else
                {
                    if (Main.rand.NextBool(6))
                    {
                       AmethystNecklace = true;
                 }
                    else
                    {
                        if (Main.rand.NextBool(5))
                        {
                        
                 SapphireNecklace = true;
                     }
                        else
                        {
                            if (Main.rand.NextBool(4))
                            {
                            RubyNecklace = true;
                            }
                            else
                            {
                                if (Main.rand.NextBool(3))
                                {
                                    EmeraldNecklace = true;
                                }
                                else
                                {
                                    if (Main.rand.NextBool(2))
                                    {
                                        DiamondNecklace = true;
                                    }
                                    else
                                    {
                                        AmberNecklace = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (AmethystNecklace && hit.Crit)
            {
                target.AddBuff(BuffID.Confused, 80);
            }
            if (TopazNecklace && hit.Crit)
            {
                target.AddBuff(BuffID.Midas, 160);
            }
            if (SapphireNecklace && hit.Crit)
            {
                target.AddBuff(BuffID.Frostburn, 60);
            }
            if (RubyNecklace && hit.Crit)
            {
                Player.statLife += 1;
                Player.HealEffect(1);
            }
            if (EmeraldNecklace && hit.Crit)
            {

                target.AddBuff(BuffID.Poisoned, 150);
            }
            if (DiamondNecklace && hit.Crit)
            {
                target.AddBuff(ModContent.BuffType<Shining>(), 35);
            }
            if (AmberNecklace && hit.Crit)
            {
                target.AddBuff(BuffID.OnFire, 120);
            }
            AmberNecklace = false;
            LuminescentNecklace = false;
            DiamondNecklace = false;
            EmeraldNecklace = false;
            RubyNecklace = false;
            SapphireNecklace = false;
            TopazNecklace = false;
            AmethystNecklace = false;
            Marksmenset = false;
        }
     
    }
}
  