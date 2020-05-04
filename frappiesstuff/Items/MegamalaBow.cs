using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class MegamalaBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Surprisingly odd, all there is to it!");
        }

        public override void SetDefaults()
        {
            item.damage = 125;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 0;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 100;
            item.value = 10000;
            item.rare = 10;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("Wewd"), 100);
            recipe.AddIngredient(mod.ItemType("Amalabow"), 1);
            recipe.AddIngredient(mod.ItemType("BarrierGun"), 1);
            recipe.AddIngredient(mod.ItemType("AmalgamatedSet"), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 125;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
