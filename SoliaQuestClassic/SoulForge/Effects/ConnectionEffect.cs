using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliaQuestClassic.SoulForge.Effects
{
    public class ConnectionEffect : SQEffect
    {
        public ConnectionEffect()
        {
            ModifyEffectReference("Connected", "connectionEffect");
            tooltip = "The spirits of Kiravael supply you with more power.";
            stackMax = -1;
            doShowEffect = true;
            m_timeLeft = -1;
        }


        //requires some unimplemented stuff.
    }
}
