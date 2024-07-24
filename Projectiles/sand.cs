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
    public class sand : ModProjectile
	{
		public override void SetDefaults()
		{
            Projectile.knockBack = 0;
            Projectile.scale = .8f;
            Projectile.width = 36;
			Projectile.height = 30;
			Projectile.timeLeft = 50;
            Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 20;
            AIType = ProjectileID.Bullet;
			Projectile.rotation = Main.rand.Next(360);
		}

        public override void AI()
		{
			Projectile.damage = 1;
            Projectile.knockBack = 0;
            Projectile.Opacity *= .90f;
			Projectile.scale *= 1.02f;

        }
	}
}