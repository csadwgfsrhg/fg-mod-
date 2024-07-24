
using System.Diagnostics;
using Fgmod.Projectiles;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Fgmod.NPCs
{
    public class TheSludge : ModNPC
    {

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[Type] = 3;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.ShadowScale, 1));
        }
        public override void SetDefaults()
        {
            NPC.width = 46;
            NPC.height = 58;
            NPC.damage = 30;
            NPC.defense = 0;
            NPC.lifeMax = 500;      
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.knockBackResist = .5f;
            NPC.aiStyle = 3;
            NPC.noTileCollide = false;

        }

        public override void OnKill()
        {
            var entitySource = NPC.GetSource_FromAI();
            for (int i = 0; i < Main.rand.Next(15); i++)
            {
                NPC.NewNPCDirect(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Sludgling>(), NPC.whoAmI);
            }
        }
        public override void HitEffect(NPC.HitInfo hit)
        {

            var entitySource = NPC.GetSource_FromAI();
            if (Main.rand.NextBool(10))
            {

                NPC.NewNPCDirect(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Sludgling>(), NPC.whoAmI);
            }
        }
        public override void AI()
        {
            var entitySource = NPC.GetSource_FromAI();
            if (Main.rand.NextBool(1000))
            {

                NPC.NewNPCDirect(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Sludgling>(), NPC.whoAmI);
            }
            Player player = Main.player[NPC.target];

            Visuals(player);

        }


        private void Visuals(Player player)
        {
     
                int startFrame = 0;
                int finalFrame = 2;
                int frameSpeed = 5;
                int frameHeight = 58;
                
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


            NPC.spriteDirection = NPC.direction;
        }

        }
    }