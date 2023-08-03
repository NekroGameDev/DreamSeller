using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : LocomotionController
{
    #region [PublicVars]

    public float GetCurrentDirection => currentDirection;

    #endregion

    #region [PrivateVars]

    
    private float moveHorizontal;
    private float moveVertical;

    private Vector3 move;

    private float currentDirection = 1;

    private int state;

    private Rigidbody _rigidbody;
    private PlayerAnimations playerAnimations;

    private readonly string INPUT_HORIZONTAL = "Horizontal";
    private readonly string INPUT_VERTICAL = "Vertical";

    #endregion

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerAnimations = GetComponent<PlayerAnimations>();
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

        playerAnimations.SetMove(state, (int)moveHorizontal, (int)moveVertical);
    }

    protected override void Move()
    {
        move = Vector3.right * moveHorizontal + Vector3.forward * moveVertical;

        _rigidbody.MovePosition(_rigidbody.position + move * speed * Time.fixedDeltaTime);
    }
}
