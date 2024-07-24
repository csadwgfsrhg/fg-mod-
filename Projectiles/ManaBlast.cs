﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Projectiles
{
	public class ManaBlast : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
		}

			public override void SetDefaults() {
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.friendly = true; 
			Projectile.timeLeft = 21; 
			Projectile.penetrate = -1; 
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.DamageType = DamageClass.Magic; 
			Projectile.aiStyle = -1;
			}
			public override void AI() {
		Projectile.ai[0] += 1f;
            Lighting.AddLight(Projectile.position, .2f, .1f, 1f);
            if (++Projectile.frameCounter >= 7) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
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