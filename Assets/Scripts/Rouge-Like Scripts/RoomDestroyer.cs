using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnPoint" || other.gameObject.tag == "GeneratedRoom")
        {
            Destroy(other.gameObject);
        }
        
    }
}
