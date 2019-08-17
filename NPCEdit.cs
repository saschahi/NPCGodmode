using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace NPCGodmode
{
    class NPCEdit : GlobalNPC
    {
        static ConfigToucher Karl = new ConfigToucher();
        static Dictionary<int, bool> npcInvincible;


        public override bool PreAI(NPC npc)
        {
            if (npcInvincible == null)
            {
                npcInvincible = Karl.LoadConfig();
            }
            if (npc.townNPC)
            {
                if (!npcInvincible[npc.netID])
                {
                    npc.dontTakeDamage = !npcInvincible[npc.type];
                    npc.lifeMax = 99999;
                    npc.life = npc.lifeMax;
                    npc.lifeRegen = 100;
                }
                
            }
            return base.PreAI(npc);
        }
        



    }
}
