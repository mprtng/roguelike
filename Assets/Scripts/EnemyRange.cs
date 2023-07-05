using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    public float startSpeed;
    private void _speed;
    private float _timeBetweenAttack;
    public float startTimeBetweenAttack;
    private float _stopTime;
    public float startStopTime;
    public int damage;

    private Player _player;
    private Animator _animator;


    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = FindObjectOfType<Animator>();
        _speed = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(_stopTime <= 0)
        {
            _speed = startSpeed;
        }
        else
        {
            _speed = 0;
            _stopTime -= Time.deltaTime;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * startSpeed * Time.deltaTime); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("PlayerTag"))
        {
            if(_timeBetweenAttack <= 0)
            {
                _animator.SetTrigger("attack")
            }
        }
        else
        {
            _timeBetweenAttack -= Time.deltaTime;
        }
    }
}
