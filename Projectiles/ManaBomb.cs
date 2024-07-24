﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
﻿using Fgmod.Particles;
using Terraria.ModLoader;

namespace Fgmod.Projectiles
{
	public class ManaBomb : ModProjectile
	{
			public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true; 
			Projectile.timeLeft = 200; 
			Projectile.penetrate = 1; 
			Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.DamageType = DamageClass.Magic; 
			Projectile.aiStyle = 1;
			}
	public override void OnKill(int timeLeft) {
            Lighting.AddLight(Projectile.position, .5f, .2f, 2f);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<ManaExplosion>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
	SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
	}

	public override void AI() {
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ManaSpark>());
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