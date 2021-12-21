using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool _isAutoplayEnabled;

    private SceneLoader _loader;
    private int _breakableBlocks;

    public bool IsAutoplayEnabled => _isAutoplayEnabled;

    private void Start() => _loader = FindObjectOfType<SceneLoader>();

    public void CountBreakableBlocks() => _breakableBlocks++;

    public void OnBlockDestroyed()
    {
        _breakableBlocks--;
        if (_breakableBlocks <= 0)
            _loader.LoadNextScene();
    }
}