using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject settingUI;

    private bool _isActive = false;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        _isActive = !_isActive;
        settingUI.SetActive(_isActive);
          
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("Scenes/MainScene");
    }

    public void OnClickExit()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void a()
    {
    }

    public void a2()
    {
    }
}