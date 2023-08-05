using UnityEngine;

public class Item : Interactable
{
    #region [PrivateVars]

    protected Rigidbody _rigidbody;
    protected Collider _collider;

    #endregion

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }
}
