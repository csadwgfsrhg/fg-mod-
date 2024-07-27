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
using Fgmod.GlobalClasses;

namespace Fgmod.Projectiles
{
	public class EnchantedSpark : ModProjectile
	{
		public override void SetStaticDefaults() {
		}

			public override void SetDefaults() {
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true; 
			Projectile.timeLeft = 90; 
			Projectile.penetrate = 1; 
			Projectile.tileCollide = true;
			Projectile.aiStyle = 14;
			}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
            Player player = Main.player[Projectile.owner];
            player.GetModPlayer<HarvestCharge>().Hunger += 1;



                for (int i = 0; i < Main.rand.Next(8, 12); i++)
				{
					Dust.NewDust(Projectile.position, 28, 28, ModContent.DustType<ManaSpark>());
					Lighting.AddLight(Projectile.position, .2f, .3f, .5f);
				}
			
		}
        public override void AI() {
            Projectile.velocity *= .93f;
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<ManaSpark>());
			}
		
			
		
          
	}
}