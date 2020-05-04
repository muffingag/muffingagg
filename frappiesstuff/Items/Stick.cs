using Microsoft.Xna.Framework;
using Terraria;
using System.IO;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class Stick : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Can't reach the light switch from the couch? That one book too high on the shelf bothering you?\nWell this stick is for you!");
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 40;
            item.height = 20;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.value = 10000;
            item.rare = 0;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}