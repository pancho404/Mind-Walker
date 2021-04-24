using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
      
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = player.transform.position.x;
        temp.y = player.transform.position.y;

        transform.position = temp;
    }

}
