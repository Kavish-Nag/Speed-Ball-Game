using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 9f);
    }
}
