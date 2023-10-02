using System;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreOption[] scoreOptions;

    private List<ModelScore> modelScoreList;

    private static readonly string ScoreTablePref = "ScoreTablePref";

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(ScoreTablePref))
        {
            PopulateEmptyList();
        }

        string jsonString = PlayerPrefs.GetString(ScoreTablePref);
        NewScores bestScores = JsonUtility.FromJson<NewScores>(jsonString);

        for (int i = 0; i < bestScores.modelScoreList.Count; i++)
        {
            CreateEntries(bestScores.modelScoreList[i], scoreOptions[i]);
        }
    }

    private void PopulateEmptyList()
    {
        string now = DateTime.Now.ToBinary().ToString();

        modelScoreList = new List<ModelScore>()
        {
            new ModelScore{ scorePlayerR = 5, scorePlayerL = 4, playerWhoWon = "Thay", date = now },
            new ModelScore{ scorePlayerR = 4, scorePlayerL = 5, playerWhoWon = "Thay", date = now },
            new ModelScore{ scorePlayerR = 5, scorePlayerL = 3, playerWhoWon = "Thay", date = now },
            new ModelScore{ scorePlayerR = 3, scorePlayerL = 5, playerWhoWon = "Thay", date = now },
            new ModelScore{ scorePlayerR = 5, scorePlayerL = 2, playerWhoWon = "Thay", date = now }
        };
        NewScores bestScores = new NewScores { modelScoreList = modelScoreList };
        bestScores = OrdenateList(bestScores);
        string json = JsonUtility.ToJson(bestScores);
        PlayerPrefs.SetString(ScoreTablePref, json);
        PlayerPrefs.Save();
    }

    private NewScores OrdenateList(NewScores bestScores)
    {
        for (int i = 0; i < bestScores.modelScoreList.Count; i++)
        {
            for (int j = i + 1; j < bestScores.modelScoreList.Count; j++)
            {
                long temp1 = Convert.ToInt64(bestScores.modelScoreList[j].date);
                long temp2 = Convert.ToInt64(bestScores.modelScoreList[i].date);
                DateTime date1 = DateTime.FromBinary(temp1);
                DateTime date2 = DateTime.FromBinary(temp2);

                if (date1 > date2)
                {
                    ModelScore model = bestScores.modelScoreList[i];
                    bestScores.modelScoreList[i] = bestScores.modelScoreList[j];
                    bestScores.modelScoreList[j] = model;
                }
            }
        }

        if (bestScores.modelScoreList.Count > 5)
        {
            bestScores.modelScoreList.RemoveAt(5);
        }
        return bestScores;
    }

    private void CreateEntries(ModelScore modelScore, ScoreOption scoreOption)
    {
        scoreOption.playerRPoints.text = modelScore.scorePlayerR.ToString();
        scoreOption.playerLPoints.text = modelScore.scorePlayerL.ToString();
        scoreOption.playerWhoWon.text = modelScore.playerWhoWon;

        long temp = Convert.ToInt64(modelScore.date);
        scoreOption.date.text = DateTime.FromBinary(temp).ToString("dd-MM-yyyy");
    }

    public void AddEntrie(int scorePlayerR, int scorePlayerL, string name)
    {
        ModelScore modelScore = new ModelScore 
        { 
            scorePlayerR = scorePlayerR, 
            scorePlayerL = scorePlayerL,
            playerWhoWon = name,
            date = DateTime.Now.ToBinary().ToString(),
        };

        string jsonString = PlayerPrefs.GetString(ScoreTablePref);
        NewScores bestScores = JsonUtility.FromJson<NewScores>(jsonString);
        bestScores.modelScoreList.Add(modelScore);

        bestScores = OrdenateList(bestScores);

        string json = JsonUtility.ToJson(bestScores);
        PlayerPrefs.SetString(ScoreTablePref, json);
        PlayerPrefs.Save();
    }

    public void RestartScore()
    {
        PlayerPrefs.DeleteKey(ScoreTablePref);
        Awake();
    }

    private class NewScores
    {
        public List<ModelScore> modelScoreList;
    }

    [Serializable]
    private class ModelScore
    {
        public int scorePlayerR;
        public int scorePlayerL;
        public string playerWhoWon;
        public string date;
    }
}