using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Color ForkliftColor;
    private string saveFileName = "/savefile.json";


    public void SaveColor()
    {
        SaveData color = new SaveData();
        color.TeamColor = ForkliftColor;

        string json = JsonUtility.ToJson(color);
        File.WriteAllText(Application.persistentDataPath + saveFileName, json);
    }

    public void LoadColor()
    {
        string pathToSaveFile = Application.persistentDataPath + saveFileName;
        if (File.Exists(pathToSaveFile))
        {
            string data = File.ReadAllText(pathToSaveFile);
            Debug.Log(data);
            Debug.Log(pathToSaveFile);
            SaveData savedata = JsonUtility.FromJson<SaveData>(data);
            ForkliftColor = savedata.TeamColor;

        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this; 
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

}
