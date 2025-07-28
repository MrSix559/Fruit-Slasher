using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnRestart;
    public static event Action OnGameOver;

    [Header("Out scripts")]
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private MissController _missController;

    [SerializeField] private GameObject _panelMenu;
    [SerializeField] private GameObject _cursorTrail;

    [Header("Game Over")]
    [SerializeField] private GameObject _panelGameOver;

    private void OnEnable()
    {
        MenuManager.OnStart += StartGame;
    }

    private void OnDisable()
    {
        MenuManager.OnStart -= StartGame;
    }

    private void StartGame()
    {
        _cursorTrail.SetActive(true);
        _panelMenu.SetActive(false);
    }
    public void GameOver()
    {
        OnGameOver?.Invoke();
        _panelGameOver.SetActive(true);
        _cursorTrail.SetActive(false);
    }

    public void ReturnInMenu() => SceneManager.LoadScene(0);

    public void RestartGame()
    {
        OnRestart?.Invoke();
        _panelGameOver.SetActive(false);
        _scoreManager.ResetScore();
        _missController.ResetMissFruit();
        _cursorTrail.SetActive(true);
    }
}
