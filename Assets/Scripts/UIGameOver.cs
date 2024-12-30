using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeper _scoreKeeper;
    
    private void Awake()
    {
        _scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    
    private void Start()
    {
        scoreText.text = "You Score:\n" + _scoreKeeper.GetScore();
    }
}
