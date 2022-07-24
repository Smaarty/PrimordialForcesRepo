using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using PrimordialForces.Content.Items.Weapons;

namespace PrimordialForces
{
    internal class GlobalNPC : Terraria.ModLoader.GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.WallCreeper)
                {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpiderFangedSword>(), 20));
            }
        }


    }
    }

