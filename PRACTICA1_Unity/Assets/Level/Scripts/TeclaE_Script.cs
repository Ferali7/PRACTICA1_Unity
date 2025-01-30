using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TeclaE_Script : MonoBehaviour
{
    public MC_Action mc_action;
    public Image image;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        image.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
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