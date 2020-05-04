using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class Boner : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("No, the name is not sexual, this gun is just comprised of bones! One-shots just about anything, if you're lucky.");
        }

        public override void SetDefaults()
        {
            item.damage = 99999999;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 600;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 6;
            item.value = 10000;
            item.rare = 1;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 154;
            item.shootSpeed = 16f;
            item.useAmmo =  ItemID.Bone;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 999);
            recipe.AddIngredient(mod.ItemType("Wewd"), 10);
            recipe.AddIngredient(ItemID.BoneKey);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(360));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}