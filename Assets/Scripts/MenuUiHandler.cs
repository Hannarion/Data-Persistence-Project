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
    public TextMeshProUGUI playerScore;
    public string playerName;
    public TextMeshProUGUI nameText;
   
   void start()
   {
        DataSave.Instance.LoadScoreText();
        playerScore = DataSave.Instance.playerScore;
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
