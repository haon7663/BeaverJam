using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Slider[] slider;
    [SerializeField] private TMP_Text[] tmpTextMasterSliderValue;

    [SerializeField] private Toggle toggle;

    private SoundManager _soundManager;

    private void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();

        slider[0].onValueChanged.AddListener(value => _soundManager.AudioControl("Master", slider[0]));
        slider[1].onValueChanged.AddListener(value => _soundManager.AudioControl("BGM", slider[1]));
        slider[2].onValueChanged.AddListener(value => _soundManager.AudioControl("SFX", slider[2]));

        toggle.onValueChanged.AddListener(value => _soundManager.ToggleAudioVolume());

        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void Update()
    {
        for (var i = 0; i < slider.Length; i++)
        {
            tmpTextMasterSliderValue[i].text = ((int)(slider[i].value * 2.5f + 100)).ToString();
        }
    }

    public void UIInitializing()
    {
        
        toggle.isOn = SaveManager.Inst.saveData.playSoundToggle;
        AudioListener.volume = SaveManager.Inst.saveData.playSoundToggle ? 0 : 1;
        for (var i = 0; i < slider.Length; i++)
        {
            slider[i].value = SaveManager.Inst.saveData.volume[i];
        }
    }

    private void PlayerSettingSave()
    {
        for (var i = 0; i < slider.Length; i++)
        {
            SaveManager.Inst.saveData.volume[i] = slider[i].value;
        }
        SaveManager.Inst.saveData.playSoundToggle = toggle.isOn;
        SaveManager.Inst.Save();
    }

    private void OnSceneUnloaded(Scene current)
    {
        PlayerSettingSave();
    }

    private void OnApplicationQuit()
    {
        PlayerSettingSave();
    }
}