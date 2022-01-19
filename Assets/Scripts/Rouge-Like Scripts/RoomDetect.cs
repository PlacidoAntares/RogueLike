 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetect : MonoBehaviour
{
    public Vector3 RayStartPos; //where the ray will start
    public Vector3[] RayDir; //direction of the ray
    public Vector3[] RayOffset; //offsets the ray to avoid it colliding with the orgin
    public Vector3[] DirRay;
    public float RayMag; //how far the ray will go
    public bool[] ActiveRays; //toggle which rays are on.
    //top = 0
    //bottom = 1
    //left = 2
    //right = 3

    public int RayID;
    // Start is called before the first frame update
    void Start()
    {
        RayStartPos = transform.position;
        CastRay();
    }

    // Update is called once per frame
    void Update()
    {
        DrawRay();
    }

    void CastRay()
    {
        if (Physics.Raycast(RayStartPos + RayOffset[0],RayDir[0],RayMag) && ActiveRays[0] == true)
        {
            

        }
    }


    void DrawRay()
    {
        if (ActiveRays[0] == true)
        {
            DirRay[0] = transform.TransformDirection(RayDir[0]) * RayMag;
            Debug.DrawRay(RayStartPos + RayOffset[0], DirRay[0], Color.green);
        }
       if (ActiveRays[1] == true)
        {
            DirRay[1] = transform.TransformDirection(RayDir[1]) * RayMag;
            Debug.DrawRay(RayStartPos + RayOffset[1], DirRay[1], Color.green);
        }
       if (ActiveRays[2] == true)
        {
            DirRay[2] = transform.TransformDirection(RayDir[2]) * RayMag;
            Debug.DrawRay(RayStartPos + RayOffset[2], DirRay[2], Color.green);
        }
        //
        if (ActiveRays[3] == true)
        {
            DirRay[3] = transform.TransformDirection(RayDir[3]) * RayMag;
            Debug.DrawRay(RayStartPos + RayOffset[3], DirRay[3], Color.green);
        }
        //
       
    }
}
