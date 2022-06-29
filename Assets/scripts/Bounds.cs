using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
  public Transform vectorback;
  public Transform vectorforward;
  public Transform vectorright;
  public Transform vectorleft;
  public void LateUpdate()
  {
      Vector3 VievPos =transform.position;
      VievPos.z=(Mathf.Clamp(VievPos.z,vectorback.transform.position.z,vectorforward.transform.position.z));
      VievPos.x=(Mathf.Clamp(VievPos.x,vectorleft.transform.position.x,vectorright.transform.position.x));
      transform.position=VievPos;

  }
}
