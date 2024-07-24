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

namespace Fgmod.Projectiles.Hitbox
{
	public class ExampleCritterHitbox : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.timeLeft = 1;
			Projectile.penetrate = 1;
			Projectile.tileCollide = false;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.aiStyle = 1;
		}

		public override void AI()
		{
		
		
		}
	}
	}
