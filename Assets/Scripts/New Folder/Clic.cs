using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clic : MonoBehaviour {

    public bool cliced = false;
    void OnMouseDown()
    {
        cliced = true;
    }
    void OnMouseUp()
    {
        cliced = false;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
