using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    //script utilitzant el sistema de llums per il·luminar les prestatgeries que són mòbils amb mantenir la tecla E polsada.
    Light2D bookshelfLight;
    //variables que controlaran si la llum està pujant o baixant
    private bool upIntenisty = true;
    private bool downIntensity = false;
    public float timeFlicker = 1.0f;
    //variable que controla quant s'il·lumina la prestatgeria
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
