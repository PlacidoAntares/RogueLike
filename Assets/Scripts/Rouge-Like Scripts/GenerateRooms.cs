using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRooms : MonoBehaviour
{
    public int MaxRoomCount;
    private RoomTemplates templates;
    private int rand;
    //1:need bottom door
    //2:need top door
    //3:need left door
    //4:need right door
    public List<RoomInfo> roomProp = new List<RoomInfo>();
    public List<GameObject> Rooms = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("InitialRooms", 0.1f);
    }

    private void Update()
    {
        SpawnBoss();
       
        
    }

    void SpawnBoss()
    {
        //simple boss spawn code. Boss should spawn at the last room instantiated.
        if (templates.waitTime <= 0 && templates.spawnedBoss == false)
        {
            for (int i = 0; i < templates.rooms.Count; i++)
            {
                if (i == templates.rooms.Count - 1)
                {
                    Instantiate(templates.boss, templates.rooms[i].transform.position + new Vector3(0.0f, 2f, 0.0f), Quaternion.identity);
                    templates.spawnedBoss = true;
                }
            }
        }
        else if (templates.spawnedBoss == false)
        {
            templates.waitTime -= Time.deltaTime;
        }
    }
    void InitialRooms()
    {
       for (int i = 0; i < Rooms.Count; i++)
        {
            if (roomProp[i].RoomType == 1)
            {
                rand = Random.Range(0, templates.doubleEntryRoomsBottom.Length);
                Instantiate(templates.doubleEntryRoomsBottom[rand],Rooms[i].transform.position, Quaternion.identity);
            }
            if (roomProp[i].RoomType == 2)
            {
                rand = Random.Range(0, templates.doubleEntryRoomsTop.Length);
                Instantiate(templates.doubleEntryRoomsTop[rand], Rooms[i].transform.position, Quaternion.identity);
            }
            if (roomProp[i].RoomType == 3)
            {
                rand = Random.Range(0, templates.doubleEntryRoomsLeft.Length);
                Instantiate(templates.doubleEntryRoomsLeft[rand], Rooms[i].transform.position, Quaternion.identity);
            }
            if (roomProp[i].RoomType == 4)
            {
                rand = Random.Range(0, templates.doubleEntryRoomsRight.Length);
                Instantiate(templates.doubleEntryRoomsRight[rand], Rooms[i].transform.position, Quaternion.identity);
            }
        }

       
    }


    public void SpawnRoom(Vector3 roomPos,int roomType)
    {
        switch (roomType)
        {
            case 1:
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], roomPos, Quaternion.identity);
                break;
            case 2:
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], roomPos, Quaternion.identity);
                break;
            case 3:
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], roomPos, Quaternion.identity);
                break;
            case 4:
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], roomPos, Quaternion.identity);
                break;
            case 0:
                Instantiate(templates.ClosedRoom, roomPos, Quaternion.identity);
                break;
        }
    }
    public void SpawnRoom(Vector3 roomPos,bool spawnedRoom,int roomType)
    {
        if (spawnedRoom == false)
        {
            switch (roomType)
            {
                case 1:
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], roomPos, Quaternion.identity);
                    break;
                case 2:
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], roomPos, Quaternion.identity);
                    break;
                case 3:
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand],roomPos, Quaternion.identity);
                    break;
                case 4:
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], roomPos, Quaternion.identity);
                    break;
                case 0:
                    Instantiate(templates.ClosedRoom,roomPos, Quaternion.identity);
                    break;
            }

        }

    }

}