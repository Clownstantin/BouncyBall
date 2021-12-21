using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(sceneCount - 1);
    }
}
