using System;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static event Action OnStart;

    [SerializeField] private TMP_Text _bestScoreText;
    public void ButtonStart() => OnStart?.Invoke();

    public void ButtonSettings(GameObject PanelSettings) => PanelSettings.SetActive(true);
    public void ButtonSettingsClose(GameObject PanelSettings) => PanelSettings.SetActive(false);
}
