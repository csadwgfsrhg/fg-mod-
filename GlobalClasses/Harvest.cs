
using System;

using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Fgmod.Items.Harvester;
using Terraria.DataStructures;

using Terraria.GameContent;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using Terraria.UI.Chat;



namespace Fgmod.GlobalClasses
{

    public class HarvestCharge : ModPlayer
    {
        public int CleaverMax = 4;
        public int CleaverThrow = 0;
        public int HungerMax = 50;
        public int Hunger = 0;
        public int hungerpoints = 0;
       
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            CleaverMax = 4;
            if (Hunger > HungerMax)
            {
                Hunger = HungerMax;
            }
            if (Hunger >= 10 && Main.rand.NextBool(5))
            {
              
                Dust.NewDust(Player.position, Player.width, Player.height, DustID.Blood);


            }
            if (Hunger >= 25)
            {
                if (Hunger >= 10 && Main.rand.NextBool(2))
                    Dust.NewDust(Player.position, Player.width, Player.height, DustID.Blood);


            }
            if (Hunger >= 50)
            {

                Dust.NewDust(Player.position, Player.width, Player.height, DustID.Blood);


            }


        }

    }

    public class HarvestDamage : DamageClass
    {
        public override bool UseStandardCritCalcs => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("harvest damage");
        }

        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if (damageClass == Generic) return StatInheritanceData.Full;
            return StatInheritanceData.None;
        }

        public override bool GetEffectInheritance(DamageClass damageClass) => false;

        public override void SetDefaultStats(Player player)
        {
        }

    }
    public abstract class Scythe : ModItem
    {

        public sealed override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = ModContent.GetInstance<HarvestDamage>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.shootSpeed = 10f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            SetStaticDefaults();
        }
    }
    public abstract class ScytheProj : ModProjectile
    {

        private Player Owner => Main.player[Projectile.owner];
        public sealed override void SetDefaults()
        {
            Projectile.timeLeft = 30;
            Projectile.penetrate = -1;
            Projectile.Opacity = 100;
            Projectile.knockBack = 0;
            Projectile.friendly = true;
            Projectile.scale = 1;
            Projectile.knockBack = 2;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.localNPCHitCooldown = 999999;
            Projectile.usesLocalNPCImmunity = true;
            SetStaticDefaults();


        }

        public override bool PreDraw(ref Color lightColor)
        {

            Vector2 origin;
            float rotationOffset;
            SpriteEffects effects;

            if (Projectile.spriteDirection > 0)
            {
                origin = new Vector2(0, Projectile.height);
                rotationOffset = MathHelper.ToRadians(45f);
                effects = SpriteEffects.None;
            }
            else
            {
                origin = new Vector2(Projectile.width, Projectile.height);
                rotationOffset = MathHelper.ToRadians(135f);
                effects = SpriteEffects.FlipHorizontally;
            }

            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, default, lightColor * Projectile.Opacity, Projectile.rotation + rotationOffset, origin, Projectile.scale, effects, 0);


            return false;
        }
        bool canharvest = true;
        bool landhit = false;
        int swingspeed = 0;
        private ref float InitialAngle => ref Projectile.ai[1];

        public sealed override void AI()
        {
            if (Projectile.spriteDirection > 0)
            {
                Projectile.rotation = Projectile.spriteDirection * Projectile.ai[0] + 180;
            }
            else { Projectile.rotation = Projectile.spriteDirection * Projectile.ai[0]; }


            Player player = Main.player[Projectile.owner];
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.ToRadians(90f));
            Vector2 armPosition = Owner.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, Projectile.rotation - (float)Math.PI / 2); // get position of hand

            armPosition.Y += Owner.gfxOffY;

            Projectile.ai[0] *= 1f + 2f / ((swingspeed) - 3/2) ;





            Owner.heldProj = Projectile.whoAmI;
            Projectile.Center = armPosition;
            if (landhit == true)
            {
                player.GetModPlayer<HarvestCharge>().Hunger += swingspeed / 6;
                landhit = false;
            }
        }
        public sealed override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 start = Owner.MountedCenter;
            Vector2 end = start + Projectile.rotation.ToRotationVector2() * ((Projectile.Size.Length()) * Projectile.scale);
            float collisionPoint = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, 15f * Projectile.scale, ref collisionPoint);
        }
        public sealed override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {

            modifiers.HitDirectionOverride = target.position.X > Owner.MountedCenter.X ? 1 : -1;

        }
        public sealed override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {




            if (canharvest == true)
            {
                canharvest = false;
                landhit = true;

            }


        }
        public sealed override void OnSpawn(IEntitySource source)
        {
            swingspeed = Projectile.timeLeft;
            Projectile.spriteDirection = Main.MouseWorld.X > Owner.MountedCenter.X ? 1 : -1;

            Projectile.ai[0] += 1.01f;


        }
    }
    public abstract class Cleaver : ModItem
    {

        public sealed override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = ModContent.GetInstance<HarvestDamage>();
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.shootSpeed = 10f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            SetStaticDefaults();
        }

      
        public abstract class CleaverProj : ModProjectile
        {
            int stuck = 0;
            int airtime = 0;
            int disappear = 0;
          

            public sealed override void SetDefaults()
            {
                Projectile.timeLeft = 1000;
                Projectile.penetrate = -1;
                Projectile.Opacity = 100;
                Projectile.knockBack = 0;
                Projectile.friendly = true;
                Projectile.scale = 1;
                Projectile.knockBack = 2;
                Projectile.tileCollide = true;
                Projectile.aiStyle = 2;
                SetStaticDefaults();


            }
            public int TargetWhoAmI
            {
                get => (int)Projectile.ai[1];
                set => Projectile.ai[1] = value;
            }
            public sealed override bool OnTileCollide(Vector2 oldVelocity)
            {
                if    (stuck == 0)
                    { 
                Projectile.aiStyle = 3;
            }
                return base.OnTileCollide(oldVelocity);
            }
            public sealed override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
            {
            
                Projectile.damage = 0;
                Projectile.aiStyle = -1;
                Projectile.tileCollide = false;
                TargetWhoAmI = target.whoAmI;
                
                Projectile.velocity = (target.Center - Projectile.Center) * 0.75f;
                stuck = 1;

            }
            public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
            {

                if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
                {
                    targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
                }

                return projHitbox.Intersects(targetHitbox);
            }
            public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
            {
              behindNPCs.Clear();


            }

            public sealed override void AI()
            {
                int npcTarget = TargetWhoAmI;
                Player player = Main.player[Projectile.owner];
                disappear += 1;


              if ( npcTarget < 0 || npcTarget >= 200) { 

                    Projectile.Kill();
                }
                if (disappear >= 800)
                {
                    Projectile.Opacity -= .008f;
                    
                }


                if (stuck == 0)
                {
                    airtime += 1;
                }
                else
                {

                    Projectile.Center = Main.npc[npcTarget].Center - Projectile.velocity * 2f;
                    Projectile.gfxOffY = Main.npc[npcTarget].gfxOffY;

                }


                if (stuck == 1 && player.Hitbox.Intersects(Projectile.Hitbox))
                {
                    player.GetModPlayer<HarvestCharge>().Hunger += player.GetModPlayer<HarvestCharge>().hungerpoints;
                    Projectile.Kill();

                }


            }
        }
    }
}
