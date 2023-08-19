using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void OnClickContinue()
    {
        SceneManager.LoadScene("Scenes/InGameScene");
    }
    
    public void OnClickStartFresh()
    {
        SaveManager.Inst.Delete();
        SceneManager.LoadScene("Scenes/InGameScene");
    }
    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
