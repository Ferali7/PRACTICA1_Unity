using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ConeEnemy : MonoBehaviour
{
    private bool turnUp = true;
    private bool turnDown;
    private void Update()
    {
        if (turnUp)
        {
            if (transform.localRotation.z > 15f)
            {
                turnUp = false;
                turnDown = true;
            }
            else
            {
                transform.Rotate(0, 0, 5f * Time.deltaTime);
            }    
        }
        if (turnDown)
        {
            if (transform.localRotation.z < -15f)
            {
                turnUp = true;
                turnDown = false;
            }
            else
            {
                transform.Rotate(0, 0, -5f * Time.deltaTime);
            }
        }
    }

}
