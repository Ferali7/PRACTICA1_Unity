using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    Light2D bookshelfLight;
    private bool upIntenisty = true;
    private bool downIntensity = false;

    IEnumerator TurnOnLight()
    {
        yield return new WaitForSeconds(1.0f);
        upIntenisty = true;
        downIntensity = false;
        StartCoroutine(TurnOffLight());
    }
    IEnumerator TurnOffLight()
    {
        yield return new WaitForSeconds(1.0f);
        downIntensity = true;
        upIntenisty = false;
        StartCoroutine(TurnOnLight());
    }


    void Start()
    {
        bookshelfLight = GetComponent<Light2D>();
        StartCoroutine(TurnOffLight());
    }
    private void Update()
    {
        if (upIntenisty)
        {
            bookshelfLight.intensity = bookshelfLight.intensity + 3f * Time.deltaTime;
        }
        if (downIntensity)
        {
            bookshelfLight.intensity = bookshelfLight.intensity - 3f * Time.deltaTime;
        }
    }

}
