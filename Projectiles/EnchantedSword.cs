﻿﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Fgmod.Particles;

namespace Fgmod.Projectiles
{
	public class EnchantedSword : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 2;
		}

			public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true; 
			Projectile.timeLeft = 50; 
			Projectile.penetrate = 2; 
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.DamageType = DamageClass.Melee; 
			Projectile.aiStyle = 0;
			}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{

			{
				for (int i = 0; i < Main.rand.Next(8, 12); i++)
				{
					Dust.NewDust(Projectile.position, 28, 28, ModContent.DustType<ManaSpark>());
					Lighting.AddLight(Projectile.position, .2f, .3f, .5f);
				}
			}
		}
        public override void AI() {
            Projectile.rotation = Projectile.velocity.ToRotation();
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ManaSpark>());
            Projectile.ai[0] += 1f;

            Projectile.velocity *= .95f;
            if (++Projectile.frameCounter >= 5) {
                Projectile.tileCollide = true;
                Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
			}
		public override bool PreDraw(ref Color lightColor)
		{

            SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
			{
           
                spriteEffects = SpriteEffects.FlipHorizontally;
		}
			
		
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