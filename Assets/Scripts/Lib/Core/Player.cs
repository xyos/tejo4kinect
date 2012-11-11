using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Lib.Core
{
    public class Player
    {
        public int Score { get; set; }

        public TejoGame TejoGame
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }
    
        public Player()
        {
            this.Score = 0;
        }
    }
}
