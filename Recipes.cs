using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;


namespace Fgmod
{
    public class Recipes : ModSystem
    {
        public class HellstoneBar : GlobalItem
        {
            public override void SetDefaults(Item item)

            { 
                if (item.type == ItemID.HellstoneBar)
                {

                }
            }
        }
        public override void AddRecipeGroups()
        {
            RecipeGroup SilverBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.SilverBar)}", ItemID.SilverBar, ItemID.TungstenBar);
            RecipeGroup CopperBarRecipeGroup = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.CopperBar)}", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.SilverBar), SilverBarRecipeGroup);
            RecipeGroup.RegisterGroup(nameof(ItemID.CopperBar), CopperBarRecipeGroup);
        }
        public override void AddRecipes()
        {

            Recipe baseRecipe = Recipe.Create(ItemID.HellstoneBar);
          //  baseRecipe.AddRecipeGroup("CopperBar", 2)
           //  .AddIngredient(ItemID.Hellstone, 3)
            // .AddIngredient(ItemID.Obsidian, 2)
            // .AddTile(TileID.Hellforge)
            //   .Register();

        }
    }
}