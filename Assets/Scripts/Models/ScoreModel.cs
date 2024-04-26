using System;

namespace MixarTest1.Models
{
    public class ScoreModel
    {
        public event Action UpdatedScore;

        public int Score { get; private set; }

        public void IncreaseScore()
        {
            Score++;
            UpdatedScore?.Invoke();
        }
    }
}