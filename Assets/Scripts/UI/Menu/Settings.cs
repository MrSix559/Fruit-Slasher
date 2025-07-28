using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("FPS")]
    [SerializeField] private Toggle _fps60Toggle;
    [SerializeField] private Toggle _fps120Toggle;

    [Header("Sounds")]
    [SerializeField] private Toggle _soundsOnToggle;
    [SerializeField] private Toggle _soundsOffToggle;
    [SerializeField] private AudioSource _sounds;

    private void Start()
    {
        #region Sounds
        _soundsOnToggle.onValueChanged.AddListener(OnSounds);
        _soundsOffToggle.onValueChanged.AddListener(OffSounds);

        int Sound = EncryptedPlayerPrefs.GetEncryptedInt("Sounds", 1);
        _sounds.mute = Sound == 0;
        _soundsOnToggle.SetIsOnWithoutNotify(Sound == 1); 
        _soundsOffToggle.SetIsOnWithoutNotify(Sound == 0);
        #endregion

        #region FPS
        _fps60Toggle.onValueChanged.AddListener(On60Fps);
        _fps120Toggle.onValueChanged.AddListener(On120Fps);

        int TargetFps = EncryptedPlayerPrefs.GetEncryptedInt("Fps", 60);
        Application.targetFrameRate = TargetFps;
        _fps60Toggle.SetIsOnWithoutNotify(TargetFps == 60); 
        _fps120Toggle.SetIsOnWithoutNotify(TargetFps == 120);
        #endregion
    }

    private void On60Fps(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Fps", isOn ? 60 : 120);
        if (isOn) Application.targetFrameRate = 60;
    }

    private void On120Fps(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Fps", isOn ? 120 : 60);
        if (isOn) Application.targetFrameRate = 120;
    }

    private void OnSounds(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Sounds", isOn ? 1 : 0);
        _sounds.volume = 1f;
    }

    private void OffSounds(bool isOn)
    {
        EncryptedPlayerPrefs.SetEncryptedInt("Sounds", isOn ? 0 : 1);
        _sounds.mute = !isOn;
    }
}
