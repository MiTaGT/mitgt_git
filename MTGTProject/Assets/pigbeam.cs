using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigbeam : MonoBehaviour {

    public GameObject chargeb;
    public GameObject beam;
    public float times;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            beam.SetActive(false);
            chargeb.SetActive(true);
            times += 1 * Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            if(times > 0)
            {
                chargeb.SetActive(false);
                beam.SetActive(true);
                times -= 1 * Time.deltaTime;

            }
            else
            {
                beam.SetActive(false);
                times = 0;
            }
        }
	}
}
