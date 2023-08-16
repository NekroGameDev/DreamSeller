using UnityEngine;

public abstract class LocomotionController : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected abstract void Move();
}
