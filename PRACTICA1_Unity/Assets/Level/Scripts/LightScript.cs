using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    Light2D bookshelfLight;
    private bool upIntenisty = true;
    private bool downIntensity = false;
    public float timeFlicker = 1.0f;
    public float intensityVariation = 3.0f;

    IEnumerator TurnOnLight()
    {
        yield return new WaitForSeconds(timeFlicker);
        upIntenisty = true;
        downIntensity = false;
        StartCoroutine(TurnOffLight());
    }
    IEnumerator TurnOffLight()
    {
        yield return new WaitForSeconds(timeFlicker);
        downIntensity = true;
        upIntenisty = false;
        StartCoroutine(TurnOnLight());
    }


    void Start()
    {
        bookshelfLight = GetComponent<Light2D>();
        StartCoroutine(TurnOffLight());
    }
    void Update()
    {
        if (upIntenisty)
        {
            bookshelfLight.intensity = bookshelfLight.intensity + intensityVariation * Time.deltaTime;
        }
        if (downIntensity)
        {
            bookshelfLight.intensity = bookshelfLight.intensity - intensityVariation * Time.deltaTime;
        }
    }

}
