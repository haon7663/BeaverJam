using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Inst { get; private set; }

    [SerializeField] private CinemachineVirtualCamera cinevirtual;
    
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject SoundSettingUI;

    private bool _isActive = false;
    public float setTimeScale = 1;

    public float orthoSize;
    private float cineSize;
    private float realCineSize;

    private void Awake() => Inst = this;

    void Start()
    {
        cineSize = orthoSize;
        realCineSize = orthoSize;
        SoundSettingUI.GetComponent<SoundController>().UIInitializing();
    }

    private void Update()
    {
        realCineSize = Mathf.Lerp(realCineSize, cineSize, Time.deltaTime * 20);
        cinevirtual.m_Lens.OrthographicSize = realCineSize;

        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        _isActive = !_isActive;
        settingUI.SetActive(_isActive);

        Time.timeScale = Time.timeScale == 0 ? setTimeScale : 0;
        if (Time.timeScale != 0)
        {
            cineSize = Time.timeScale == 1 ? orthoSize : orthoSize * 0.8f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    public void SetTimeScale(float scale)
    {
        setTimeScale = scale;
        Time.timeScale = setTimeScale;
        if (Time.timeScale != 0)
        {
            cineSize = Time.timeScale == 1 ? orthoSize : orthoSize*0.8f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    public void OnClickMain()
    {
        Time.timeScale = 1;
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

    public void OnClickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickSoundSetting()
    {
        SoundSettingUI.SetActive(!SoundSettingUI.activeSelf);
    }
}