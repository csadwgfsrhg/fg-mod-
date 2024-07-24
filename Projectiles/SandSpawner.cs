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
	public class SandSpawner : ModProjectile
	{
			public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
            Projectile.friendly = true; 
			Projectile.timeLeft = 20; 
			Projectile.friendly = false; 
			Projectile.penetrate = -1; 
			Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;
            Projectile.aiStyle = 1;
        }
	public override void AI() {
			if (Main.rand.NextBool(2))
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<sand>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 0);
			}
		}
	}
}