using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;


public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public string playerName;
    public GameObject inputField;
    public int maxPoints;
    public string bestPlayerName;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void UpdatePlayerName()
    {
        playerName = inputField.GetComponent<TMP_InputField>().text;
        Debug.Log(playerName);
    }
    class SavedData
    {
        public int maxPoints;
        public string bestPlayerName;
    }
    public void SaveData()
    {
        SavedData data = new SavedData();
        data.maxPoints = maxPoints;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);

            maxPoints = data.maxPoints;
            bestPlayerName = data.bestPlayerName;
        }

    }
}
