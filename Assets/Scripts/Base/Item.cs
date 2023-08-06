using UnityEngine;

public class Item : Interactable
{
    #region [PrivateVars]

    protected Rigidbody2D _rigidbody;
    protected Collider2D _collider;

    #endregion

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }
}
