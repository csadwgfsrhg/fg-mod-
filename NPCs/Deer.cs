
using System.Diagnostics;
using Fgmod.Projectiles;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Fgmod.NPCs
{
    public class Deer : ModNPC
    {

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[Type] = 4;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Leather, 2));
        }
        public override void SetDefaults()
        {
            NPC.width = 54;
            NPC.height = 68;
            NPC.damage = 0;
            NPC.defense = 5;
            if (Main.expertMode)
            {
                NPC.lifeMax = 200;
            }
            else
            {
                NPC.lifeMax = 125;
            }
               
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.knockBackResist = .3f;
            NPC.aiStyle = -1;
            NPC.noTileCollide = false;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.2f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            NPC.aiStyle = 26;
            NPC.damage = 18;
        }
        public override void AI()
        {
            NPC.velocity.X *= .97f;

            Player player = Main.player[NPC.target];

            Visuals(player);

        }


        private void Visuals(Player player)
        {
            if (NPC.aiStyle == -1)
            {
                NPC.frame.Y = 204;
            }
            if (NPC.aiStyle == 26) {
                int startFrame = 0;
                int finalFrame = 2;
                int frameSpeed = 5;
                int frameHeight = 68;
                
                NPC.frameCounter += 0.5f;
                NPC.frameCounter += NPC.velocity.Length() / 10f;
                if (NPC.frameCounter > frameSpeed)
                {
                    NPC.frameCounter = 0;
                    NPC.frame.Y += frameHeight;
                    if (NPC.frame.Y > finalFrame * frameHeight)
                    {
                        NPC.frame.Y = startFrame * frameHeight;
                    }
                }
            }


            NPC.spriteDirection = NPC.direction;
        }

        }
    }