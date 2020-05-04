using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace frappiesstuff.Projectiles
{
	internal class VortexBullet: ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 1;
		}

		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 40;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
            projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.penetrate = 9999999;
			projectile.tileCollide = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//3a: target.immune[projectile.owner] = 20;
			//3b: target.immune[projectile.owner] = 5;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(0, 195, 0, 0) * (1f - (float)projectile.alpha / 255f);
		}

		public override void AI()
		{
			// This code spawns 3 projectiles in the opposite direction of the projectile, with random variance in velocity.
			if (projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 3; i++)
				{
					// Calculate new speeds for other projectiles.
					// Rebound at 40% to 70% speed, plus a random amount between -8 and 8
					float speedX = -projectile.velocity.X * Main.rand.NextFloat(.4f, .7f) + Main.rand.NextFloat(-8f, 8f);
					float speedY = -projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f; // This is Vanilla code, a little more obscure.
																															 // Spawn the Projectile.
					Projectile.NewProjectile(projectile.position.X + speedX, projectile.position.Y + speedY, speedX, speedY, 90, (int)(projectile.damage * 2), 0f, projectile.owner, 0f, 0f);
				}
			}
			projectile.ai[0] += 1f;
            if (projectile.ai[0] > 50f)
            {
                // Fade out
            }
            else
            {
                // Fade in
                projectile.alpha -= 25;
                if (projectile.alpha < 100)
                {
                    projectile.alpha = 100;
                }
            }
			projectile.velocity.Y = projectile.velocity.Y + 2f; // 0.1f for arrow gravity, 0.4f for knife gravity
			if (projectile.velocity.Y > 15f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
			{
				projectile.velocity.Y = 15f;
			}
			// Slow down
			projectile.velocity *= 1f;
			// Kill this projectile after 1 second
			if (projectile.ai[0] >= 600f)
			{
				projectile.Kill();
			}
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation += MathHelper.Pi;
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (projectile.spriteDirection == -1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
			Texture2D texture = Main.projectileTexture[projectile.type];
			int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
			int startY = frameHeight * projectile.frame;
			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
			Vector2 origin = sourceRectangle.Size() / 2f;
			origin.X = (float)(projectile.spriteDirection == 1 ? sourceRectangle.Width - 20 : 20);

			Color drawColor = projectile.GetAlpha(lightColor);
			Main.spriteBatch.Draw(texture,
				projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
				sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

			return false;
		}
	}
}