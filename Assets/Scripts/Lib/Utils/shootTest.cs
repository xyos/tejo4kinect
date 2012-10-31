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
        this._start = DateTime.Now;
    }
    void Update()
    {
        if (DateTime.Now > this._start.AddSeconds(5))
        {
            Application.LoadLevel(4);
        }
    }
}
