using UnityEngine;
using Assets.Scripts.Lib.Core;

namespace Assets.Scripts
{
    public class Tejo : MonoBehaviour
    {
        private TejoGame _game;
        private bool _gameStarted;
        void Awake()
        {
            //Make this script persistent(Not destroy when loading a new level)
            DontDestroyOnLoad(this);
            //In case some game does not UN-pause..
            Time.timeScale = 1.0f;
        }
        // Use this for initialization
        void Start()
        {

        }
        void StartGame(int nr)
        {
            Application.LoadLevel(nr);
        }
        void OnGUI()
        {
            if (_gameStarted)
            {
                //Game scene
                InGameGUI();
            }
            else if (Application.loadedLevel == 2)
            {
                MainMenuGUI();
            }

        }

        void MainMenuGUI()
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 3 - 50 / 2, 200, 50), "Un jugador"))
            {
                NewGame(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 2 - 50 / 2, 200, 50), "Dos jugadores"))
            {
                NewGame(2);
            }

        }
        void NewGame(int players)
        {
            _game = new TejoGame(players);
            Application.LoadLevel(4);
            _gameStarted = true;
        }
        void InGameGUI()
        {
            //Top-right
            GUILayout.BeginArea(new Rect(0, 100, Screen.width, 100));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(_game.getScore());
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        public GUIStyle invisibleButton;
        // Update is called once per frame
        void Update()
        {
            if (_gameStarted && Application.loadedLevel == 2)
            {
                Application.LoadLevel(4);
                _game.activePlayer.score += 3;
                _game.newTurn();
            }
        }
    }
}
