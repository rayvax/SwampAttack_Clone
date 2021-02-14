using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    public event UnityAction<int, int> OnSpawnedCountChanged;
    public event UnityAction WaveFinished;

    public bool IsOver => (_currentWaveIndex >= _waves.Count);
    public bool HasNextWave => (_currentWaveIndex + 1 < _waves.Count);

    private float _timeBeforeSpawn = 0;
    private Wave _currentWave;
    private int _currentWaveIndex;
    private int _spawnedCount;
    private int _enemiesAlive = 0;

    private void Start()
    {
        _currentWave = _waves[_currentWaveIndex];
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeBeforeSpawn -= Time.deltaTime;
        if(_timeBeforeSpawn <= 0)
        {
            SpawnEnemy();
            _spawnedCount++;
            OnSpawnedCountChanged?.Invoke(_spawnedCount, _currentWave.Count);

            _enemiesAlive++;
            _timeBeforeSpawn = _currentWave.Delay;

            if (_spawnedCount >= _currentWave.Count)
            {
                _currentWave = null;
            }
        }
    }

    public bool TrySetNextWave()
    {
        _currentWaveIndex++;
        if(!IsOver)
        {
            _currentWave = _waves[_currentWaveIndex];
            _timeBeforeSpawn = _currentWave.Delay;

            _spawnedCount = 0;
            OnSpawnedCountChanged?.Invoke(_spawnedCount, _currentWave.Count);
            return true;
        }

        return false;
    }


    private void SpawnEnemy()
    {
        Enemy spawnedEnemy = Instantiate(_currentWave.EnemyTemplate, _spawnPoint.position, Quaternion.identity, _spawnPoint);
        spawnedEnemy.Init(_player);
        spawnedEnemy.OnDead += OnEnemyDead;
    }

    private void OnEnemyDead(Enemy enemy)
    {
        enemy.OnDead -= OnEnemyDead;
        _player.TryAddMoney(enemy.Reward);

        _enemiesAlive--;
        if (_currentWave == null && _enemiesAlive <= 0)
        {
            WaveFinished?.Invoke();
        }
            
    }
}

[System.Serializable]
public class Wave
{
    public Enemy EnemyTemplate;
    public float Delay;
    public int Count;
}
