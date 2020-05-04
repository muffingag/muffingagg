using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class Amalabow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It's odd. That's all I have to say, it's odd.");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 0;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 10;
            item.value = 10000;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenBow, 1);
            recipe.AddIngredient(ItemID.BorealWoodBow, 1);
            recipe.AddIngredient(ItemID.RichMahoganyBow, 1);
            recipe.AddIngredient(ItemID.ShadewoodBow, 1);
            recipe.AddIngredient(ItemID.EbonwoodBow, 1);
            recipe.AddIngredient(ItemID.PearlwoodBow, 1);
            recipe.AddIngredient(ItemID.PalmWoodBow, 1);
            recipe.AddIngredient(ItemID.PalmWoodBow, 1);
            recipe.AddIngredient(mod.ItemType("Wewd"), 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 10;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(90));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
