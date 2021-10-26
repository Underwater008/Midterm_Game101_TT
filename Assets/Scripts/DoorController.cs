using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public bool open;
    public Vector3 originalPosition;
    private void Start()
    {
        door = gameObject;
        originalPosition = transform.position;
    }
    private void Update()
    {
        float sizeY = door.GetComponent<BoxCollider2D>().bounds.size.y;
        float sizeX = door.GetComponent<BoxCollider2D>().bounds.size.x;
        float move = sizeY>sizeX? sizeY : sizeX;
        if (open && originalPosition == transform.position )
        {
            door.transform.Translate(Vector2.right * move, Space.Self);
        }
        else if(!open && originalPosition != transform.position)
        {
            door.transform.Translate(Vector2.right * -move, Space.Self);
        }
    }
   
     
   
}
