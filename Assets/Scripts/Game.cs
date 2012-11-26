using UnityEngine;
using System.Collections;
using Assets.Scripts.Lib;

public class Game : MonoSingleton<Game>
{
    public void Awake()
    {
        //persistence between levels
        DontDestroyOnLoad(this);
        //Reset the time speed
        Time.timeScale = 1.0f;
    }
    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
        MainMenu.instance.Awake();
        //Application.LoadLevel("MainMenu");
    }

    // Update is called once per frame
    public void Update()
    {
        MainMenu.instance.Update();
    }
}
