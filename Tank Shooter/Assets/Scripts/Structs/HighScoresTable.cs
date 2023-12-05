using System;

namespace TankGame.Structs
{
    [Serializable]
    public struct HighScoresTable
    {
        public int highScore1;
        public int highScore2;
        public int highScore3;

        public HighScoresTable(int highScore1, int highScore2, int highScore3)
        {
            this.highScore1 = highScore1;

            this.highScore2 = highScore2;

            this.highScore3 = highScore3;
        }
    }
}