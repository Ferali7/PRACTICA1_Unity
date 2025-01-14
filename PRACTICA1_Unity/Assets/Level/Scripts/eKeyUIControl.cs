using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class eKeyUIControl : MonoBehaviour
{
    public MC_Action mc_action;
    private RectTransform rectTransform;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.SetActive(true);
        //amaguem la UI en un primer moment
        color = spriteRenderer.color;
        color.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        posicioE(transform.position);
        if (mc_action.showE == true)
        {
            color.a = 100;
            //gameObject.SetActive(true);
        }
        else if (mc_action.showE == false)
        {
            color.a = 0;
            //gameObject.SetActive(false);
        }
    }
    public void posicioE(Vector2 worldPosition)
    {
        //convertir la worldposition de la camera en una variable nova que li direm "screenposition", per després passar aquestes dades de posició a ON s'ha de mostrar la tecla E
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);
        rectTransform.position = screenPosition + new Vector2(1,1);
        
    }
}*/