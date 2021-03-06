﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarknessUnbound.Items.Accessories
{
    // TBD - tweak stats? recipe
    [AutoloadEquip(EquipType.Shield)]
    public class TerraShield : DarknessItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'It shimmers with an earthly power...'" +
                             "\nGrants immunity to knockback and fire blocks" +
                             "\nGrants immunity to an extreme amount of debuffs" +
                             "\nGreatly increases life regeneration and reduces the cooldown of healing potions by 25%" +
                             "\nShields you when below 50% life" +
                             "\nEnemies are more likely to target you" +
                             "\nCauses stars to fall and increases the length of invincibility after taking damage");
        }

        public override void SafeSetDefaults()
        {
            item.accessory = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.buyPrice(0, 10);
            item.defense = 8;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // ANKH SHIELD
            player.buffImmune[46] = true;
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[33] = true;
            player.buffImmune[36] = true;
            player.buffImmune[30] = true;
            player.buffImmune[20] = true;
            player.buffImmune[32] = true;
            player.buffImmune[31] = true;
            player.buffImmune[35] = true;
            player.buffImmune[23] = true;
            player.buffImmune[22] = true;

            // CHARM OF MYTHS
            player.pStone = true;
            player.lifeRegen += 2;
            player.lifeRegenTime += 300;

            // FROZEN TURTLE SHELL
            if (player.statLife <= player.statLifeMax2 * 0.5) player.AddBuff(62, 5);

            // FLESH KNUCKLES
            player.aggro += 400;

            // STAR VEIL
            player.starCloak = true;
            player.longInvince = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AnkhShield);
            recipe.AddIngredient(ItemID.CharmofMyths);
            recipe.AddIngredient(ItemID.FrozenTurtleShell);
            recipe.AddIngredient(ItemID.FleshKnuckles);
            recipe.AddIngredient(ItemID.StarVeil);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.SetResult(this);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddRecipe();
        }
    }
}
