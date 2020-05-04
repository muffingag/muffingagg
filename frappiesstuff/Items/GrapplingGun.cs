using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class GrapplingGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Oh neat, a grappling hook- but it's a gun.");
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 0;
            item.useAnimation = 0;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 600;
            item.value = 10000;
            item.rare = 0;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useAmmo = ItemID.None;
            item.shoot = 13;
            item.shootSpeed = 16f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Chain, 20);
            recipe.AddIngredient(ItemID.Hook, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage = 30, knockBack = -999, player.whoAmI);
            }
            return false;
        }
    }
}