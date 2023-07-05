using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public int health;

    private Rigidbody2D _rigidBody;
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    private Animator _animator;

    private bool _facingRight = true;
    private bool _isDamaged = false;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = _moveInput.normalized * speed;

        if(_moveInput.x == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }

        if(!_facingRight && _moveInput.x > 0)
        {
            Flip();
        }
        else if(_facingRight && _moveInput.x < 0)
        {
            Flip();
        }
        if(_isDamaged)
        {
            _isDamaged = false;
        }
    }

    void FixedUpdate() 
    {
        _rigidBody.MovePosition(_rigidBody.position + _moveVelocity * Time.fixedDeltaTime);

    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        _isDamaged = true;
    }
}
