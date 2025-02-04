using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    //script utilitzant el sistema de llums per il�luminar les prestatgeries que s�n m�bils amb mantenir la tecla E polsada.
    Light2D bookshelfLight;
    //variables que controlaran si la llum est� pujant o baixant
    private bool upIntenisty = true;
    private bool downIntensity = false;
    public float timeFlicker = 1.0f; //variable que controla cada quant varia la llum
   
    public float intensityVariation = 3.0f; //variable que controla quant s'il�lumina la prestatgeria

    IEnumerator TurnOnLight() //en aquest delay indiquem que volem que la llum s'il�lumini despr�s del segons indicats en timeFlicker
    {
        yield return new WaitForSeconds(timeFlicker);
        upIntenisty = true;
        downIntensity = false;
        StartCoroutine(TurnOffLight()); //fem que torni a apagar-se
    }
    IEnumerator TurnOffLight() //en aquest delay indiquem que volem que la llum s'apahui despr�s del segons indicats en timeFlicker
    {
        yield return new WaitForSeconds(timeFlicker);
        downIntensity = true;
        upIntenisty = false;
        StartCoroutine(TurnOnLight()); //fem que torni a il�luminar-se
    }


    void Start()
    {
        bookshelfLight = GetComponent<Light2D>();
        StartCoroutine(TurnOffLight()); //com ja comen�a il�luminada, fem que s'apagui
    }
    void Update()
    {
        if (upIntenisty) //Aqui simplement cridem a la llum per despr�s dir-li que augmenti la intensitat de la llum per "IntensityVariation" cada segon
        {
            bookshelfLight.intensity = bookshelfLight.intensity + intensityVariation * Time.deltaTime;
        }
        if (downIntensity) //Aqui simplement cridem a la llum per despr�s dir-li que disminueixi la intensitat de la llum per "intensityVariation" cada segon
        {
            bookshelfLight.intensity = bookshelfLight.intensity - intensityVariation * Time.deltaTime;
        }
    }

}
