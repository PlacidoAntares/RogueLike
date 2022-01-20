using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject ClosedRoom;

    public GameObject[] doubleEntryRoomsLeft;
    public GameObject[] doubleEntryRoomsRight;
    public GameObject[] doubleEntryRoomsTop;
    public GameObject[] doubleEntryRoomsBottom;

    public List<GameObject> rooms;

    public float waitTime;
    public int roomCounter;
    public bool spawnedBoss;
    public GameObject boss;

    void Update()
    {
        
    }
}
