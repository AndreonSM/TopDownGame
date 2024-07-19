using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float _moveSpeedSlime = 3.5f;
    private Vector2 _slimeDirection;
    private Rigidbody2D _slimeBody;
    public DetectionController _detectionArea;
    private SpriteRenderer _spriteRenderer;
    private Animator _slimeAnimator;

    private bool isKnockedBack = false;
    private float knockbackDuration = 0.2f;
    private float knockbackTimer = 0f;

    void Start()
    {
        _slimeBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _slimeAnimator = GetComponent<Animator>();

        if (_detectionArea == null)
        {
            Debug.LogError("DetectionArea não está atribuído no SlimeController.");
        }
    }

    void Update()
    {
        if (isKnockedBack)
        {
            _slimeAnimator.SetInteger("Move", 2);
            knockbackTimer -= Time.deltaTime;

            if (knockbackTimer <= 0)
            {   
                _slimeAnimator.SetInteger("Move", 0);
                isKnockedBack = false;
                _slimeBody.velocity = Vector2.zero;  // Resetar velocidade da slime quando o knockback termina
            }
        }
        else if (_detectionArea != null && _detectionArea.detectedObjs.Count > 0)
        {
            _slimeDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        if (!isKnockedBack && _detectionArea != null && _detectionArea.detectedObjs.Count > 0)
        {
            _slimeAnimator.SetInteger("Move", 1);
            _slimeBody.MovePosition(_slimeBody.position + _slimeDirection * _moveSpeedSlime * Time.fixedDeltaTime);

            if (_slimeDirection.x > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_slimeDirection.x < 0)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }

    public void ApplyKnockback(Vector2 knockbackDirection, float knockbackForce)
    {
        isKnockedBack = true;
        knockbackTimer = knockbackDuration;
        _slimeBody.velocity = Vector2.zero; // Resetar velocidade atual
        _slimeBody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
