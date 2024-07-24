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
using Fgmod.Items.Accessories;

namespace Fgmod.Projectiles
{
	public class BarbedArrow : ModProjectile
	{

        public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 16;
			Projectile.friendly = true; 
			Projectile.timeLeft = 2000;
            Projectile.penetrate = 1; 
			Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.aiStyle = 1;
			}
			public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (hit.Crit) { 
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Cut>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
				}
			}
	}
}