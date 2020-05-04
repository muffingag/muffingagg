using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class BanHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("No comment.");
        }

        public override void SetDefaults()
        {
            item.damage = 90;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 99999999;
            item.value = 10000;
            item.rare = 10;
            item.UseSound = SoundID.Item1;
            item.useAmmo = ItemID.None;
            item.shoot = 207;
            item.autoReuse = true;
            item.shootSpeed = 16f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ectoplasm, 25);
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddIngredient(mod.ItemType("HarbingerOfEvil"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, 1, 99999999, player.whoAmI);
            }
            return false;
        }
    }
}