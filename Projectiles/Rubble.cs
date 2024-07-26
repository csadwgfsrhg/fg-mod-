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
	public class Rubble : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.timeLeft = 2000;
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.aiStyle = 2;
		}
		public override void OnKill(int timeLeft)
		{

		}
	}
    }
	
