using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class BackToSchoolLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("We do not condone school violence.\n150% more damage on teachers!");
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.melee = true;
            item.width = 0;
            item.height = 0;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.knockBack = 1;
            item.value = 10000;
            item.rare = 6;
            item.UseSound = SoundID.Item61;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("Penis");
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.None;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}