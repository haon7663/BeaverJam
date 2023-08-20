using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public void OnClickContinue()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scenes/InGameScene");
    }
}
