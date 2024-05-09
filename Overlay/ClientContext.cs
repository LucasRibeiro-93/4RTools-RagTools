using System.Collections.Generic;
using _4RTools.Model;
using _4RTools.Utils;

namespace _4RTools.Overlay
{
    public class ClientContext
    {
        public Client ROClient;
        public readonly HashSet<uint> ActiveBuffs = new HashSet<uint>();
        public readonly uint AmmunitionStatusId = 0;

        public void FetchAllClientData()
        {
            FetchClientAmmoStatus();
            FetchClientBuffs();
        }

        private void FetchClientAmmoStatus()
        {
        }

        public void FetchClientBuffs()
        {
            ActiveBuffs.Clear();
            
            for (var i = 0; i < Constants.MAX_BUFF_LIST_INDEX_SIZE - 1; i++)
            {
                var activeBuff = ROClient.CurrentBuffStatusCode(i);
                if (activeBuff == uint.MaxValue) continue; //Ignore invalid buffs

                ActiveBuffs.Add(activeBuff);
            }
        }
    }
}