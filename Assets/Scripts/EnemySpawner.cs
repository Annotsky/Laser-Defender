using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSo> waveConfigs;
    [SerializeField] private float timeBetweenWaves = 0f;
    [SerializeField] private bool isLooping = false;
    private WaveConfigSo _currentWave;
    
    private void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }
    
    public WaveConfigSo GetCurrentWave()
    {
        return _currentWave;
    }
    
    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSo wave in waveConfigs)
            {
                _currentWave = wave;
                for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(i),
                        _currentWave.GetStartingWaypoint().position,
                        Quaternion.identity, transform);
                    yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
