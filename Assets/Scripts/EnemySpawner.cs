using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSo currentWave;
    
    private void Start()
    {
        SpawnEnemies();
    }
    
    public WaveConfigSo GetCurrentWave()
    {
        return currentWave;
    }
    
    private void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i),
                currentWave.GetStartingWaypoint().position,
                Quaternion.identity, transform);
        }
    }
}
