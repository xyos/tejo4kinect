using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class shootTest : MonoBehaviour
{
    private DateTime _start;
    void Start()
    {
        //startTime = Time.time;
        this._start = DateTime.Now;
    }
    void Update()
    {
        if (DateTime.Now > this._start.AddSeconds(5))
        {
            Tejo.instance.addScore(3);
            Tejo.instance.nextTurn();
            Application.LoadLevel(4);

        }
    }
}
