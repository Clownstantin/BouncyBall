using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioClip[] _breakSounds;
    [SerializeField] private float _soundVolume;
    [Header("Damage Settings")]
    [SerializeField] private Sprite[] _damageLevels;
    [SerializeField] private GameObject _destroyEffect;

    private Camera _camera;
    private SpriteRenderer _renderer;
    private GameController _gameManager;
    private ScoreManager _scoreManager;
    private int _currentHits = 0;

    private void Awake()
    {
        _camera = Camera.main;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        CountBlocksOnScene();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpawnAndDestroyEffect(collision.GetContact(0).point);

        _currentHits++;

        int maxHits = _damageLevels.Length + 1;

        if (_currentHits >= maxHits)
            DestroyBlock();
        else
            ShowDamageInpact();
    }

    private void CountBlocksOnScene()
    {
        _gameManager = FindObjectOfType<GameController>();
        _gameManager.CountBreakableBlocks();
    }

    private void ShowDamageInpact()
    {
        int spriteIndex = _currentHits - 1;
        if (spriteIndex < _damageLevels.Length)
            _renderer.sprite = _damageLevels[spriteIndex];
    }

    private void DestroyBlock()
    {
        _scoreManager.AddToScore();

        var randomClip = _breakSounds[Random.Range(0, _breakSounds.Length)];
        AudioSource.PlayClipAtPoint(randomClip, _camera.transform.position, _soundVolume);

        Destroy(gameObject);
        _gameManager.OnBlockDestroyed();
    }

    private void SpawnAndDestroyEffect(Vector3 position)
    {
        GameObject effect = Instantiate(_destroyEffect, position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}
