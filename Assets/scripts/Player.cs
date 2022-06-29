using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public camerashake camerashake;
    public UIManeger uimaneger;
    public GameObject cam;
     public GameObject vectorback;
  public GameObject vectorforward;
    public Rigidbody rb;
  private Touch touch;
  [Range(20,40)]
    public int speedMidefer;
    public int forwardspeed;

    private bool speedballfoward = false;
    private bool firstouchcontrol = false;

    public void Update()
 {
if(Variables.fistouch==1 && speedballfoward==false)
        {
transform.position+=new Vector3(0,0,forwardspeed*Time.deltaTime);
vectorback.transform.position+=new Vector3(0,0,forwardspeed*Time.deltaTime);
vectorforward.transform.position+=new Vector3(0,0,forwardspeed*Time.deltaTime);
}





     //hareket ettirme
     if(Input.touchCount>0)
     {
         touch=Input.GetTouch(0);

         if(touch.phase==TouchPhase.Began){

                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (firstouchcontrol==false)
                    {
                        Variables.fistouch = 1;
                        uimaneger.fistouch();
                        firstouchcontrol = true;
                    }
                }
         }


         else if(touch.phase==TouchPhase.Moved)
         {
          
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    rb.velocity = new Vector3(
             touch.deltaPosition.x * speedMidefer * Time.deltaTime,
             transform.position.y,
             touch.deltaPosition.y * speedMidefer * Time.deltaTime);
                    if (firstouchcontrol == false)
                    {
                        Variables.fistouch = 1;
                        uimaneger.fistouch();
                        firstouchcontrol = true;
                    }
                }

            }
         else if (touch.phase==TouchPhase.Ended){
             rb.velocity= new Vector3(0,0,0);
         }

     }
 }
    public GameObject[] FractureItems;
    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Obstacles")) 
        {
             camerashake.CameraShakescall();
            uimaneger.StartCoroutine("WhiteEffect");
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            foreach (GameObject item in FractureItems)
            {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;
            }
            StartCoroutine("TimeScalecontrol");
            
        }
    }
    public IEnumerator TimeScalecontrol()
    {
        speedballfoward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        uimaneger.restartbutonactive();
        rb.velocity = Vector3.zero;
    }

}

/*
üç farklı hareket ettirme komutu vardır
--transform position
   transform.position= new Vector3(
             transform.position.x + touch.deltaPosition.x * speedMidefer*Time.deltaTime,
             transform.position.y,
             transform.position.z + touch.deltaPosition.y * speedMidefer*Time.deltaTime);
--velocity
--addforce
*/