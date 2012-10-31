using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
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

        //Detect if we're in the main menu scene
        if (Application.loadedLevel == 1)
        {
            MainMenuGUI();
        }
        else
        {
            //Game scene
            InGameGUI();
        }
    }

    void InGameGUI()
    {
        //Top-right
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, 50));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Volver al Menu"))
        {
            Destroy(gameObject); //Otherwise we'd have two of these..
            Application.LoadLevel(0);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }
    public GUIStyle invisibleButton;

    void MainMenuGUI()
    {

        if (GUI.Button(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 3 - 50 / 2, 200, 50), "Nuevo Juego"))
        {
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 200 / 2, Screen.height / 2 - 50 / 2, 200, 50), "Instrucciones"))
        {
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 200 / 2, Screen.height * 2 / 3 - 50 / 2, 200, 50), "Mejores Puntajes"))
        {
            Application.LoadLevel(2);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
