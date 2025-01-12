using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provaObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInteract()
    {
        print("Interacted with " + gameObject.name);
        Destroy(gameObject);
    }
}
