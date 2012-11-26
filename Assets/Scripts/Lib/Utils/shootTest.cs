using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class shootTest : MonoBehaviour
{
    private DateTime _start;
    System.TimeSpan duration = new System.TimeSpan(0, 0, 1, 0);
    private DateTime _end; 
    void Start()
    {
        //startTime = Time.time;
        this._start = DateTime.Now;
        this._end = _start.Add(duration);
    }
    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 300, 60), getTime());

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(50, 40, 200, 20), "Saltar Turno"))
        {
            Tejo.instance.nextTurn();
            Application.LoadLevel(4);
        }

    }
    void Update()
    {

        if (DateTime.Now > _end)
        {
            Tejo.instance.addScore(3);
            Tejo.instance.nextTurn();
            Application.LoadLevel(4);

        }
    }
    string getTime() {
        return "tiempo restante:" + (_end-DateTime.Now);
    }
}
