
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using  Fgmod.GlobalClasses;
using static Fgmod.GlobalClasses.Cleaver;
using Terraria.DataStructures;

namespace Fgmod.Items.Harvester
{

    public class RottenCleaver : Cleaver
    {
        public override void SetStaticDefaults()
        {
            Item.width = 38;
            Item.damage = 30;
            Item.height = 34;
            Item.rare = 2;
            Item.shoot = ModContent.ProjectileType<RottenCleaverProj>();
            Item.useTime = 30;
            Item.useAnimation = 30;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<HarvestCharge>().CleaverThrow + 1 < player.GetModPlayer<HarvestCharge>().CleaverMax)
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
            recipe.AddIngredient(ItemID.RottenChunk, 5);
            recipe.AddIngredient(ItemID.DemoniteBar, 15);
            recipe.AddIngredient(ItemID.VilePowder, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
    public class RottenCleaverProj : CleaverProj
    {
        public override string Texture => "Fgmod/Items/Harvester/RottenCleaver";
        public override void SetStaticDefaults()
        {

            Projectile.width = 38;
            Projectile.height = 34;


        }
        public override void OnSpawn(IEntitySource source)
        {
            Player player = Main.player[Projectile.owner];
            player.GetModPlayer<HarvestCharge>().CleaverThrow += 2;
            player.GetModPlayer<HarvestCharge>().hungerpoints = 7;
        }
        public override void OnKill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            player.GetModPlayer<HarvestCharge>().CleaverThrow -= 2;
        }

    }
}