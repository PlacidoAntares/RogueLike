using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRooms : MonoBehaviour
{
    public int RoomCount;
    private RoomTemplates templates;
    private int rand;
    //1:need bottom door
    //2:need top door
    //3:need left door
    //4:need right door
    
    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
       
    }

    private void Update()
    {
        SpawnBoss();       
    }

    void SpawnBoss()
    {
        //boss will only spawn when the room counter is equal or greater than RoomCount.
        if(templates.roomCounter >= RoomCount && templates.spawnedBoss == false)
        {
            Instantiate(templates.boss,templates.rooms[templates.rooms.Count - 1].transform.position + new Vector3(0.0f, 15.0f, 0.0f),Quaternion.identity);
            templates.spawnedBoss = true;
        }    
        
    }
    
       
    


    public void SpawnRoom(Vector3 roomPos,int roomType)
    {
        switch (roomType)
        {
            case 0:
                Instantiate(templates.ClosedRoom, roomPos, Quaternion.identity);
                break;
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
        } 
    }
    public void SpawnRoom(Vector3 roomPos,bool spawnedRoom,int roomType)
    {

    }

}