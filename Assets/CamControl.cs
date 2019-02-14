using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    void Start()
    {

    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 0f, -2f);
    }
}
