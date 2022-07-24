using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace PrimordialForces.Content.Items
{
    internal class AncientGunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Gunk");
            Tooltip.SetDefault("It reeks of sweat");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;

            Item.value = Item.buyPrice(copper: 10);
            Item.maxStack = 999;
        }
    }
}
