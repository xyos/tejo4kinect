using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Game.instance.Awake();
	}
	
	// Update is called once per frame
	void Update () {
        Game.instance.Update();
	}
}
