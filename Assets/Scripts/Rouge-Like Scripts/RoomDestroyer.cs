using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private GenerateRooms RoomGen;
    public GameObject[] roomSpawners;
    
    // Start is called before the first frame update
    void Start()
    {
        RoomGen = GameObject.FindGameObjectWithTag("R_Gen").GetComponent<GenerateRooms>();
       
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnPoint" || other.gameObject.tag == "GeneratedRoom")
        { 
            //Destroy(other.gameObject);
        }
        
    }
}
