using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assettocorsasharedmemory
{
    public class GameStatusEventArgs : EventArgs
    {
        public AC_STATUS GameStatus {get; private set;}

        public GameStatusEventArgs(AC_STATUS status)
        {
            GameStatus = status;
        }
    }
}
