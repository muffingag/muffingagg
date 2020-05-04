 using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace frappiesstuff.Items
{
    public class BloodsteelBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Hot and wet, from blood- and being practically on fire.");
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
    }
}