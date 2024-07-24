
using System.Diagnostics;
using Fgmod.GlobalClasses;
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
    public class ExampleCritter : FriendlyFighter
    {

       
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 2;
            NPC.damage = 10;
        }
      
      }
    }