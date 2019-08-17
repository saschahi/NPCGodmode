using Terraria.ModLoader;

namespace NPCGodmode
{
    public class NPCGodmode : Mod
    {
        ConfigToucher Karl = new ConfigToucher();

        public NPCGodmode()
        {

        }

        public override void PostAddRecipes()
        {
            //Reading the config file
            Karl.CheckConfig();
            Karl.LoadConfig();
        }

    }
}
