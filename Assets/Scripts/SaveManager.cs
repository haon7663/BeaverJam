using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LDtkUnity;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public PlayerData saveData;
    private static SaveManager inst = null;
    
    [Serializable]
    public class PlayerData
    {
        public int level = 0;
        public int elemental = 0;
    }

    private void Awake()
    {
        if (null == inst)
        {
            inst = this; 
            DontDestroyOnLoad(inst);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Load();
    }
    
    public static SaveManager Inst
    {
        get
        {
            if (null == inst)
            {
                return null;
            }
            return inst;
        }
    }

    public void Save()
    {
        // saveData 변수를 json 형식으로 변환한다
        var jsonData = JsonUtility.ToJson(saveData, true);
        // jsonData를 save.json에 저장한다
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "save.json"), jsonData);
    }

    public void Load()
    {
        // save.json이 존재하지않는가?
        if (!File.Exists(Path.Combine(Application.persistentDataPath, "save.json")))
        {
            // saveData 변수를 새로 작성
            saveData = new PlayerData();
            // Load 메서드 종료
            return;
            
        }

        // 파일이 존재하면 save.json을 불러온다
        var jsonData = File.ReadAllText(Path.Combine(Application.persistentDataPath, "save.json"));
        // saveData 변수에 덮어씌운다
        saveData = JsonUtility.FromJson<PlayerData>(jsonData);
    }

    public void Delete()
    {
        File.Delete(Path.Combine(Application.persistentDataPath, "save.json"));
    }
}