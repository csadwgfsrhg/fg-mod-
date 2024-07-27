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
using Microsoft.Build.Tasks;

namespace Fgmod.Projectiles
{
	public class MiniHeart : ModProjectile
	{
		public override void SetStaticDefaults() {
			Main.projFrames[Projectile.type] = 3;
		}

			public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true; 
			Projectile.timeLeft = 2000; 
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.aiStyle = 14;
			}
        public override void OnSpawn(IEntitySource source)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            Projectile.frame = Main.rand.Next(0, 2);
			if (Main.rand.NextBool(2))
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
        }
		int timer = 0;
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];


            timer += 1;

			if (timer >= 30 && player.Hitbox.Intersects(Projectile.Hitbox) )
            {
                player.statLife += 4;
                player.HealEffect(4);
                Projectile.Kill();

            }
			
		}

		
			
		
           
	public override Color? GetAlpha(Color lightColor)
{
    return new Color(1f, 1f, 1f, 1f);

		}
	}
}