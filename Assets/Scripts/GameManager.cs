using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyRightNums;
    public DoorController doorRight;
    public DoorController doorTop;
    public DoorController doorBottom;
    // Start is called before the first frame update
    public static GameManager GameGanagerInstance { get; private set; }
    private void Awake()
    {
        if (GameGanagerInstance != null) {
            Destroy(gameObject);
        }
        GameGanagerInstance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Boss")) {
            OpenDoor(doorBottom);
        }

    }

    public void OpenDoor(DoorController door)
    {
        door.open = true;
    }
    public void CloseDoor(DoorController door)
    {
        door.open = false;
    }

}
