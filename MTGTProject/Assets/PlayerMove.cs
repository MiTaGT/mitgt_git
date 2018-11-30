using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    float speed = 1;
    public float move = 0;
    public GameObject bullet;

    public bool stepflag = false;
    public Vector3 steppos;
    public Vector3 vs;
    public float vlong = 0;
    public float stepspeed = 1;

    public GameObject shadow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //上下左右入力取得
        float mx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float my = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //移動操作
        if (!stepflag)
        {
            transform.position += new Vector3(mx, my, 0);
        }
        //ステップ入力を取った時の処理
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (stepflag == false)
            {
                //transform.position + new Vector3(mx * 10, my * 10, 0);
                steppos = new Vector3(mx, my, 0).normalized;
                steppos = transform.position + new Vector3(steppos.x * 5, steppos.y * 5, 0);
                stepflag = true;
            }
        }
        //
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
        Step();

    }

    void Step()
    {
        if (stepflag) {
            vs = steppos - transform.position;
            vlong = vs.magnitude;
            if (vlong > 2)
            {
                Instantiate(shadow, transform.position, transform.rotation);
                transform.position += vs.normalized * stepspeed * Time.deltaTime;
            }
            else
            {
                stepflag = false;
            }
        }
    }
}
