using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    private int m_Score;
    private int m_HighScore;
    public int HighScore { get; }
    public int Score
    {
        get
        {
            return m_Score;
        }
        set
        {
            m_Score = value;
            if (m_Score > m_HighScore) m_HighScore = m_Score;
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
        LoadHighScore();
    }
    public class SaveData
    {
        public int Score;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.Score = m_HighScore;
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", JsonUtility.ToJson(data));
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if(File.Exists(path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            m_HighScore = data.Score;
        }
    }
    private void OnApplicationQuit()
    {
        SaveHighScore();
    }
}
