using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    float speed = 1;
    public float move = 0;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float my = Input.GetAxis("Vertical") * Time.deltaTime * speed;


        transform.position += new Vector3(mx, my, 0);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.position += new Vector3(mx * 10, my * 10, 0);
        }
        if (mx < 0)
        {
            mx = -mx;
        }
        if (my < 0)
        {
            my = -my;
        }
        move = mx + my;



        if (move > 0.01f)
        {
            if (speed <= 5)
            {
                speed += 0.1f;
            }
        }
        else
        {
            speed = 1;
        }

        if (Input.GetMouseButton(0))
        {
            var bullet_obj = Instantiate(bullet,
            transform.position,
            transform.rotation);
        }

    }
}
