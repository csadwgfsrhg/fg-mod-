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
	public class MoltenEmber : ModProjectile
	{
			public override void SetDefaults() {
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true; 
			Projectile.timeLeft = 70; 
			Projectile.friendly = true; 
			Projectile.penetrate = 1; 
			Projectile.tileCollide = true;
			Projectile.usesLocalNPCImmunity = true;
            Projectile.DamageType = DamageClass.Generic; 
			AIType = ProjectileID.Bullet; 

			}
        int speedincrease = 1;

        public override void AI()
        {
            float projSpeed = .1f;
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<HellEmber>());
            float maxDetectRadius = 300f; // The maximum radius at which a projectile can detect a target
       
            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null)
            {

                Player owner = Main.player[Projectile.owner];
                Vector2 center = owner.RotatedRelativePoint(owner.MountedCenter);
               Projectile.Center = center;
                Projectile.position.Y -= 30;
            }
            else
            {
               speedincrease += 1;
                Projectile.timeLeft = 200;
                SoundEngine.PlaySound(SoundID.DD2_FlameburstTowerShot, Projectile.Center);
                // If found, change the velocity of the projectile and turn it in the direction of the target
                // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
                Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * (projSpeed * speedincrease);
                Projectile.rotation = Projectile.velocity.ToRotation();
            }
        }
        // Finding the closest NPC to attack within maxDetectDistance range
        // If not found then returns null
        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs
            foreach (var target in Main.ActiveNPCs)
            {
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                if (target.CanBeChasedBy())
                {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

                    // Check if it is within the radius
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }
    }
}