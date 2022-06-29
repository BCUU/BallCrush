using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Untagged") ||collision.gameObject.CompareTag("Obstacles"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
