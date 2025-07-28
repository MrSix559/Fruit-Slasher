using UnityEngine;

public class MissController : MonoBehaviour
{
    [Header("Out scripts")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private FruitMissUI _fruitMissUI;

    private int _missFruit;

    private void OnEnable()
    {
        MissTrigger.OnFruitMiss += MissFruit;
    }

    private void OnDisable()
    {
        MissTrigger.OnFruitMiss -= MissFruit;
    }

    private void MissFruit()
    {
        _missFruit++;
        _fruitMissUI.UpdateFruitMissText(_missFruit);
        if (_missFruit >= 3)
            _gameManager.GameOver();
    }

    public void ResetMissFruit()
    {
        _missFruit = 0;
        _fruitMissUI.UpdateFruitMissText(_missFruit);
    }

}
