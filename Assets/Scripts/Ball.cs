using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private PaddleController _paddle;
    [SerializeField] private float _offsetY = 0.8f;
    [SerializeField] private Vector2 _launchVelocity = new Vector2(2f, 10f);
    [SerializeField] private float _randomFactor = 0.5f;

    private Transform _transform;
    private Rigidbody2D _rb2D;
    private bool _isLaunched = false;

    private void Awake()
    {
        _transform = transform;
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!_isLaunched)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 preventStackVelocity = new Vector2(Random.Range(0, _randomFactor), Random.Range(0, _randomFactor));
        _rb2D.velocity += preventStackVelocity;
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isLaunched = true;
            _rb2D.velocity = _launchVelocity;
        }
    }

    private void LockBallToPaddle()
    {
        Vector3 paddlePosition = _paddle.transform.position;
        _transform.position = new Vector3(paddlePosition.x, paddlePosition.y + _offsetY);
    }
}
