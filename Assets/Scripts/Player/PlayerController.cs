using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : LocomotionController
{
    #region [PublicVars]

    public float GetCurrentDirection => currentDirection;

    #endregion

    #region [PrivateVars]

    
    private float moveHorizontal;
    private float moveVertical;

    private Vector2 move;

    private float currentDirection = 1;

    private int state;

    private Rigidbody2D _rigidbody;
    private PlayerAnimations playerAnimations;
    private AudioSource _audio;

    private readonly string INPUT_HORIZONTAL = "Horizontal";
    private readonly string INPUT_VERTICAL = "Vertical";

    #endregion

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        moveHorizontal = Input.GetAxisRaw(INPUT_HORIZONTAL);
        moveVertical = Input.GetAxisRaw(INPUT_VERTICAL);

        state = Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical) > 0 ? 1 : 0;

        if (Mathf.Abs(moveHorizontal) > 0)
        {
            currentDirection = moveHorizontal;
        }

        if (state == 0)
        {
            _audio.Stop();
        }
        else
        {
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
        }

        playerAnimations.SetMove(state, (int)moveHorizontal, (int)moveVertical);
    }

    protected override void Move()
    {
        move = Vector2.right * moveHorizontal + Vector2.up * moveVertical;

        _rigidbody.MovePosition(_rigidbody.position + move * speed * Time.fixedDeltaTime);
    }

    public void StopMove()
    {
        playerAnimations.SetMove(0, (int)moveHorizontal, (int)moveVertical);
    }
}
