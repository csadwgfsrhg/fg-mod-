
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using  Fgmod.GlobalClasses;
using static Fgmod.GlobalClasses.Cleaver;
using Terraria.DataStructures;

namespace Fgmod.Items.Harvester
{

    public class IronCleaver : Cleaver
    {
        public override void SetStaticDefaults()
        {
            Item.width = 30;
            Item.damage = 12;
            Item.height = 30;
            Item.rare = 0;
            Item.shoot = ModContent.ProjectileType<IronCleaverProj>();
            Item.useTime = 25;
            Item.useAnimation = 25;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<HarvestCharge>().CleaverThrow < player.GetModPlayer<HarvestCharge>().CleaverMax)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
    public class IronCleaverProj : CleaverProj
    {
        public override string Texture => "Fgmod/Items/Harvester/IronCleaver";
        public override void SetStaticDefaults()
        {

            Projectile.width = 30;
            Projectile.height = 30;


        }
        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.player[Projectile.owner];
            player.GetModPlayer<HarvestCharge>().CleaverThrow += 1;
            player.GetModPlayer<HarvestCharge>().hungerpoints = 4;
        }
        public override void OnKill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            player.GetModPlayer<HarvestCharge>().CleaverThrow -= 1;
        }

    }
}