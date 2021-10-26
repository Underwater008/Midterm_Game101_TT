using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullent : MonoBehaviour
{
    public int speed;
    public float rotatePerSecond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime,Space.Self);
        transform.localEulerAngles += new Vector3(0,0, rotatePerSecond * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            HpManage hp;
            if (other.gameObject.TryGetComponent<HpManage>(out hp))
            {
                Debug.Log("ss");
                hp.Attacked(10f);
            }
            Destroy(gameObject);
        }
    }
}
