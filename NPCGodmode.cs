using Terraria.ModLoader;
using Terraria;

namespace NPCGodmode
{
    public class NPCGodmode : Mod
    {
        public NPCGodmode()
        {
            





            






        }



        int counter = 0;
        int[] idlist = new int[999];


        public override void MidUpdateInvasionNet()
        {
            if (counter <= 300)
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    if (Main.npc[i].townNPC && !Main.npc[i].dontTakeDamage)
                    {
                        bool found = false;
                        foreach (var item in idlist)
                        {
                            if (Main.npc[i].netID == item)
                            {
                                found = true;
                            }

                        }
                        if (found == false)
                        {
                            Main.npc[i].dontTakeDamage = true;
                            if (Main.npc[i].life < Main.npc[i].lifeMax)
                            {
                                Main.npc[i].life = Main.npc[i].lifeMax;
                            }
                        }
                        
                    }
                }
                counter = 0;
            }
            else
            {
                counter++;
            }
        }
        public override void Load()
        {
            int idlistcounter = 0;
            idlist[idlistcounter] = 22;
            idlistcounter++;
            idlist[idlistcounter] = 54;
        }
    }
}
