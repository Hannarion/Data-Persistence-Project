using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;


public class DataSave : MonoBehaviour
{
    public static DataSave Instance;
    public string playerName;

    public string bestName;
    public int bestScore;
    
    private void Awake()
    {
        if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

[System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;
    }

    public void SaveScoreText()
    {

        SaveData data = new SaveData();
        data.bestName = bestName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Fichié enregistré");
    }

    public void LoadScoreText()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
    {
        Debug.Log("fichié existant");
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        bestName = data.bestName;
        bestScore = data.bestScore;
    }
    }

}
