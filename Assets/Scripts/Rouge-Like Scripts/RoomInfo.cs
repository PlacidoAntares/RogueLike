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

    void Start()
    {
        roomSpawner = this.gameObject;
        RoomTemp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        GenRooms = GameObject.FindGameObjectWithTag("R_Gen").GetComponent<GenerateRooms>();
        GenRooms.Rooms.Add(this.gameObject);
        GenRooms.roomProp.Add(roomSpawner.GetComponent<RoomInfo>());
        if (GenRooms.Rooms.Count < GenRooms.MaxRoomCount)
        {
            Invoke("InvokeSpawnRoom", 0.5f);
        }
        else if (GenRooms.Rooms.Count >= GenRooms.MaxRoomCount)
        {
            Invoke("CloseRoom", 0.5f);
        }


    }

   
    private void InvokeSpawnRoom()
    {
        GenRooms.SpawnRoom(roomSpawner.transform.position, roomSpawned, RoomType);
    }
    private void CloseRoom()
    {      
        GenRooms.SpawnRoom(roomSpawner.transform.position, roomSpawned, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnPoint" || other.gameObject.tag == "GeneratedRoom")
        {
            roomSpawned = true;
            this.gameObject.SetActive(false);
            Debug.Log("SpawnerDisabled");
        }

    }

}
