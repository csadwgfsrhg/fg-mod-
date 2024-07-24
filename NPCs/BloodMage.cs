
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
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class BloodMage : ModNPC
    {

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[Type] = 7;
        }

        public override void SetDefaults()
        {
            NPC.width = 58;
            NPC.height = 98;
            NPC.damage = 14;
            NPC.defense = 4;
            NPC.lifeMax = 1200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 60f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            NPC.npcSlots = 10f;
            NPC.boss = true;

            NPC.noTileCollide = false;
        
        }
      int wait = 0;
      int attack = 0; 
      int cooldown = 0;
        public override void AI()
        {

         
            NPC.velocity.X *= .9f;
         cooldown -= 1;
            Lighting.AddLight(NPC.position, 1f, .3f, .4f);
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }
            Player player = Main.player[NPC.target];

            if (player.dead)
            {
                NPC.velocity.Y -= 0.02f;
                NPC.noTileCollide = true;
             NPC.EncourageDespawn(10);
                return;
            }

            Visuals();
            pointtoplayer(player);
   

             
                if (attack < 2 && attack > 0)
            {
                shoot();
            }
            if (attack < 3 && attack > 1)
            {
                Teleport(player);
            }
            if (attack < 4 && attack > 2)
            {
                Read();
            }
            if (cooldown < 1 && attack < 1)
            {
                if (Main.rand.NextBool(2))
                {
                    attack = 1;
                }
                else
                {
                    if (Main.rand.NextBool(4))
                    {
                        attack = 3;
                      
                    }
                    else
                    {
                        attack = 2;
                    }
                }
            }
        }
        private void Read()
        {
            wait += 1;
            if (wait > 100)
            {
                attack = 0;
                cooldown += 320 / (NPC.lifeMax / NPC.life);
                wait = 0;
            }
        }
        private void shoot()
        {
            Player target = Main.player[NPC.target];
            Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
            direction = direction.RotatedByRandom(MathHelper.ToRadians(10));
            wait += 1;

                if (wait > 30)
                {

           
                NPC.velocity.X += NPC.direction/2f;

                if (wait > 30 && wait < 32)
                {
                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ModContent.ProjectileType<BloodShot>(), 5, 0, Main.myPlayer);
                    Main.projectile[projectile].damage = 20;
                }
                    if (wait > 40)
                {
                    attack = 0;
                    cooldown += 120 / (NPC.lifeMax / NPC.life);
                    wait = 0;
                }
            }

        }
        private void pointtoplayer(Player player)
        {
            if (player.position.X > NPC.position.X )
            {
                NPC.direction = -1;

            }
            else
            {
                NPC.direction = 1;
            
            }

        }
        private void Visuals()
        {

            if (attack < 3 && attack > 1)
            {
                if ( wait > 1)
                {
                    NPC.frame.Y = 98;
                }
                if (wait > 6 && wait > 8)
                {
                    NPC.frame.Y = 196;
                }
                if (wait > 12 && wait > 14)
                {
                    NPC.frame.Y = 294;
                }
                if (wait > 18 && wait > 20)
                {
                   NPC.Opacity = 0;
                }
                if (wait > 24 && wait > 26)
                {
                    NPC.Opacity = 100;
                    NPC.frame.Y = 294;
                }
                if (wait > 30 && wait > 32)
                {
                    NPC.frame.Y = 196;
                }
                if (wait > 36 && wait > 38)
                {
                    NPC.frame.Y = 0;
                }

            }


            if (attack < 4 && attack > 2)
            {
                if (wait < 100)
                {
                    NPC.frame.Y = 588;
                }
                if (wait > 100)
                {
                    NPC.frame.Y = 0;
                }
            }


                if (attack < 2 && attack > 0)
            {
                NPC.frame.Y = 0;

                if (wait > 9 && wait > 11)
                {
                    NPC.frame.Y = 392;
                }

                if (wait > 14 && wait > 16)
                {
                    NPC.frame.Y = 490;
                }
            }
            if (attack < 1)
            {
                NPC.frame.Y = 0;
            }

            NPC.spriteDirection = NPC.direction;

        }
        private void Teleport(Player player)
        {
            if (wait < 1) { 
            SoundEngine.PlaySound(SoundID.Item8, NPC.Center);
        }
            wait += 1;
           
            if (wait < 20)
            {
                NPC.damage = 0;
            }
            if (wait > 19 && wait < 21)
            {
                NPC.position.Y = player.position.Y - 60;
                NPC.position.X = Main.rand.Next(1000) - Main.rand.Next(1000) + player.position.X;
            }
        
            if (wait > 38)
            {
                NPC.damage = 20;
                wait = 0;
                attack = 0;
                cooldown += 120 / (NPC.lifeMax / NPC.life);


            }


            }
        }
    }
