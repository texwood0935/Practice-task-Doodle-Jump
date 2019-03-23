using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlay : MonoBehaviour {
    public static bool isPlay;
	// Use this for initialization
	void Start () {
        isPlay = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        isPlay = true;
    }
}
