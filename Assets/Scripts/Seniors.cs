using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Seniors : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject finishPanel;
    public GameObject successPanel;
    public AudioSource BGM;

    public DoorCenterController doorCenterController;
    private void Start()
    {
        dialogPanel.SetActive(false);
        finishPanel.SetActive(false);
        dialogPanel.gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && KeyCollision.isFinish == false)
        {
            dialogPanel.gameObject.transform.parent.gameObject.SetActive(true);
            dialogPanel.SetActive(true);
            if(!BGM.isPlaying)
            {
                BGM.Play();
            }
        }
        else if (collision.CompareTag("Player") && KeyCollision.isFinish == true)
        {
            dialogPanel.gameObject.transform.parent.gameObject.SetActive(true);
            finishPanel.SetActive(true);
            successPanel.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // open the right door
            GameManager.GameGanagerInstance.OpenDoor(GameManager.GameGanagerInstance.doorRight);
            dialogPanel.SetActive(false);
            finishPanel.SetActive(false);
            successPanel.SetActive(false);
            dialogPanel.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
