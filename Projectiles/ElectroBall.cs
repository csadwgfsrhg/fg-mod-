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
using Fgmod.Buffs;

namespace Fgmod.Projectiles
{
	public class ElectroBall : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.timeLeft = 300;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.DamageType = DamageClass.Magic;
			AIType = ProjectileID.Bullet;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Elektric>(), 80);
        }
        public override void AI()
		{
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric);
            Lighting.AddLight(Projectile.position, .2f, .3f, .5f);
        }
	}
}

