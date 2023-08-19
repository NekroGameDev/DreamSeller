using UnityEngine;
using UnityEngine.Events;

public class GearCell : TagsCell
{
    [Header("Gear")]
    [SerializeField] private LayerMask gearsLayer;
    [SerializeField] private float radiusCast;

    [SerializeField] private bool rotateOnStart;
    [SerializeField] private Animator _animator;

    [SerializeField] private bool isDrawGizmos;

    [SerializeField] private UnityEvent onStartRotation;

    private bool isRotating;

    public bool IsRotating => isRotating;

    protected override void Start()
    {
        base.Start();

        if (rotateOnStart)
        {
            SetIsRotating(true);
        }

        CheckNearerGears();
    }

    private void OnEnable()
    {
        onStartMove += OnStartMove;
        onStopMove += OnStopMove;
    }

    private void OnDisable()
    {
        onStartMove -= OnStartMove;
        onStopMove -= OnStopMove;
    }

    private void OnStartMove()
    {
        SetIsRotating(false);
    }

    private void OnStopMove(Vector3 lastPosition)
    {
        Collider2D[] _colliders = Physics2D.OverlapCircleAll(lastPosition, radiusCast, gearsLayer);

        foreach (Collider2D c in _colliders)
        {
            if (c.TryGetComponent(out GearCell gear))
            {
                if (gear.IsRotating)
                {
                    gear.StopRotating();
                    gear.CheckNearerGears();
                }
            }
        }

        CheckNearerGears();
    }

    public void CheckNearerGears()
    {
        Collider2D[] _colliders = Physics2D.OverlapCircleAll(transform.position, radiusCast, gearsLayer);

        foreach (Collider2D c in _colliders)
        {
            if (c.TryGetComponent(out GearCell gear))
            {
                if (gear.IsRotating)
                {
                    SetIsRotating(true);
                    break;
                }
            }
        }
    }

    public void StartRotating()
    {
        if (!isRotating)
        {
            SetIsRotating(true);
        }
    }

    public void StopRotating()
    {
        if (isRotating)
        {
            SetIsRotating(false);
        }
    }

    private void SetIsRotating(bool _value)
    {
        isRotating = _value;
        _animator.SetBool("IsRotating", isRotating);

        if (isRotating)
        {
            onStartRotation?.Invoke();

            Collider2D[] _colliders = Physics2D.OverlapCircleAll(transform.position, radiusCast, gearsLayer);

            foreach (Collider2D c in _colliders)
            {
                if (c.TryGetComponent(out GearCell gear))
                {
                    gear.StartRotating();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (isDrawGizmos)
        {
            Gizmos.DrawSphere(transform.position, radiusCast);
        }
    }
}
