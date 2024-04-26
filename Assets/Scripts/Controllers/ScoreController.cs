using System;
using MixarTest1.Models;
using TMPro;
using VContainer.Unity;

namespace MixarTest1.Controllers
{
    public class ScoreController : IInitializable, IDisposable
    {
        private readonly ScoreModel _scoreModel;
        private readonly TMP_Text _scoreText;

        public ScoreController(ScoreModel scoreModel, TMP_Text scoreText)
        {
            _scoreModel = scoreModel;
            _scoreText = scoreText;
        }

        public void Initialize()
        {
            _scoreModel.UpdatedScore += UpdateScoreText;
        }

        public void Dispose()
        {
            _scoreModel.UpdatedScore -= UpdateScoreText;
        }

        private void UpdateScoreText()
        {
            _scoreText.text = _scoreModel.Score.ToString();
        }
    }
}