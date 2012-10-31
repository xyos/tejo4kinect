using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Lib
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;

        public static T instace
        {
            get
            {
                if (instace == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (instance == null)
                    {
                        Debug.LogError("An instance of" + typeof(T) +
                            " is needed in the scene, but couldn't find one.");
                    }
                }
                return instace;
            }
        }
    }
}
