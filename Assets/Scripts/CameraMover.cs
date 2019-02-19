using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, -2f, -2f);
    }
}
