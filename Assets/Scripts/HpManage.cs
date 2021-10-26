using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManage : MonoBehaviour
{
    public Slider slider;
    [HideInInspector]
    public bool isAlive = true;

    public float maxHp = 100f;
    private float hp;
    public CharacterHurtController chc;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        slider.value = hp / maxHp;
        if (GameManager.GameGanagerInstance.enemyRightNums == 0)
        {
            GameManager.GameGanagerInstance.OpenDoor(GameManager.GameGanagerInstance.doorTop);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attacked(float value)
    {
        hp -= value;
        CharacterHurtController cc;
        TryGetComponent<CharacterHurtController>(out cc);
        cc.DoAttackWithAnimation((int)value);
   
        slider.value = hp / maxHp;
        if(hp <= 0)
        {
            isAlive = false;
            GameManager.GameGanagerInstance.enemyRightNums--;
            if (GameManager.GameGanagerInstance.enemyRightNums == 0) {
                GameManager.GameGanagerInstance.OpenDoor(GameManager.GameGanagerInstance.doorTop);
            }
            Destroy(gameObject);
        }
    }
}
