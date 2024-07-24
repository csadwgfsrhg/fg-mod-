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
	public class BloodBurst : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			Projectile.width = 12;
			Projectile.height = 28;
			Projectile.friendly = false;
			Projectile.hostile = true;
			Projectile.timeLeft = 200;
			Projectile.penetrate = 1;
			Projectile.tileCollide = false;
			Projectile.aiStyle = -1;
			Projectile.scale = 1;
     
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.NPCHit8, Projectile.Center);
        }
        public override void AI()
		{
            Projectile.velocity *= 1.02f;

            Projectile.ai[0] += 1f;

            Projectile.rotation = Projectile.velocity.ToRotation();
            if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
          
        }
	}
}