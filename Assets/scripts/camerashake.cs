﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    private bool shakeconttrol = false;
    public IEnumerator CameraShakes(float duration,float magnitude)
    {
        Vector3 originalspos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f)*magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalspos.z);
            elapsed += Time.deltaTime;
            yield return null;

        }
        transform.localPosition = originalspos;

        

    }
    public void CameraShakescall()
    {
        if (shakeconttrol == false)
        {
            StartCoroutine(CameraShakes(0.22f, 0.4f));
            shakeconttrol = true;
        }
        
    }
}
