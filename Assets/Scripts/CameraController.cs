using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public void Callibrate(int width, int height)
    {
        float xPos = (width - transform.localScale.x) / 2;
        float zPos = height / 2;

        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }

}
