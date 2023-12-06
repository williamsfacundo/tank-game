using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using TankGame.DataPersistence;
using TankGame.Extension;
using TankGame.Tank.Score;
using TankGame.Structs;

namespace TankGame.EndGame 
{
    public class EndGameHighScoreManager : MonoBehaviour
    {
        private const string fileName = "/highScoresTable.dat";

        public event Action OnHighScoreChanged;
        
        private List<int> highScoresList;
        
        private HighScoresTable highScoresTableStruct;
        
        private string filePath;

        private bool newHighScoreAchieved;

        public int HighScore1 
        {
            get 
            {
                return highScoresTableStruct.highScore1;
            }
        }

        public int HighScore2
        {
            get
            {
                return highScoresTableStruct.highScore2;
            }
        }

        public int HighScore3
        {
            get
            {
                return highScoresTableStruct.highScore3;
            }
        }

        public bool NewHighScoreAchieved 
        {
            get
            {
                return newHighScoreAchieved;
            }
        }

        void Start()
        {
            filePath = Application.persistentDataPath + fileName;            

            highScoresTableStruct = GetHighScoreTableFromFile();

            highScoresList = new List<int>();

            highScoresList.Add(highScoresTableStruct.highScore1);
            highScoresList.Add(highScoresTableStruct.highScore2);
            highScoresList.Add(highScoresTableStruct.highScore3);

            newHighScoreAchieved = false;

            OnHighScoreChanged?.Invoke();

            TryToAddScoreInTable(TankScoreBehaviour.TankScore);
        }

        private HighScoresTable GetHighScoreTableFromFile() 
        {
            if (BinaryFilesManager.FileExists(filePath)) 
            {
                return (HighScoresTable)BinaryFilesManager.Load(filePath);
            }
            else 
            {
                HighScoresTable newHighScoresTable = new HighScoresTable(0,0,0);

                BinaryFilesManager.Save(newHighScoresTable, filePath);

                return newHighScoresTable;
            }
        }

        private void TryToAddScoreInTable(int score)
        {
            highScoresList.SortDescending();

            int minScore = highScoresList.Min();

            if (score > minScore)
            {                   
                highScoresList.Insert(highScoresList.Count - 1, score);

                highScoresList.SortDescending();

                highScoresTableStruct.highScore1 = highScoresList[0];
                highScoresTableStruct.highScore2 = highScoresList[1];
                highScoresTableStruct.highScore3 = highScoresList[2];

                BinaryFilesManager.Save(highScoresTableStruct, filePath);

                newHighScoreAchieved = true;

                OnHighScoreChanged?.Invoke();

                newHighScoreAchieved = false;
            }
        }
    }
}