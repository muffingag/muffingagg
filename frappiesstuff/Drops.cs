using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

class MyGlobalNPC : GlobalNPC
{
    public override void NPCLoot(NPC npc)
    {
        if (npc.type == NPCID.Clown)
        {
            if (Main.rand.Next(20) < 1)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("BackToSchoolLauncher"));
            }
        }
        if (npc.type == NPCID.RedDevil)
        {
            {
                Item.NewItem(npc.getRect(), mod.ItemType("BloodsteelBar"), 25 + Main.rand.Next(25)); // 5, 6, or 7
            }
        }
    }
    public override void SetDefaults(NPC npc)
    {
        if (npc.type == NPCID.RedDevil)
        {
            npc.lifeMax = 1200;
            npc.damage = 150;
        }
        if (npc.type == NPCID.BrainofCthulhu)
        {
            npc.lifeMax = 2000;
        }
        if (npc.type == NPCID.Golem)
        {
            npc.lifeMax = 12000;
            npc.damage = 85;
        }
    }
}