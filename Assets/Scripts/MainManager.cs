using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public string playerName;
    public int currentScore;

    public int highScore;
    public string highScoreName;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    public class SaveData
    { 
        public int highScore;
        public string highScoreName;

    }
    public void SaveHighScore(int currentScore, string playerName)
    {
        //First, create a new instance of the save data 
        SaveData data = new SaveData();

        //Then specify what you want to store
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //Next, transform that instance to JSON with JsonUtility.ToJson: 
        string json = JsonUtility.ToJson(data);

        //Finally, use the special method File.WriteAllText to write a string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }
    public void StorePlayerName(string input)
    {
        playerName = input;
        Debug.Log(playerName);
    }
}
