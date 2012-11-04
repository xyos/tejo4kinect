using UnityEngine;
using System.Collections;
using Assets.Scripts.Lib;

public class Game : Singleton<MonoBehaviour>
{
    public global::MainMenu MainMenu
    {
        get
        {
            throw new System.NotImplementedException();
        }
        set
        {
        }
    }

    void Awake()
    {
        //persistence between levels
        DontDestroyOnLoad(this);
        //Reset the time speed
        Time.timeScale = 1.0f;
    }
    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.LoadLevel("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {


    }
}
