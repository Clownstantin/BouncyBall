using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private int _currentScore = 0;
    private int _pointsPerBlock = 5;

    private void Awake()
    {
        int scoreManagerCount = FindObjectsOfType<ScoreManager>().Length;

        if (scoreManagerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start() => UpdateScore();

    public void AddToScore()
    {
        _currentScore += _pointsPerBlock;
        UpdateScore();
    }

    public void ResetScore() => Destroy(gameObject);

    private void UpdateScore() => _scoreText.text = _currentScore.ToString();
}
