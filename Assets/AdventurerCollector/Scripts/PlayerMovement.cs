using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private int speed;
    private bool canMove = true;

    [Header("Dash")]

    [SerializeField] private float speedDash;
    [SerializeField] private float timeDash;
    [SerializeField] private float initialGravity;
    [SerializeField] private AudioSource _audioSource;
    private bool canDash = true;

    private MovementEntries _movementEntries;

    private void Awake()
    {
      _movementEntries = new MovementEntries();
    }

    private void OnEnable()
    {
        _movementEntries.Enable();
    }

    private void OnDisable()
    {
        _movementEntries.Disable();
    }


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
       _spriteRenderer = GetComponent<SpriteRenderer>();
       _animator = GetComponent<Animator>();
        speed = 18;
        speedDash = 37f;
        timeDash = 0.4f;
        initialGravity = _rigidbody2D.gravityScale;
        _audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (canMove) {
            movement();
        }

        if (_movementEntries.Movimiento.Dash.triggered && canDash)
        {
            StartCoroutine(dash());    
        }
    }

    public void movement()
    {
        var movementValue = _movementEntries.Movimiento.Horizontal.ReadValue<float>();

        if (movementValue == 0)
        {
            _animator.SetBool("run", false);
        }

        if (movementValue > 0f)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("run", true);
        }
        else if (movementValue < 0f)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("run", true);
        }

        _rigidbody2D.velocity = new Vector2(movementValue * speed, transform.position.y);
    }

    private IEnumerator dash()
    {
        canMove = false;
        canDash = false;
        _rigidbody2D.gravityScale = 0;

        _animator.SetBool("dash", true);
        _audioSource.Play();
        
        if (_spriteRenderer.flipX) {
            _rigidbody2D.velocity = new Vector2(-speedDash * transform.localScale.x, transform.position.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(speedDash * transform.localScale.x, transform.position.y);
        }

        yield return new WaitForSeconds(timeDash);
        
        _animator.SetBool("dash", false);
        canMove = true;
        canDash = true;
        _rigidbody2D.gravityScale = initialGravity;
    }
}
