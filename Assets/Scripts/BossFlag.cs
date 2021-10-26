using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BossFlag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // open the right door
            GameObject.Find("Boss").GetComponent<AIPath>().maxSpeed = 4;
            GameObject.Find("Boss").GetComponent<BossDoAttack>().attack = true;
        }
    }
}
