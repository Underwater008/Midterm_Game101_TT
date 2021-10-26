using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenMan : MonoBehaviour
{
    public AudioSource playingAudio;
    public AudioSource movingAudio;
    public GameObject headA;
    public GameObject headB;

    public GameObject playerspeed;

    public bool isHeadTurning = false;
    private float duration;
    private float interval;
    private Coroutine coroutine;

    public bool Playerflag;

    void Start()
    {

    }
    void Update()
    {
        if(!Playerflag)
        {
            movingAudio.Stop();
            playingAudio.Stop();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerspeed.GetComponent<Rigidbody2D>().velocity != Vector2.zero && isHeadTurning && collision.CompareTag("Player"))
        {
            Playerflag = true;
            int s=playerspeed.GetComponent<PlayerController>().CurrentHealth/4;
            playerspeed.GetComponent<PlayerController>().Attacked(s+1);
        }
    }
    private void Head()
    {
        if (!isHeadTurning)
        {
            Debug.Log("面向 S");
            headB.SetActive(false);
            headA.SetActive(true);
        }
        else
        {
            Debug.Log("面向 N");
            headB.SetActive(true);
            headA.SetActive(false);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playerflag = true;

            coroutine = StartCoroutine(Timer());
            playerspeed.GetComponent<PlayerController>().speed = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movingAudio.Stop();
            playingAudio.Stop();
            playerspeed.GetComponent<PlayerController>().speed = 8;
            StopCoroutine(coroutine);
            Playerflag = false;

            //if (KeyCollision.isFinish == true)
            //{
            //    this.enabled = false;
            //    movingAudio.enabled = false;
            //    playingAudio.enabled = false;
            //}
        }
    }

    private void InvokeSetReady()
    {
        // 让玩家不能移动
        Debug.Log("playing ");
        isHeadTurning = true;
        Head();
        playingAudio.Stop();
        playingAudio.Play();

        movingAudio.Stop();
    }

    IEnumerator Timer()
    {
        while (true)
        {
            duration = Random.Range(1, 5);
            interval= Random.Range(duration, 6);
            movingAudio.Stop();
            playingAudio.Stop();
            movingAudio.Play();

            isHeadTurning = false;

            Invoke("InvokeSetReady", duration);
            Head();
            yield return new WaitForSeconds(duration+interval);
        }
    }
}

