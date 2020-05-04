 using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class Wewd : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Surprisingly light for how much stuff it took.");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 1;
            // Set other item.X values here
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddIngredient(ItemID.BorealWood, 1);
            recipe.AddIngredient(ItemID.RichMahogany, 1);
            recipe.AddIngredient(ItemID.SpookyWood, 1);
            recipe.AddIngredient(ItemID.DynastyWood, 1);
            recipe.AddIngredient(ItemID.Shadewood, 1);
            recipe.AddIngredient(ItemID.Ebonwood, 1);
            recipe.AddIngredient(ItemID.Pearlwood, 1);
            recipe.AddIngredient(ItemID.PalmWood, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}