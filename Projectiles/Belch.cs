
using Terraria;

using Terraria.ID;
using Terraria.ModLoader;

namespace Fgmod.Projectiles
{
	public class Belch : ModProjectile
	{

			public override void SetDefaults() {
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true; 
			Projectile.timeLeft = 200; 
			Projectile.penetrate = 1;
			Projectile.tileCollide = true;
			Projectile.aiStyle = 14;
			}
    
    public override void AI()
		{
			Projectile.velocity *= .98f;
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.ScourgeOfTheCorruptor);

			}
		}           
	}
}