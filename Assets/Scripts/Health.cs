using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int health = 3;
    
    [Header("Score")]
    [SerializeField] private bool isPlayer;
    [SerializeField] private int scorePerEnemy = 100;
    private ScoreKeeper _scoreKeeper;
    
    [Header("Effects and SFX")]
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private bool applyCameraShake; 
    private CameraShake _cameraShake;
    private AudioPlayer _audioPlayer;
    
    private LevelManager _levelManager; 

    private void Awake()
    {
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            _audioPlayer.PlayDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        if (!isPlayer)
        {
            _scoreKeeper.AddScore(scorePerEnemy);
        }
        else
        {
            _levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
    
    private void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    
    private void ShakeCamera()
    {
        if (_cameraShake != null && applyCameraShake)
        {
            _cameraShake.Play();
        }
    }
    
    public int GetHealth()
    {
        return health;
    }
}
