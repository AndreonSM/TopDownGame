using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody2D;
    private Animator _playerAnimator;
    private Vector2 _playerDirection;
    private Vector2 _lastPlayerDirection;
    public float _playerSpeed;
    private float _playerInitialSpeed;
    public float _playerRunSpeed;
    public GameObject attackHitbox; // Hitbox de ataque

    public float knockbackDuration = 0.2f; // Duração do knockback em segundos
    public float knockbackSpeed = 5f; // Velocidade do knockback

    private bool _isAttacking = false;
    private bool _isKnockedBack = false;
    private Vector2 _knockbackVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerInitialSpeed = _playerSpeed;

        _playerRigidBody2D.drag = 10f;
        _playerRigidBody2D.angularDrag = 10f;

        attackHitbox.SetActive(false); // Garantir que a hitbox comece desativada
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRunningCheck();
        AttackCheck();
    }

    void FixedUpdate()
    {
        if (_isKnockedBack)
        {
            _playerRigidBody2D.velocity = _knockbackVelocity;
        }
        else
        {
            _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            IdleAnimationCheck();

            if (_isAttacking)
            {
                _playerAnimator.SetInteger("Movimento", 2);
            }

            MovePlayer();
        }
    }

    private void IdleAnimationCheck()
    {

        if (_playerDirection.sqrMagnitude > 0.1)
        {
            _playerAnimator.SetFloat("X-Axis", _playerDirection.x);
            _playerAnimator.SetFloat("Y-Axis", _playerDirection.y);

            _playerAnimator.SetInteger("Movimento", 1);
            _lastPlayerDirection = _playerDirection;

            UpdateHitboxPosition();
        }
        else
        {
            _playerAnimator.SetFloat("X-Axis", _lastPlayerDirection.x);
            _playerAnimator.SetFloat("Y-Axis", _lastPlayerDirection.y);
            _playerAnimator.SetInteger("Movimento", 0);
        }
    }

    private void UpdateHitboxPosition()
    {
        if (_playerDirection != Vector2.zero)
        {
            // Define a posição e rotação da hitbox baseado na direção do jogador
            attackHitbox.transform.localPosition = _playerDirection.normalized * 0.5f; // Ajuste a distância conforme necessário
            float angle = Mathf.Atan2(_playerDirection.y, _playerDirection.x) * Mathf.Rad2Deg;
            attackHitbox.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void MovePlayer()
    {
        _playerRigidBody2D.MovePosition(_playerRigidBody2D.position 
                                            + _playerDirection.normalized 
                                            * _playerSpeed 
                                            * Time.fixedDeltaTime);
    }

    void PlayerRunningCheck()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _playerSpeed = _playerRunSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _playerSpeed = _playerInitialSpeed;
        }
    }

    void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            _isAttacking = true;
            _playerSpeed = _playerInitialSpeed / 3;
            
            //hitbox.SetActive(true); // Ativar hitbox
        }
        if (Input.GetKeyUp(KeyCode.Z) || Input.GetMouseButtonUp(0))
        {
            _isAttacking = false;
            _playerSpeed = _playerInitialSpeed;
            
            //hitbox.SetActive(false); // Desativar hitbox
        }
    }

     // Métodos chamados pelos eventos de animação
    public void ActivateHitbox()
    {
        attackHitbox.SetActive(true);
    }

    public void DeactivateHitbox()
    {
        attackHitbox.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            _knockbackVelocity = knockbackDirection * knockbackSpeed;
            StartCoroutine(ApplyKnockback());

            // Causar dano ao jogador
            Health playerHealth = GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Valor do dano a ser ajustado
            }
        }
    }

    IEnumerator ApplyKnockback()
    {
        _isKnockedBack = true;
        yield return new WaitForSeconds(knockbackDuration);
        _isKnockedBack = false;
        _knockbackVelocity = Vector2.zero;
        _playerRigidBody2D.velocity = Vector2.zero;
    }
}
