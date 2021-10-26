using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoAttack : MonoBehaviour
{
    public GameObject darts;
    public Transform center;
    public int dartsNum = 5;
    public int radius = 10;
    public bool attack;

    public float duaration;

    private float lastTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attack && Time.time > lastTime + duaration)
        {
            DoAttack();
            lastTime = Time.time;
      
        }
    }

    public void Attack()
    {
        attack = true;
    }

    // boss Î§ÈÆ×ÔÉí·¢Éä·ÉïÚ
    public void DoAttack()
    {
        float angle = 360f / dartsNum;
        for(int i = 0; i < dartsNum; i++)
        {
            GameObject tmp_darts = Instantiate(darts);
            tmp_darts.SetActive(true);
            tmp_darts.transform.SetParent(transform,false);

            float x = radius * Mathf.Cos(angle * i * Mathf.PI / 180f);
            float y = radius * Mathf.Sin(angle * i * Mathf.PI / 180f);
            tmp_darts.transform.localPosition = center.localPosition+ new Vector3(x,y,0);
            tmp_darts.transform.localEulerAngles = new Vector3(0, 0, angle * i);
        }
    }
}
