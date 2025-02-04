using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //script que controla la posici� de la c�mera en funci� de la posici� del jugador. assignada a la c�mera.
    public GameObject player;
    Vector2 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        //trobar al jugador en l'escena, per saber-ne despr�s la posici�
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Entenent el mapa total com un bloc dividit en 4 pel centre, si la X val menys de la meitat (x<12) i la y tamb� (y<5.6) �s perqu� el jugador est� a la pantalla de abaix a l'esquerra, per tant la c�mera fa snap a una posici� centrada en aquell quadrant. El mateix per cadascuna de les altres 3 situacions.
        if (player.transform.position.x < 12 && player.transform.position.y < 5.6)
        {
            transform.position = new Vector3(2f, 0f, -10f);
        }
        if (player.transform.position.x > 12 && player.transform.position.y < 5.6)
        {
            transform.position = new Vector3(22f, 0f, -10f);
        }
        if (player.transform.position.x > 12 && player.transform.position.y > 5.6)
        {
            transform.position = new Vector3(22f, 11.2f, -10f);
        }
        if (player.transform.position.x < 12 && player.transform.position.y > 5.6)
        {
            transform.position = new Vector3(2f, 11.2f, -10f);
        }
    }
}
