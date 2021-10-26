using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed;
    public GameObject GameOverPanel;

    public GameObject weapon;
    public GameObject playerSprite;
    float horzitontal;
    float horizontalDir;
    float vertical;

    public int CurrentHealth = 500;
    public int CurrentDefence = 5;
    private int Updateflag = 5;
    public int CurrentEnergy = 360;

    private int currentSkillPoint = 0;
    private const int maxSkillPoint = 400;
    [Header("Skill")]
    public Image flashSlider;
    public bool isSkill = false;
    
    private Queue<int> damageQueue;
    private float damageAnimationDuartion = 0.3f;
    public GameObject damageText;

    public float lastTime =0;
    public int totalDamage = 0;
    public float damageDuration = 1f;

    private float relaxTime;
    public float realxDuration;
    private float lastRelaxTime;

    public WoodenMan woodenMan;
    public Transform relivePosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdateCurrentDefence", 1f, 1f);
        //damageQueue = new Queue<int>();
        //StartCoroutine(DamageAnimationCoroutine());
        //lastTime = Time.time;
        relaxTime = Time.time;
        GameOverPanel.SetActive(false);
    }
    private void Update()
    {
        // 瞄准
        Aiming();
        // 移动
        Movement();
        //技能
        RefreshSkillUI();
        if (Time.time > lastRelaxTime + realxDuration) 
        {
            Updateflag = 5;
        }
    }
    private void UpdateCurrentDefence()
    {
        if(CurrentDefence<20)
        {
            CurrentDefence += Updateflag;
            CurrentDefence = CurrentDefence < 20 ? CurrentDefence : 20;
        }

    }
    private void Movement()
    {
        horzitontal = Input.GetAxis("Horizontal");
        horizontalDir = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontalDir > 0)
        {
            playerSprite.transform.localScale = new Vector3(1, 1, 1);

        }
        else if (horizontalDir < 0)
        {
            playerSprite.transform.localScale = new Vector3(-1, 1, 1);
        }
        rigidbody.velocity = new Vector3(horzitontal, vertical, 0) * speed;

    }
    // 瞄准
    private void Aiming()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Vector2 dir = weapon.transform.position - mousePosition ;
        Vector2 dir = mousePosition - weapon.transform.position;
        weapon.transform.right = dir;
        //float rotationAngle = Vector2.Angle(dir,Vector3.left);

        //if (mousePosition.y < weapon.transform.position.y)
        //{
        //    rotationAngle = -rotationAngle;
        //}
        //weapon.transform.eulerAngles = new Vector3(0, 0, rotationAngle);

    }

    public void RefreshSkillUI()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetMouseButtonDown(1) && flashSlider.fillAmount == 1)
            {
                isSkill = true;
            }

            if (isSkill == false && currentSkillPoint < maxSkillPoint)
            {
                currentSkillPoint++;
            }
            else if (isSkill == true)
            {
                currentSkillPoint -= 3;
                if (currentSkillPoint <= 0)
                {
                    isSkill = false;
                }
            }
            flashSlider.fillAmount = (float)currentSkillPoint / maxSkillPoint;
        }
    }

    public void Attacked(int value)
    {
       
        lastRelaxTime = Time.time;
        Updateflag = 1;
        if (CurrentDefence>=value)
        {
            CurrentDefence -= value;
        }
        else
        {
            CurrentHealth = CurrentHealth - value + CurrentDefence;
            CurrentDefence = 0;
        }
        GetComponent<CharacterHurtController>().DoAttackWithAnimation(value);
        //Debug.Log(Time.time);
        //totalDamage += value;
        //if (Time.time > lastTime + damageDuration)
        //{
        //    Debug.Log(totalDamage);
        //    damageQueue.Enqueue(totalDamage);
        //    totalDamage = 0;
        //    lastTime = Time.time;
        //}
        if (CurrentHealth <= 0)
        {
            if (woodenMan.Playerflag) {
                transform.position = relivePosition.position;
                CurrentHealth = 500;

                return;
            }
            GameOverPanel.SetActive(true);
            //Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    IEnumerator DamageAnimationCoroutine()
    {
        while (true) {

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
