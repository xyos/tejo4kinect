using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Lib.Core
{
    public class Player
    {
        public int score { get; set; }

        public TejoGame TejoGame
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public Player()
        {
            this.score = 0;
        }
    }
}
