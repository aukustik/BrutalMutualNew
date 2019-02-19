using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject enemy;
    Transform portaltr;
    Rigidbody2D enemyrigid;
    

	// Use this for initialization
	void Start () {
        //enemyrigid = enemy.GetComponent<Rigidbody2D>();
        //InvokeRepeating("CreateEnemy", 0, 3);
    }
	// Update is called once per frame
	void Update () {
        
	}
    void CreateEnemy()
    {
        Instantiate(enemy,portaltr);
    }
}
