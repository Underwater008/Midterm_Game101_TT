using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SmallBossCortol : MonoBehaviour
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
            Invoke("EnemyOpen", 0.5f);
            GetComponent<Collider2D>().enabled = false;
        }
    }
    public void EnemyOpen()
    {
        GameObject.Find("Rogue_03").GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Rogue_03").GetComponent<EnemyBullent>().enabled = true;
        GameObject.Find("Rogue_04").GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Rogue_06").GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Rogue_04 (2)").GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Rogue_04 (1)").GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Rogue_06 (1)").GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Rogue_03 (1)").GetComponent<AIPath>().maxSpeed = 4;
        GameObject.Find("Rogue_04").GetComponent<EnemyBullent>().enabled = true;
        GameObject.Find("Rogue_06").GetComponent<EnemyBullent>().enabled = true;
        GameObject.Find("Rogue_04 (2)").GetComponent<EnemyBullent>().enabled = true;
        GameObject.Find("Rogue_04 (1)").GetComponent<EnemyBullent>().enabled = true;
        GameObject.Find("Rogue_06 (1)").GetComponent<EnemyBullent>().enabled = true;
        GameObject.Find("Rogue_03 (1)").GetComponent<EnemyBullent>().enabled = true;
    }

}
