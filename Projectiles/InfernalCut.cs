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
	public class InfernalCut : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 5;

		}

			public override void SetDefaults() {
			Projectile.width = 114;
			Projectile.height = 24;
			Projectile.friendly = true; 
			Projectile.timeLeft = 20; 
			Projectile.penetrate = -1; 
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.aiStyle = -1;
            Projectile.rotation = Main.rand.Next(360);
        }
			public override void AI() {
		Projectile.ai[0] += 1f;
            Projectile.CritChance = 0;

            if (++Projectile.frameCounter >= 4) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
			}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			{
				if (Main.rand.NextBool(2))
				{
                    target.AddBuff(BuffID.Oiled, 20);
                    target.AddBuff(BuffID.OnFire, 40);
                    Projectile.friendly = false;
				}
				SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, Projectile.Center);
				SoundEngine.PlaySound(new SoundStyle("Fgmod/Sounds/Slash"), Projectile.Center);
			}
		}

    public override bool PreDraw(ref Color lightColor)
	{
    Main.spriteBatch.End();
	//blendstate.Subtractive???????
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