using Microsoft.Xna.Framework;
using Terraria;
using System.IO;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class Trusty : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Your greatest friend, a trusty pistol, always by your side! Not in any way related to dragons.\nScales with your ingame progression, it could always be useful!");
            DisplayName.SetDefault("Ol' Betsy");
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 10;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = 10;
            item.shootSpeed = 9f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 5);
            recipe.AddIngredient(ItemID.LeadBar, 7);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, player.statLifeMax2 / 10 + player.statDefense, 4, player.whoAmI);
            }
            return false;
        }
    }
}