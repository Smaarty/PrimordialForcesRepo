using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;



namespace PrimordialForces.Content.NPCs.Enemies
{
    public class JurassicWarrior : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jurassic Warrior");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.UndeadMiner];
        }
        public override void SetDefaults()
        {
            NPC.width = 26;
            NPC.height = 48;
            NPC.damage = 47;
            NPC.defense = 2;
            NPC.lifeMax = 77;
            NPC.knockBackResist = 0.2f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 500f;
            NPC.aiStyle = -1;
            AnimationType = NPCID.UndeadMiner;

        }
        int jumpCD;
        bool climb;

      
        public override void AI()
            
        {
            NPC.TargetClosest(true);
            Player target = Main.player[NPC.target];
            jumpCD--;
            if (NPC.collideY || climb == true)
            
            {
                //Also, it's divided by 60 so i can get velocity that increases by that value in one second (60 ticks = 1 second)
                if (target.position.X <= NPC.position.X) NPC.velocity.X -= 3.5f / 60; //Player to the left
                else if (target.position.X >= NPC.position.X) NPC.velocity.X += 3.5f / 60; //Player to the right
                if (target.position.X <= NPC.position.X && NPC.velocity.X > 0) NPC.velocity.X -= 6.5f / 60; //Player to the left, sharp reversal
                else if (target.position.X >= NPC.position.X && NPC.velocity.X < 0) NPC.velocity.X += 6.5f / 60; //Player to the right, sharp reversal
            }
            if (NPC.collideY) climb = false;


            if (NPC.collideX && jumpCD <= 0) { NPC.velocity.Y = -8f; jumpCD = 60; climb = true;} //Handles the climbing on wall
                if (NPC.position.Y < target.position.Y - 20 && !Collision.SolidTiles(NPC.position, NPC.width, NPC.height)) NPC.noTileCollide = true && !NPC.collideX; //Makes it so npc will fall through platforms, if player is beneath npc
            else NPC.noTileCollide = false;
            

            if (Math.Abs(target.position.X - NPC.position.X) < 100f && target.position.Y + 40 < NPC.position.Y && NPC.collideY && jumpCD <= 0) { NPC.velocity.Y = -9f; jumpCD = 80; } //Handles the jump

            if (NPC.velocity.X >= 4.7f) NPC.velocity.X = 4.7f; //Maximum speed
            if (NPC.velocity.X <= -4.7f) NPC.velocity.X = -4.7f;

            Collision.StepUp(ref NPC.position, ref NPC.velocity, NPC.width, NPC.height, ref NPC.stepSpeed, ref NPC.gfxOffY); //Allow npc to step up the tile, so it will not stop before it
            if (NPC.velocity.Y >= 0) Collision.StepDown(ref NPC.position, ref NPC.velocity, NPC.width, NPC.height, ref NPC.stepSpeed, ref NPC.gfxOffY); //Allow npc to step down the tile, so it will not just free fall
            if (NPC.velocity.X < 0) NPC.direction = -1;
            else NPC.direction = 1; //Handles npcs direction
        }


        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Bleeding, 45 * 60);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            return SpawnCondition.OverworldDaySlime.Chance * 1f;
        }
       

        }
    }

