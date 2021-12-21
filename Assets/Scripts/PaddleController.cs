using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Camera _camera;
    private Transform _transform;
    private GameController _controller;
    private Ball _ball;

    private const int Min = 1;
    private const int Max = 15;

    private void Awake()
    {
        _camera = Camera.main;
        _transform = transform;
    }

    private void Start()
    {
        _controller = FindObjectOfType<GameController>();
        _ball = FindObjectOfType<Ball>();
    }

    private void Update() => MouseMovement();

    private void MouseMovement()
    {
        // float mousePosInUnits = Input.mousePosition.x / Screen.width * 16f;
        // Тоже самое что и _camera.ScreenToWorldPoint(Input.mousePosition)
        float clampedX = Mathf.Clamp(GetXPos(), Min, Max);
        _transform.position = new Vector2(clampedX, _transform.position.y);
    }

    private float GetXPos()
    {
        if (_controller.IsAutoplayEnabled)
            return _ball.transform.position.x;
        else
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            return mousePosition.x;
        }
    }
}
