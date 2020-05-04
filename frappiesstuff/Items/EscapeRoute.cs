using Microsoft.Xna.Framework;
using Terraria;
using System.IO;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class EscapeRoute : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("An escape route for any situation!");
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.ranged = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1500;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = SoundID.Item11;
            item.healLife = 0;
            item.autoReuse = false;
            item.useAmmo = ItemID.None;
            item.shoot = 180;
            item.shootSpeed = 9f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddIngredient(ItemID.LeadBar, 5);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X * -1, perturbedSpeed.Y * -1, type, player.statLifeMax2 / 2 + player.statDefense, 1500, player.whoAmI);
                player.AddBuff(BuffID.Ironskin, 5400);
                player.AddBuff(BuffID.Lifeforce, 5400);
                player.AddBuff(BuffID.Regeneration, 5400);
                player.AddBuff(BuffID.Rage, 5400);
                player.AddBuff(BuffID.Titan, 5400);
                player.AddBuff(BuffID.Wrath, 5400);
            }
            return false;
        }
    }
}