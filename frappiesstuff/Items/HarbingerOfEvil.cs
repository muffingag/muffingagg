using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
	public class HarbingerOfEvil : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Two swords make a hammer? Doesn't make sense, but okay.");
		}

		public override void SetDefaults() 
		{
			item.damage = 75;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 10000;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 25);
			recipe.AddIngredient(ItemID.SoulofNight, 25);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}