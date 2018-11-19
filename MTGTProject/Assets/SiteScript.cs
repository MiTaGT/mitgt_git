using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteScript : MonoBehaviour {
    public Vector3 mousepos;
    public Vector3 screenpos;
    public Camera Main;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mousepos = Input.mousePosition;
        mousepos = new Vector3(mousepos.x, mousepos.y, 10);
        screenpos = Main.ScreenToWorldPoint(mousepos);
        transform.position = screenpos;
        transform.position = new Vector3(screenpos.x,
                                            screenpos.y,
                                            0);
    }
}
