using UnityEngine;
using System.Collections;
using Assets.Scripts.Lib;

public class Game : Singleton<MonoBehaviour>
{

    void Awake()
    {
        //persistence between levels
        DontDestroyOnLoad(this);
        Time.timeScale = 1.0f;
    }
    // Use this for initialization
    void Start()
    {
         Application.LoadLevel("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
