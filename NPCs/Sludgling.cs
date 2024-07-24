
using System.Diagnostics;
using Fgmod.Projectiles;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Fgmod.NPCs
{
    public class Sludgling : ModNPC
    {

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[Type] = 2;
        }
     
        public override void SetDefaults()
        {
            NPC.width = 26;
            NPC.height = 26;
            NPC.damage = 20;
            NPC.defense = 0;
            NPC.lifeMax = 15;      
            NPC.HitSound = SoundID.NPCHit9;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0f;
            NPC.knockBackResist = .5f;
            NPC.aiStyle = 1;
            NPC.noTileCollide = false;
            AnimationType = NPCID.GreenSlime;


        }

      
        public override void AI()
        {
        
            Player player = Main.player[NPC.target];

            Visuals(player);

        }


        private void Visuals(Player player)
        {
            NPC.spriteDirection = NPC.direction;

        }

        }
    }