using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenManEnterPanel : MonoBehaviour
{
    public GameObject EnterPanel;
    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        DowmPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!flag)
        {
            flag = true;
            EnterPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void DowmPanel()
    {
        EnterPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
