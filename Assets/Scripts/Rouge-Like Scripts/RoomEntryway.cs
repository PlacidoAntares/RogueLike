using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntryway : MonoBehaviour
{
    public GameObject roomSpawner;
    private RoomTemplates roomTemplates;
    private GenerateRooms roomGen;
    private RoomInfo roomInfo;
    private Vector3 roomPos;
    private bool roomSpawned;
    // Start is called before the first frame update
    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        roomGen = GameObject.FindGameObjectWithTag("R_Gen").GetComponent<GenerateRooms>();
        roomInfo = roomSpawner.GetComponent<RoomInfo>();
        roomPos = roomSpawner.transform.position;
        roomSpawned = roomInfo.roomSpawned;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //spawn appropriate room
            //roomGen.SpawnRoom(roomPos,roomSpawned);
            roomInfo.roomSpawned = true;
        }
        
    }
}
