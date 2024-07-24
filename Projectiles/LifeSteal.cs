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
using Microsoft.CodeAnalysis;
using static Humanizer.In;
using Fgmod.Buffs;

namespace Fgmod.Projectiles
{
    public class LifeSteal : ModProjectile
	{
        public override void SetDefaults()
		{
       
            Projectile.knockBack = 0;
            Projectile.rotation = Main.rand.Next(360);
            Projectile.scale = 1f;
            Projectile.width = 216;
			Projectile.height = 216;
			Projectile.timeLeft = 20;
            Projectile.Opacity = 100;
            Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.tileCollide = false;
            AIType = ProjectileID.Bullet;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 100;


        }
        public override bool? CanCutTiles()
        {
            return false;
        }
        public override void OnHitNPC(NPC npc, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[npc.target];
              
                if (Main.rand.NextBool(3))
                {
                player.HealEffect(1);
                player.statLife += 1;
                    Projectile.friendly = false;
                }
            }

        public override void AI()
		{
            Player owner = Main.player[Projectile.owner];
            Vector2 center = owner.RotatedRelativePoint(owner.MountedCenter);
            Projectile.Center = center;
            Projectile.knockBack = 0;
            Projectile.Opacity -= .03f;
            Projectile.scale *= .96f;

        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
            return true;
        }
        public override void PostDraw(Color lightColor)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
        }
    }
}
