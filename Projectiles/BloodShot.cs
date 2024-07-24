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
	public class BloodShot : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
		}

			public override void SetDefaults() {
			Projectile.width = 46;
			Projectile.height = 26;
			Projectile.friendly = false; 
			Projectile.hostile = true;
			Projectile.timeLeft = 80; 
			Projectile.penetrate = -1; 
			Projectile.tileCollide = false;
			Projectile.aiStyle = -1;
			Projectile.scale = 1;

            }
        public override void OnSpawn(IEntitySource source)
        {
			Projectile.velocity *= 10f;
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 launchVelocity = new Vector2(Main.rand.NextFloat(2, -2), Main.rand.NextFloat(2, -2));
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, launchVelocity, ModContent.ProjectileType<BloodBurst>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
            }

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
        public override void AI() {
            Projectile.velocity *= .97f;

		Projectile.ai[0] += 1f;

            Projectile.rotation = Projectile.velocity.ToRotation();
            if (++Projectile.frameCounter >= 5) {
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
         
        }
	}
}