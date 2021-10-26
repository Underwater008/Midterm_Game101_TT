using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCenterController : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorController doorRight;
    public DoorController doorTop;
    public DoorController doorBottom;

    public void OpenDoor(DoorController door) 
    {
        door.open = true;
    }
    public void CloseDoor(DoorController door) {
        door.open = false;
    }
  
}
