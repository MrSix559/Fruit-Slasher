using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Current score")]
    [SerializeField] private TMP_Text _textScore;
    private int _score;

    [Header("Last score")]
    [SerializeField] private TMP_Text _lastScore;

    [Header("Best Score")]
    [SerializeField] private TMP_Text _bestScoreText;

    private void OnEnable()
    {
        Fruit.OnSlice += AddScoreAndUpdateScore;
        GameManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        Fruit.OnSlice -= AddScoreAndUpdateScore;
        GameManager.OnGameOver -= GameOver;
    }

    private void Start()
    {
        LoadBestScore();
    }

    private void AddScoreAndUpdateScore()
    {
        _score++;
        _textScore.text = $"Score: {_score}";
    }

    private void GameOver()
    {
        _lastScore.text = $"Last Score: {_score}";
        ChangeBestScore();
    }
    private void ChangeBestScore()
    {
        if(_score > EncryptedPlayerPrefs.GetEncryptedInt("BestScore"))
        {
            EncryptedPlayerPrefs.SetEncryptedInt("BestScore", _score);
        }
    }

    private void LoadBestScore()
    {
        _bestScoreText.text = $"Best Score: {EncryptedPlayerPrefs.GetEncryptedInt("BestScore")}";
    }

    public void ResetScore()
    {
        _score = 0;
        _textScore.text = $"Score: 0";
    }
}
