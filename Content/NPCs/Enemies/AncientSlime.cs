using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.ItemDropRules;
using PrimordialForces.Content.Items;

namespace PrimordialForces.Content.NPCs.Enemies
{
    public class AncientSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Slime");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 15;
            NPC.damage = 28;
            NPC.defense = 6;
            NPC.lifeMax = 140;
            NPC.value = 25f;
            NPC.aiStyle = 1;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.GreenSlime;
            AnimationType = NPCID.GreenSlime;
        }
        public override void AI() { 
        
           
            {
                int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Cloud, 0f, 0f, 0, Colors.RarityGreen, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0;
            }

        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.PlayerSafe && NPC.downedSlimeKing == true)
            {
                return SpawnCondition.OverworldDaySlime.Chance * 0.05f;
            }
            else
            {
                return 0f;
            }



        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;

        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientGunk>(), 1));
        }
    }
}




