using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {


    public GameObject locks;
    public float movespeed;
    public Vector3 movemap;
    public float shottime;
    public float shottimemax;

	// Use this for initialization
	void Start () {
        //locklist = GameObject.FindGameObjectsWithTag("Site");
        //for (var i = 0; i < locklist.length; i++)
        //{
        //    if (locklist[i].GetComponent.< SiteScript > ().LocalPlayer == true)
        //    {
        //        lock = locklist[i];
        //    }
        //}
        locks = GameObject.Find("lockonsite");
        movemap = locks.transform.position - transform.position;
        movemap = movemap.normalized;
        LookAt2D(transform,locks.transform,Vector2.right);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        transform.position += movemap * movespeed;
    }

    public void LookAt2D(Transform self, Transform target, Vector2 forward)
    {
        LookAt2D(self, target.position, forward);
    }

    public void LookAt2D(Transform self, Vector3 target, Vector2 forward)
    {
        var forwardDiff = GetForwardDiffPoint(forward);
        Vector3 direction = target - self.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        self.rotation = Quaternion.AngleAxis(angle - forwardDiff, Vector3.forward);
    }

    /// <summary>
    /// 正面の方向の差分を算出する
    /// </summary>
    /// <returns>The forward diff point.</returns>
    /// <param name="forward">Forward.</param>
    static private float GetForwardDiffPoint(Vector2 forward)
    {
        if (Equals(forward, Vector2.up)) return 90;
        if (Equals(forward, Vector2.right)) return 0;
        return 0;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
