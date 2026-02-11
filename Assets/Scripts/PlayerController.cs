using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private PlayerControls                          _playerControls;
    [SerializeField] private Vector2                _PlayerDirection;
    private Rigidbody2D                             _PlayerRB2D;
    public float                                    _PlayerSpeed;

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void PlayerInput()
    {
        _PlayerDirection = _playerControls.Player.Move.ReadValue<Vector2>();
    }

    void Start()
    {
        _PlayerRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();   
    }

    private void FixedUpdate()
    {
        playerMove();
    }

    void playerMove()
    {
        _PlayerRB2D.MovePosition(_PlayerRB2D.position + _PlayerDirection * (_PlayerSpeed * Time.deltaTime));
    }
}
