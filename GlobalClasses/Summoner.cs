
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Fgmod.Items.Harvester;
using Terraria.DataStructures;
using static tModPorter.ProgressUpdate;
using Terraria.GameContent;
using Fgmod.Projectiles;
using Fgmod.Projectiles.Hitbox;
using static Terraria.ModLoader.PlayerDrawLayer;
using Terraria.Utilities;



namespace Fgmod.GlobalClasses
{


    public abstract class FriendlyFighter : ModNPC
    {
 
        public sealed override void SetDefaults()
        {
          NPC.friendly = true;
          NPC.aiStyle = 3;
            NPC.width = 18;
            NPC.height = 22;
            NPC.lifeMax = 20;
            NPC.noTileCollide = false;
            SetStaticDefaults();

        }

        public sealed override void AI()
        {

         //   var target = NPC.Center; 
         //   Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
         //   Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ModContent.ProjectileType<ExampleCritterHitbox>(), 5, 0, Main.myPlayer);
            Player player = Main.player[NPC.target];
            Visuals(player);
        }
        private void Visuals(Player player)
        {
            int startFrame = 0;
            int finalFrame = 1;
            int frameSpeed = 5;
            int frameHeight = 22;

            NPC.frameCounter += 0.5f;
            NPC.frameCounter += NPC.velocity.Length() / 10f;
            if (NPC.frameCounter > frameSpeed)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y > finalFrame * frameHeight)
                {
                    NPC.frame.Y = startFrame * frameHeight;
                }
            }
            NPC.spriteDirection = NPC.direction;
        }

    
    public sealed override void OnSpawn(IEntitySource source)
        {
           

        }
    }
}
    
