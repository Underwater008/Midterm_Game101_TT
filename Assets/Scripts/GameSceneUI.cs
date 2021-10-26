using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    public GameObject settingPanel;
    private bool isSettingPanelOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingPanel.SetActive(!isSettingPanelOpen);
            isSettingPanelOpen = !isSettingPanelOpen;
            if (isSettingPanelOpen == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(!isSettingPanelOpen);
        isSettingPanelOpen = !isSettingPanelOpen;
        Time.timeScale = 1;
    }

    public void LoadToMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
