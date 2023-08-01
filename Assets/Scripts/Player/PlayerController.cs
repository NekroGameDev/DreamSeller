using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : LocomotionController
{
    #region [PrivateVars]

    private float moveHorizontal;
    private float moveVertical;

    private Vector3 move;

    private readonly string INPUT_HORIZONTAL = "Horizontal";
    private readonly string INPUT_VERTICAL = "Vertical";

    private Rigidbody _rigidbody;

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
        moveHorizontal = Input.GetAxis(INPUT_HORIZONTAL);
        moveVertical = Input.GetAxis(INPUT_VERTICAL);
    }

    protected override void Move()
    {
        move = Vector3.right * moveHorizontal + Vector3.forward * moveVertical;

        _rigidbody.MovePosition(_rigidbody.position + move * speed * Time.fixedDeltaTime);
    }
}
