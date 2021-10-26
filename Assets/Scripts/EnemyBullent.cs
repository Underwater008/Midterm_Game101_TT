using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullent : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bullent;

    public float shootDuration;

    public Transform playerTransform;



    private float lastTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < lastTime + shootDuration) return;

        lastTime = Time.time;
        GameObject tmp_bullent = Instantiate(bullent, muzzle.transform.position, Quaternion.identity);
        //tmp_bullent.transform.right = playerTransform.position - tmp_bullent.transform.position;
        //tmp_bullent.transform.right = transform.right;
        tmp_bullent.transform.up = playerTransform.position - tmp_bullent.transform.position;
    }
}
