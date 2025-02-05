using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TeclaE_Script : MonoBehaviour
{
    //script que controla com es mostra l'animació de la tecla E sobre el personatge i com s'oculta
    //a l'script de MC_action es troba la variable showE que ens indica si s'ha de mostrar o no.
    public MC_Action mc_action;
    public Image image;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //agafem el component imatge del gameObject per modificar el seu alpha després (i ferlo transparent). comença tenint un alpha de valor 0 (transparent)
        image = GetComponent<Image>();
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //si showE es vertadera, el color de la imatge passa a valer 1, 1, 1 i 1 (RGB i Alpha). Si és falsa, baixem l'alpha a 0.
        if (mc_action.showE)
        {
            image.color = new Color(1f, 1f, 1f, 1f);
        }
        else if (!mc_action.showE)
        {
            image.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}