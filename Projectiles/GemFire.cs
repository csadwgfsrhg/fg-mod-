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
using Microsoft.CodeAnalysis;

namespace Fgmod.Projectiles
{
    public class GemFire : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }
        public override void SetDefaults()
		{
       
            Projectile.knockBack = 0;
            Projectile.rotation = Main.rand.Next(360);
            Projectile.scale = .8f;
            Projectile.width = 40;
			Projectile.height = 40;
			Projectile.timeLeft = 30;
            Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
            AIType = ProjectileID.Bullet;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.frame = Main.rand.Next(6);
       
    }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(3)) { 
                Projectile.friendly = false;
        }


            Projectile.velocity *= 50f / 100f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.tileCollide = false;
            Projectile.velocity *= 70f/100f;
 
            return false;
        }
        public override void AI()
		{
            if (Main.rand.NextBool(50))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
            }
                Projectile.velocity *= 87f/100f;
            Lighting.AddLight(Projectile.position, Main.rand.Next(2) - .2f, Main.rand.Next(2)-.2f, Main.rand.Next(2) - .2f);
            Projectile.knockBack = 0;
            Projectile.Opacity -= .03f;
            Projectile.scale *= 1.03f;
            Projectile.rotation += .1f;

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
    }
}
