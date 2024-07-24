using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Fgmod.Particles 
{
	public class ManaSpark : ModDust
	{
		public override void OnSpawn(Dust dust) {
			dust.noGravity = true;
			dust.scale *= 1.5f; 
			dust.noLight = true;
		}
			public override bool Update(Dust dust) { 
			dust.scale *= 0.85f;
            Lighting.AddLight(dust.position, .1f, .05f, .4f);
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
