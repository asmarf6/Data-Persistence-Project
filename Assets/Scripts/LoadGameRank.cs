using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class LoadGameRank : MonoBehaviour
{
    public TextMeshProUGUI BestPlayerName;

    //static variables for holding player data
    private static int BestScore;
    private static string BestPlayer;

    private void Awake()
    {
        LoadGame();
    }

    private void SetBestPlayer()
    {
        if (BestPlayer == null && BestScore == 0)
        {
            BestPlayerName.text = "";
        }
        else
        {
            BestPlayerName.text = $"Best Score - {BestPlayer} : {BestScore}";
        }
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.TheBestPlayer;
            BestScore = data.HighestScore;
            SetBestPlayer();
            
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public int HighestScore;
        public string TheBestPlayer;
    }
}
