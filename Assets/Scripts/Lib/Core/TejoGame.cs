using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Lib.Core
{
    /// <summary>
    /// the 'TejoGame' class, handles all logic.
    /// </summary>
    public class TejoGame
    {
        List<Player> players = new List<Player>();
        public int Turn { get; set; }
        public Player ActivePlayer;
        // Constructor
        public TejoGame(int playersCount) 
        {
            if (playersCount > 4 && playersCount < 1)
            {
                throw new Exception("bad number of players");
            }
            for (int i = 0; i < playersCount; i++)
            {
                Player player = new Player();
                Debug.Log(player);
                this.players.Add(player);
            }
            this.Turn = 0;
            this.ActivePlayer = this.players[0];
        }
        public string GetScore()
        {
            return "turn:" + this.Turn + "  player:" + (this.Turn % this.players.Count) + "  score:" + ActivePlayer.Score;
        }
        public void NewTurn() 
        {
            this.Turn++;
            this.ActivePlayer = this.players[(this.Turn - 1) % this.players.Count];
        }
        public void AddScore(int score)
        {
            this.ActivePlayer.Score += score;
        }

        public global::Tejo Tejo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
