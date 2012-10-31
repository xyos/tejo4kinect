using UnityEngine;
using System.Collections;
using Assets.Scripts.Lib.Core;

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
            this.newGame(1);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 2 - 50 / 2, 200, 50), "Dos jugadores"))
        {
            this.newGame(2);
        }

    }
    void newGame(int players)
    {
        this._game = new TejoGame(players);
        Application.LoadLevel(4);
        this._gameStarted = true;
    }
    void InGameGUI()
    {
        //Top-right
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, 100));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(this._game.getScore());
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
            this._game.activePlayer.score += 3;
            this._game.newTurn();
        }
    }
}
