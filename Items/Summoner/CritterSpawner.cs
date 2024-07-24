using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
﻿using Fgmod.Projectiles;
using Microsoft.CodeAnalysis;
using Terraria.DataStructures;
using Fgmod.NPCs;

namespace Fgmod.Items.Summoner
{
	public class CritterSpawner : ModItem
	{

        public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Summon;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.noMelee = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 1;
            Item.shootSpeed = 6f;
            Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.makeNPC = ModContent.NPCType<ExampleCritter>();
          


        }

		
	}
}