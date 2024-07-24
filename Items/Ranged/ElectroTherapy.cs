using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;

namespace Fgmod.Items.Ranged
{
	public class ElectroTherapy : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = 10000;
            Item.rare = 3;

            Item.UseSound = SoundID.Item75;
			Item.autoReuse = true;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.useTime =  60;
			Item.useAnimation = 60;
            Item.shoot = ModContent.ProjectileType<ElectroBall>();
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(-6f, -2f);
		}
	}
}