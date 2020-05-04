using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace frappiesstuff.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BloodsteelHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fits you perfectly! And warm!");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 18;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<BloodsteelChestplate>() && legs.type == ItemType<BloodsteelGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Increase to all damage by 10%";
			player.allDamage += 0.03f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BloodsteelBar>(), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}