﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Particles;

namespace Fgmod.Projectiles
{
    public class ManaBullet : ModProjectile
    {
        public override void SetDefaults() {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.timeLeft = 200;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.DamageType = DamageClass.Magic;
            AIType = ProjectileID.Bullet;
        }
        public override void OnKill(int timeLeft) {

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<ManaBlast>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }

        public override void AI() {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ManaSpark>());




            NPC closestNPC = FindClosestNPC(80f);
            if (closestNPC == null)
                return;
            {
                Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * (10f);
                Projectile.rotation = Projectile.velocity.ToRotation();

            }
        }


        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

     
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            foreach (var target in Main.ActiveNPCs)
            {
                if (target.CanBeChasedBy())
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }
            return closestNPC;
        }

public override bool PreDraw(ref Color lightColor)
{
    Main.spriteBatch.End();
    Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
    return true;
}
	public override void PostDraw(Color lightColor)
{
    Main.spriteBatch.End();
    Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
}
	public override Color? GetAlpha(Color lightColor)
{
    return new Color(1f, 1f, 1f, 1f);

		}
	}
}