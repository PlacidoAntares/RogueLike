using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    public GameObject g_Plane;
    private GameObject planeChild;
    private GameObject roomObj;
    //1:need bottom door
    //2:need top door
    //3:need left door
    //4:need right door
    private RoomTemplates templates;
    private int rand;
    private bool spawnedRoom = false;
    public float waitTime = 4.0f;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnRooms",0.1f);
        Destroy(this.gameObject,waitTime);
    }

    void Update()
    {
           
    }

    void SpawnRooms()
    {
        if (spawnedRoom == false)
        {
            switch (openingDirection)
            {
                case 1:
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2:
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                    break;
            }
           
        }
        spawnedRoom = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawnedRoom == false && spawnedRoom == false)
            {
                //spawn walls to block off openings
                Instantiate(templates.ClosedRoom,transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
