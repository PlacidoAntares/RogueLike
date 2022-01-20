using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    private RoomTemplates templates;
    public int RoomType;
    public bool roomSpawned;
    private GameObject roomSpawner;
    //1:need bottom door
    //2:need top door
    //3:need left door
    //4:need right door
    private GenerateRooms GenRooms;
    private RoomTemplates RoomTemp;

    void Awake()
    {
        roomSpawner = this.gameObject;
        RoomTemp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        GenRooms = GameObject.FindGameObjectWithTag("R_Gen").GetComponent<GenerateRooms>();
        //Debug.Log(GenRooms + " this is at void start");
        Invoke("InstantiateRoom", 0.1f);
             
    }

   void InstantiateRoom()
    {
        if (roomSpawned == false)
        {
            GenRooms.SpawnRoom(this.gameObject.transform.position, RoomType);
        }
       roomSpawned = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomInfo>().roomSpawned == false && roomSpawned == false && other.gameObject != null)
            {
                //Debug.Log(GenRooms);
                GenRooms.SpawnRoom(this.gameObject.transform.position,0);
                Destroy(gameObject);
            }
            roomSpawned = true;
        }
    }


}
