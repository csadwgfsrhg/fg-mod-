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
    public class ElectricAura : ModProjectile
	{
        public override void SetDefaults()
		{
       
            Projectile.knockBack = 0;
            Projectile.rotation = Main.rand.Next(360);
            Projectile.scale = 1f;
            Projectile.width = 80;
			Projectile.height = 80;
			Projectile.timeLeft = 6;
            Projectile.Opacity = 100;
            Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
            AIType = ProjectileID.Bullet;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 10;
       
    }

        public override void AI()
		{
            Projectile.knockBack = 0;
            Projectile.Opacity -= .15f;
            Projectile.scale *= 1.05f;

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
