﻿using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace DarknessUnbound
{
    public class DUWorld : ModWorld
    {
        public static bool restlessShadows;

        public override void Initialize()
        {
            restlessShadows = false;
        }

        public override TagCompound Save() => new TagCompound() {
            { "RestlessShadows", restlessShadows }
        };

        public override void Load(TagCompound tag)
        {
            restlessShadows = tag.GetBool("RestlessShadows");
        }
    }
}
