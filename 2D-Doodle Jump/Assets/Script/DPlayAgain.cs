using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DPlayAgain : MonoBehaviour {
    public static bool IsPlayAgain;
	// Use this for initialization
	void Start () {
        IsPlayAgain = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnMouseDown()
    {
        IsPlayAgain = true;
        Debug.Log("CLICK");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DPlayAgain.IsPlayAgain = false;
    }
}
