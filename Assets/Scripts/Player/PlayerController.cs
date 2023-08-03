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

    private readonly string INPUT_HORIZONTAL = "Horizontal";
    private readonly string INPUT_VERTICAL = "Vertical";

    private Rigidbody _rigidbody;

    private float currentDirection = 1;

    #endregion

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

        if (Mathf.Abs(moveHorizontal) > 0)
        {
            currentDirection = moveHorizontal;
        }
    }

    protected override void Move()
    {
        move = Vector3.right * moveHorizontal + Vector3.forward * moveVertical;

        _rigidbody.MovePosition(_rigidbody.position + move * speed * Time.fixedDeltaTime);
    }
}
