using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class StaffOfEmbers : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(" ");
        }

        public override void SetDefaults()
        {
            item.damage = 90;
            item.melee = false;
            item.mana = 6;
            item.width = 0;
            item.height = 0;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.knockBack = 1;
            item.value = 10000;
            item.rare = 12;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = 376;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.None;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BloodsteelBar"), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 5;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}