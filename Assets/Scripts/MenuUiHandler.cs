using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuUiHandler : MonoBehaviour
{
    public Text playerScore;
    public string playerName;
    public string nameText;
   
   void Start()
   {
        DataSave.Instance.LoadScoreText();
        Debug.Log("fichié en chargement");
        playerScore.text = "Best Score: " + DataSave.Instance.bestName + ": " + DataSave.Instance.bestScore;
   }

    public void ReadStringInput(string s)
    {
        playerName = s;
    }

    public void StartNew()
    {
        DataSave.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }







}
