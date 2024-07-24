using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Fgmod.Particles 
{
	public class HellEmber : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noGravity = false;
			dust.scale *= 1f; 
			dust.noLight = true;
		}
			public override bool Update(Dust dust) { 
			dust.scale *= 0.92f;
            dust.position.Y -= 1f;
            Lighting.AddLight(dust.position, .5f, .1f, .2f);

            if (dust.scale < 0.2f) {
				dust.active = false;
			}

			return false; // Return false to prevent vanilla behavior.
		}
        public override bool PreDraw(Dust dust)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);
            return true;
        }
        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            return new Color(1f, 1f, 1f, 1f);
        }

        }
}
