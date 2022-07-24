using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using PrimordialForces.Content.Items;
using PrimordialForces.Content.Buffs;
using PrimordialForces.Content.Projectiles.Minions;




namespace PrimordialForces.Content.Items.Weapons;

    public class BucketOfGunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bucket Of Gunk");
            Tooltip.SetDefault("'Whats that weird Stain?'");
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.knockBack = 3f;
            Item.mana = 10;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Item.buyPrice(0, 0, 1, 50);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item44;


            // These below are needed for a minion weapon
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
        Item.buffType = ModContent.BuffType<PileOfGunkBuff>();
            // No buffTime because otherwise the item tooltip would say something like "1 minute duration"
            Item.shoot = ModContent.ProjectileType<PileOfGunkMinion>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
            player.AddBuff(Item.buffType, 2);

            // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
            position = Main.MouseWorld;
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<AncientGunk>(), 6)
            .AddIngredient(ItemID.EmptyBucket, 1)
            .AddTile(TileID.Anvils)
            .Register();

        }
    }
