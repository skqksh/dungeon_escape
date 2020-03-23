using UnityEngine;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour, IDamageable
{
    public float gems = 0;
    private Rigidbody2D _rbody;
    [SerializeField] private float _jumpForce = 220f;
    [SerializeField] private float _speed = 2.5f;

    private PlayerAnimation _playerAnim;

    private SpriteRenderer _playerSprite;

    private SpriteRenderer _swordSprite;

    private BoxCollider2D _boxCollider2;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _boxCollider2 = GetComponent<BoxCollider2D>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move != 0)
        {
            bool isFaceLeft = move < 0;
            _playerSprite.flipX = isFaceLeft;
            _swordSprite.flipX = isFaceLeft;
            _swordSprite.flipY = isFaceLeft;
        }

        _playerAnim.Move(move);
        _rbody.velocity = new Vector2(move * _speed, _rbody.velocity.y);


        if (_rbody.velocity.y == 0)
        {
            _playerAnim.Jump(false);
        }

        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rbody.AddForce(Vector2.up * _jumpForce);
                _playerAnim.Jump(true);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                _playerAnim.Attack();
            }
        }
    }


    private bool IsGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider2.bounds.center, _boxCollider2.bounds.size, 0f,
            Vector2.down, extraHeightText, 1 << 8);

        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(_boxCollider2.bounds.center + new Vector3(_boxCollider2.bounds.extents.x, 0),
            Vector2.down * (_boxCollider2.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_boxCollider2.bounds.center - new Vector3(_boxCollider2.bounds.extents.x, 0),
            Vector2.down * (_boxCollider2.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(
            _boxCollider2.bounds.center - new Vector3(_boxCollider2.bounds.extents.x,
                _boxCollider2.bounds.extents.y + extraHeightText),
            Vector2.right * (_boxCollider2.bounds.extents.x * 2f), rayColor);

        return raycastHit.collider != null;
    }

    public int Health { get; set; }
    public void Damage(int damageAmount)
    {
        Debug.Log("ouch!!@");
    }
}