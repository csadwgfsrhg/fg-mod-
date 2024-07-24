
using System.Diagnostics;
using Fgmod.Items.Accessories;
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
    public class FleshWatcher : ModNPC
    {

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[Type] = 3;
        }

        public override void OnSpawn(IEntitySource source)
        {
            NPC.velocity.Y -= 6f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.TissueSample, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MeatSheild>(), 4));
        }
        public override void SetDefaults()  
        {
            NPC.width = 52;
            NPC.height = 52;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.lifeMax = 400;
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 60f;
            NPC.knockBackResist = .7f;
            NPC.aiStyle = 26;
            NPC.noTileCollide = false;

        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // Spawn confetti when this zombie is hit.

            for (int i = 0; i < Main.rand.Next(15); i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
            }
        }


        int Phases = 0;
        int laser = 0;

        public override void AI()
        {
            for (int i = 0; i < Main.rand.Next(3); i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
            }
        
            if (Phases == 0)
            {
                NPC.velocity.X *= .97f;

            }
            if (Phases == 1)
            {
                NPC.damage = 17;
                NPC.defense = 10;
                NPC.velocity.X *= .99f;
                NPC.velocity.Y *= 1.02f;

            }
            if (Phases == 2)
            {
                NPC.damage = 25;
                NPC.defense = 0;
                laser += 1;

            }

            Player player = Main.player[NPC.target];

            Visuals(player);
            Shoot();
            Phase();

        }
        private void Shoot()
        {
            if (laser > 199)
            {
                NPC.noGravity = true;
                NPC.noTileCollide = true;
                NPC.aiStyle = 5;
            }
                if (laser > 299)
            {
                NPC.aiStyle = 26;
                NPC.noTileCollide = false;
                NPC.noGravity = false;
                NPC.velocity = -NPC.velocity/2;
              Player target = Main.player[NPC.target];
                Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ModContent.ProjectileType<BloodBurst>(), 5, 0, Main.myPlayer);
                laser = 0;
            }
            }
        private void Phase()
        {
            var entitySource = NPC.GetSource_FromAI();
            if   (NPC.life < NPC.lifeMax/1.5 && Phases == 0)
            {
                Phases = 1;
                NPC.knockBackResist = 1f;
        
                NPC.width = 40;
                NPC.height = 40;
               
                NPC.frame.Y = 52;
                for (int i = 0; i < 3; i++)
                {
                    NPC.NewNPCDirect(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, NPCID.GiantWormHead, NPC.whoAmI);
                }

            }
            if (NPC.life < NPC.lifeMax /2.5 && Phases == 1)
            {
                NPC.knockBackResist = 1.1f;

                Phases = 2;
                for (int i = 0; i < 2; i++)
                {
                    NPC.NewNPCDirect(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, NPCID.GiantWormHead, NPC.whoAmI);
                }
                NPC.width = 30;
                NPC.height = 30;
                NPC.frame.Y = 104;
           

            }

        }

        private void Visuals(Player player)
        {




            if (NPC.aiStyle == 26)
            {

                NPC.spriteDirection = NPC.direction;

                if (NPC.spriteDirection == 1)
                {
                    NPC.rotation += NPC.velocity.Length() / 15f;
                }
                else
                {
                    NPC.rotation -= NPC.velocity.Length() / 15f;
                }

            }
        }

        }
    }