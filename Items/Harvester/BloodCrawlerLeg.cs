using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Microsoft.CodeAnalysis;
using Terraria.DataStructures;
using System;
using  Fgmod.GlobalClasses;

namespace Fgmod.Items.Harvester
{
    public class BloodCrawlerLeg : Scythe
    {
        public override void SetStaticDefaults()
        {
            Item.width = 50;
            Item.damage = 12;
            Item.height = 44;
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<BloodCrawlerLegProj>();
            Item.useTime = 15;
            Item.useAnimation = 15;
        }



    }
    public class BloodCrawlerLegProj : ScytheProj
    {
        public override string Texture => "Fgmod/Items/Harvester/BloodCrawlerLeg";
        public override void SetStaticDefaults()
        {

            Projectile.width = 50;
            Projectile.height = 44;
            Projectile.timeLeft = 15;


        }
       

    }
}