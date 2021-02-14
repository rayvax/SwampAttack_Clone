using UnityEngine;
using UnityEngine.UI;


public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private Button _button;

    private int _activeSpawnersCount = 0;

    private void OnEnable()
    {
        foreach (var spawner in _spawners)
        {
            spawner.WaveFinished += OnWaveFinished;

            if (!spawner.IsOver)
                _activeSpawnersCount++;
        }
        _button.onClick.AddListener(OnNextWaveButtonClicked);
    }

    private void OnDisable()
    {
        foreach (var spawner in _spawners)
        {
            spawner.WaveFinished -= OnWaveFinished;
        }
        _button.onClick.RemoveListener(OnNextWaveButtonClicked);
    }

    public void OnWaveFinished()
    {
        _activeSpawnersCount--;

        if (_activeSpawnersCount <= 0)
            TryActivateButton();
    }

    public void OnNextWaveButtonClicked()
    {
        foreach (var spawner in _spawners)
        {
            if (spawner.TrySetNextWave())
                _activeSpawnersCount++;
        }

        _button.gameObject.SetActive(false);
    }

    private void TryActivateButton()
    {
        foreach (var spawner in _spawners)
        {

            if (spawner.HasNextWave)
            {
                _button.gameObject.SetActive(true);
                return;
            }

        }
    }
}
