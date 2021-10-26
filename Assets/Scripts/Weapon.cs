using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour

{    // Start is called before the first frame update
    public Transform muzzle;
    public Transform muzzle1;
    public GameObject bullent;
    public float shootDuration;
    private float lastTime;

    public PlayerController player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& player.GetComponent<PlayerController>().CurrentEnergy>0)
        {
            if (Time.time < lastTime + shootDuration) return;
   
                lastTime = Time.time;
                GameObject tmp_bullent = Instantiate(bullent, muzzle.transform.position, Quaternion.identity);
                //tmp_bullent.transform.right = transform.right;
                tmp_bullent.transform.up = transform.right;
                player.GetComponent<PlayerController>().CurrentEnergy--;
        }
        if (player.isSkill)
        {
            if (Time.time < lastTime + shootDuration) return;

            lastTime = Time.time;
            GameObject tmp_bullent = Instantiate(bullent, muzzle.transform.position, Quaternion.identity);
            GameObject tmp_bullent1 = Instantiate(bullent, muzzle1.transform.position, Quaternion.identity);
            //tmp_bullent.transform.right = transform.right;
            tmp_bullent.transform.up = transform.right;
            tmp_bullent1.transform.up = transform.right;
        }
    }
}
