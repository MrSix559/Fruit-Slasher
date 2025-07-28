using UnityEngine;
using TMPro;

public class FruitMissUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _fruitMissCountText;

    public void UpdateFruitMissText(int fruitLoseCount)
    {
        _fruitMissCountText.text = $"Fruit lose: {fruitLoseCount}";
    }
}
