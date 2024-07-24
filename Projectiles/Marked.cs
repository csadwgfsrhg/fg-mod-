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
	public class Marked : ModProjectile
	{


			public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.friendly = false; 
			Projectile.timeLeft = 2; 
			Projectile.tileCollide = false;
			Projectile.aiStyle = -1;
        }
    }
}