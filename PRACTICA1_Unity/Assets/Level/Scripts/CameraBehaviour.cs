using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //script que controla la posició de la càmera en funció de la posició del jugador. assignada a la càmera.
    public GameObject player;
    Vector2 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        //trobar al jugador en l'escena, per saber-ne després la posició
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Entenent el mapa total com un bloc dividit en 4 pel centre, si la X val menys de la meitat (x<12) i la y també (y<5.6) és perquè el jugador està a la pantalla de abaix a l'esquerra, per tant la càmera fa snap a una posició centrada en aquell quadrant. El mateix per cadascuna de les altres 3 situacions.
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
