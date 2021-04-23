using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = player.transform.position.x + 1f;
        var y = player.transform.position.y + 1.5f;
        transform.position = new Vector3(x,y,transform.position.z);
    }
}
