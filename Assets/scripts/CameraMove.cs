using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float forwardspeed;
    void Update()
    {
        if (Variables.fistouch==1)
        {
            transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);
        }
       

    }
}
