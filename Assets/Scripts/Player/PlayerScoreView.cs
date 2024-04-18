using TMPro;
using UnityEngine;

public class PlayerScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private PlayerScore _score;
    private const string _prefix = "Score: ";

    private void Awake()
    {
        _scoreText.text = _prefix + _score.CurrentScore;
        _score.ScoreUpdated += UpdateText;
    }

    private void UpdateText(uint score)
    {
        _scoreText.text = _prefix + score;
    }

    private void OnDestroy()
    {
        _score.ScoreUpdated -= UpdateText;
    }
}
