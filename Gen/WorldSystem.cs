using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using Fgmod.Gen;

namespace Fgmod.Gen
{
    internal class WorldSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int SmoothWorld = tasks.FindIndex(t => t.Name.Equals("Smooth World"));
            if (SmoothWorld != -1)
            {
                tasks.Insert(SmoothWorld + 1, new HellGen("Penis", 320f));
            }
        }
    }
}