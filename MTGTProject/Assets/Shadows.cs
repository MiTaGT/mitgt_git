using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour {
    float deletetime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(deletetime > 0.25f)
        {
            Destroy(gameObject);
        }
        else
        {
            deletetime += 1 * Time.deltaTime;
        }
	}
}
