﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;


namespace Fgmod.Projectiles
{
	public class ObsidianArrow : ModProjectile
	{

        public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 16;
			Projectile.friendly = true; 
			Projectile.timeLeft = 2000;
            Projectile.penetrate = 2; 
			Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.aiStyle = 1;
			}
			public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if (hit.Crit) { 
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<Cut>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0, 1);
                Projectile.penetrate += 1;
            }
			}
	}
}