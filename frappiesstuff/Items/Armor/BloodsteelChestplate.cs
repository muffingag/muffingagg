using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace frappiesstuff.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BloodsteelChestplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("All nice and perfectly snug, and warm too!");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 30;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return legs.type == ItemType<BloodsteelGreaves>() && head.type == ItemType<BloodsteelHelm>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increase to all damage by 10%";
			player.allDamage += 0.03f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BloodsteelBar>(), 40);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}