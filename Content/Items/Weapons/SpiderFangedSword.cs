using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent;
using PrimordialForces.Content.Items;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;


namespace PrimordialForces.Content.Items.Weapons
{
    public class SpiderFangedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider Fanged Sword");
            Tooltip.SetDefault("'Eight ways to kill an enemy'");

        }
        public override void SetDefaults()
        {
            Item.height = 60;
            Item.width = 60;
            Item.DamageType = DamageClass.Melee;
            Item.damage = 31;
            Item.knockBack = 4.5f;
            Item.value = 8000;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.NPCDeath32;
            Item.autoReuse = true;
            Item.useTime = 42;
            Item.useAnimation = 42;
            Item.reuseDelay = 3;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextFloat(1) < 0.4f)
            {
                target.AddBuff(BuffID.Poisoned, 180);
            }
        }
        }
        
 
    }

