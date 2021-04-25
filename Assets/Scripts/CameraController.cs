using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    [SerializeField]
    float offset,zOffset;

    private void Start()
    {
      
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = player.transform.position.x;
        temp.y = player.transform.position.y + offset;
        temp.z = -10 + zOffset;

        transform.position = temp;
    }

}
