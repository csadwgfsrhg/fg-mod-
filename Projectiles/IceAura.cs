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
	public class IceAura : ModProjectile
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			Projectile.width = 200;
			Projectile.height = 200;
			Projectile.friendly = true;
			Projectile.timeLeft = 12;
			Projectile.penetrate = 6;
			Projectile.knockBack = 0;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.aiStyle = -1;
		}
		public override void OnSpawn(IEntitySource source)
		{
			for (int i = 0; i < Main.rand.Next(30, 50); i++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Frost);
			}

		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
            target.AddBuff(BuffID.Frostburn, 100);
        }
	}
   }