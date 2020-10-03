using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;

namespace DisVMWapy
{
    class RPC
    {
        static bool isUpdated;
        public static void ChangeRPC(DiscordRpcClient Client,string detail,string state,string largeImg,string smailImg,string smailImgText,bool settimastamp)
        {
            RichPresence RP = new RichPresence();
            Assets a = new Assets();
            a.LargeImageKey = largeImg;
            a.SmallImageKey = smailImg;
            a.SmallImageText = smailImgText;
            a.LargeImageText = "NateTH";

            RP.Assets = a;
            RP.Details = detail;
            RP.State = state;
            if (settimastamp)
            {
                RP.Timestamps = Timestamps.Now;
                if (isUpdated)
                {
                    Client.SetPresence(RP);
                }
                else
                {
                    Client.SetPresence(RP);
                    isUpdated = true;
                }
            }
            else
            {
                Client.SetPresence(RP);
                isUpdated = true;
                
            }
            
        }
    }
}
