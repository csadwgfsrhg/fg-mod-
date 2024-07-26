﻿using Microsoft.Xna.Framework;
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
	public class LavaSwordProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 2;
		}

			public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true; 
			Projectile.timeLeft = 70; 
			Projectile.penetrate = 6; 
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.DamageType = DamageClass.Melee; 
			Projectile.aiStyle = 14;
			}
        public override void OnSpawn(IEntitySource source)
        {
			Projectile.damage  = Projectile.damage / 3;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{

			{
				for (int i = 0; i < Main.rand.Next(20, 30); i++)
				{
					Dust.NewDust(Projectile.position, 50, 50, ModContent.DustType<HellEmber>());
                    Projectile.width = 50;
                    Projectile.height = 50;
                    SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
                    Projectile.Kill();

                }
			}
		}
        public override void AI() {
            Projectile.rotation = Projectile.velocity.ToRotation();
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<HellEmber>());
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