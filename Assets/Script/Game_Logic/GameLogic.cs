using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script {
    interface GameLogic {

        void TakeTurn(Card card);
        void CheckRules();

    }
}
