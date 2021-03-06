﻿using DarknessUnbound.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DarknessUnbound.Projectiles.Tropidium
{
    public class WhirlpoolYoyo : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 10f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 350f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 22f;
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.melee = true;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.netUpdate = true;
            projectile.aiStyle = 99;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        float rot = 0f;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Main.Transform);

            Texture2D spiral = mod.GetTexture("Projectiles/Tropidium/WhirlpoolSpiral");
            spriteBatch.Draw(spiral, projectile.Center - Main.screenPosition, new Rectangle(0, 0, spiral.Width, spiral.Height), Color.White, rot, new Vector2(spiral.Width, spiral.Height) / 2f, 1f, SpriteEffects.None, 0f);
            return true;
        }

        public override void PostAI()
        {
            rot += MathHelper.ToRadians(20);
            Dust dust = Dust.NewDustPerfect(projectile.Center, ModContent.DustType<TropidiumGlow>(), null, 0, Color.White, 1f);
            dust.noGravity = true;
            dust.velocity += projectile.rotation.ToRotationVector2() * 5;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
    }
}
