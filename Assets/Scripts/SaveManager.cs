using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LDtkUnity;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public PlayerData saveData;
    private static SaveManager inst = null;
    public bool onStartedPosition = false;
    private readonly string _key = "aes256=32CharA49AScdg5135=48Fk63";

    [Serializable]
    public class PlayerData
    {
        public float[] volume = { -20, -20, -20 };
        public bool playSoundToggle = false;
        public Vector3 SavePoint;
        //엘레맨탈포스 3 회복 하고 
        public int elemental = 1;
        public int elementalEnergy = 0;
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
      
        SceneManager.sceneLoaded += DefaultPlayerPos;
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

        var Encrypt = AES256Encrypt.Encrypt256(jsonData, _key);
        File.WriteAllText(Path.Combine(Application.persistentDataPath, "save.json"), Encrypt);
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
        var Decrypt256 = AES256Encrypt.Decrypt256(jsonData, _key);
        saveData = JsonUtility.FromJson<PlayerData>(Decrypt256);
    }

    
    private void DefaultPlayerPos(Scene scene, LoadSceneMode arg1)
    {
        print(saveData.SavePoint);
        if(scene.name != "InGameScene")
            return;
        onStartedPosition = false;
        print("ok");
        if (saveData.SavePoint == Vector3.zero)
        {
            
            print("ok2");
            var move = FindAnyObjectByType<Movement>();
            if (move)
            {
                print(move.transform.localPosition);
                var pos = /*GameObject.Find("Level_0").transform.position +*/ GameObject.Find("PlayerStart_3825af20-3b70-11ee-9dec-e59485d85d93").transform.position;
                move.transform.position = /*new Vector3(pos.x,pos.y +1 ,pos.z);*/pos;
                print(pos);
                onStartedPosition = true;
                print(GameObject.Find("PlayerStart_3825af20-3b70-11ee-9dec-e59485d85d93").gameObject);
                move.transform.position = GameObject.Find("PlayerStart_3825af20-3b70-11ee-9dec-e59485d85d93").gameObject.transform.position;
                print(move.transform.position);
            }
               
        }
    }
    public void Delete()
    {
        saveData = new PlayerData();
    }

    public void SavePlayerInfo(Vector3 position)
    {
        saveData.SavePoint = position;
        ElementManager.Inst.ChargeEnergy(3);
        UIManager.Inst.ChangeElement();
        saveData.elementalEnergy = ElementManager.Inst.elementalEnergy;
        saveData.elemental = (int)ElementManager.Inst.element;
    }

    public void InitPlayerInfo()
    {
        var Player = FindObjectOfType<Movement>().gameObject;
        Player.transform.position = saveData.SavePoint;
        ElementManager.Inst.SetElement(saveData.elemental);
        ElementManager.Inst.elementalEnergy = saveData.elementalEnergy;
        Elemental.saveElement = saveData.elemental;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}