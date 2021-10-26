using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterHurtController : MonoBehaviour
{
    private Queue<int> damageQueue;
    public float damageAnimationDuartion = 0.3f;
    public GameObject damageText;

    public float lastTime = 0;
    public int totalDamage = 0;
    public float damageDuration = 0f;
    // Start is called before the first frame update
    void Start()
    {
        damageQueue = new Queue<int>();
        lastTime = Time.time;
        StartCoroutine(DamageAnimationCoroutine());
        
    }
    public void DoAttackWithAnimation(int value)  
    {
        totalDamage += value; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DamageAnimationCoroutine()
    {
        while (true)
        {
            if (Time.time > lastTime + damageDuration && totalDamage > 0)
            {
                Debug.Log(totalDamage);
                
                damageQueue.Enqueue(totalDamage);
                totalDamage = 0;
                lastTime = Time.time;
            }
            if (damageQueue.Count != 0)
            {
               
                int damage = damageQueue.Dequeue();
                //if (Time.time > lastTime + damageDuration) {  
                GameObject tmp_damageText = Instantiate(damageText, damageText.transform.position, Quaternion.identity);
                tmp_damageText.SetActive(true);
                tmp_damageText.GetComponent<Text>().text = -damage + "";
                tmp_damageText.transform.SetParent(damageText.transform.parent);
                tmp_damageText.transform.localPosition = damageText.transform.localPosition;
                tmp_damageText.transform.localScale = damageText.transform.localScale;
                Destroy(tmp_damageText, 2f);

                //}
                //else
                //{
                //    totalDamage += damage;
                //}

            }

            yield return new WaitForSeconds(damageAnimationDuartion);
        }

    }
}
