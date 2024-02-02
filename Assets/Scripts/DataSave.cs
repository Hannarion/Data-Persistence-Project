using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;


public class DataSave : MonoBehaviour
{
    public static DataSave Instance;
    public TextMeshProUGUI playerScore;
    public string playerName;
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
        public TextMeshProUGUI playerScore;
        public int bestScore;
    }

    public void SaveScoreText()
    {
        playerScore.text = "Best Score: " + playerName + ": " + bestScore;
        SaveData data = new SaveData();
        data.playerScore = playerScore;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreText()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        playerScore = data.playerScore;
        bestScore = data.bestScore;
    }
    }

}
