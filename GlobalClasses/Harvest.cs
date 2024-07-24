
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Fgmod.Items.Harvester;
using Terraria.DataStructures;
using static tModPorter.ProgressUpdate;
using Terraria.GameContent;



namespace Fgmod.GlobalClasses
{




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
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.shootSpeed = 10f;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.shoot = ModContent.ProjectileType<ObsidianScytheProjectile>();
            SetStaticDefaults();
        }
    }
        public abstract class ScytheProj : ModProjectile
        {
         
            private Player Owner => Main.player[Projectile.owner];
            public sealed override void SetDefaults()
            {
                Projectile.timeLeft = 60;
                Projectile.penetrate = -1;
                Projectile.Opacity = 100;
                Projectile.knockBack = 0;
                Projectile.friendly = true;
                Projectile.scale = 1;
                Projectile.knockBack = 2;
                Projectile.tileCollide = false;
                Projectile.aiStyle = -1;
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
            int drawback = 0;
            private ref float InitialAngle => ref Projectile.ai[1];
            public override string Texture => "Fgmod/Items/Harvester/ObsidianScythe";
            public sealed override void AI()
            {
                Projectile.rotation = Projectile.spriteDirection * Projectile.ai[0];
                Player player = Main.player[Projectile.owner];
                Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.ToRadians(90f));
                Vector2 armPosition = Owner.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, Projectile.rotation - (float)Math.PI / 2); // get position of hand

                armPosition.Y += Owner.gfxOffY;
                if (Projectile.ai[0] < 9 && drawback == 0)
                {
                    Projectile.ai[0] *= 1.1f;
              
                }
                else
                {
                    drawback = 1;

                    Projectile.ai[0] -= .2f;
                }


                Owner.heldProj = Projectile.whoAmI;
                Projectile.Center = armPosition;

              
            }
            public sealed override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
            {
                Vector2 start = Owner.MountedCenter;
                Vector2 end = start + Projectile.rotation.ToRotationVector2() * ((Projectile.Size.Length()) * Projectile.scale);
                float collisionPoint = 0f;
                return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, 15f * Projectile.scale, ref collisionPoint);
            }
            public sealed override void OnSpawn(IEntitySource source)
            {
              
                Projectile.spriteDirection = Main.MouseWorld.X > Owner.MountedCenter.X ? 1 : -1;
         
                Projectile.ai[0] += 1.01f;

                InitialAngle = 90f * Projectile.spriteDirection + 135f; // Otherwise, we calculate the angle
            }
            }



        }
    
