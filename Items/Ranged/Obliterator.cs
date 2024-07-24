using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;

namespace Fgmod.Items.Ranged
{
	public class Obliterator : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.crit = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = 0;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.useTime =  40;
			Item.useAnimation = 40;
         
        }
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-6f, -2f);
		}

	}
}