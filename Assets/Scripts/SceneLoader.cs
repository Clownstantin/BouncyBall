using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private ScoreManager _scoreManager;

    private void Start() => _scoreManager = FindObjectOfType<ScoreManager>();

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int scenesCount = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex < scenesCount - 1)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
        {
            SceneManager.LoadScene(0);
            _scoreManager.ResetScore();
        }
    }

    public void QuitGame() => Application.Quit();
}
