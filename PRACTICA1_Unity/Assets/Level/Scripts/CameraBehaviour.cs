using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
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
