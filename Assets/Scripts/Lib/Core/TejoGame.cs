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
        public int turn { get; set; }
        public Player activePlayer;
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
            this.turn = 1;
            this.activePlayer = this.players[0];
        }
        public string getScore()
        {
            return "player:" + (this.turn % this.players.Count) + "score:" + activePlayer.score;
        }
        public void newTurn() 
        {
            this.turn++;
            this.activePlayer = this.players[(this.turn - 1) % this.players.Count];
        }
        public void addScore(int score)
        {
            this.activePlayer.score += score;
        }
        ~TejoGame()
        {
        }
    }
}
