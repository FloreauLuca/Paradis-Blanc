﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Color invincibilityColor;
    [SerializeField] private float invincibilityTime;
    [SerializeField] private bool invincibilityShake;
    private bool invincibility;
    public bool Invincibility => invincibility;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    [SerializeField] private float airMax; // Comme les chaussures XD   réponse: t'es sérieux ? XD
    public float AirMax => airMax;
    
    [SerializeField] private float decreaseAir;
    private float actualAir;
    public float ActualAir => actualAir;

    private AudioSource audioSource;
    [SerializeField] private AudioClip breath;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        actualAir = airMax;
    }
    
    void Update()
    {
        if (Input.GetButton("Jump") || Input.touchCount>0)
        {
            rigidbody2D.AddForce(Vector2.down*speed);
        }

        if (Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
        {
            rigidbody2D.velocity = new Vector2(0, maxSpeed * Mathf.Sign(rigidbody2D.velocity.y));
        }

        if (rigidbody2D.velocity.y > 2)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        } else if (rigidbody2D.velocity.y < -2)
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (actualAir <= 25f/100 * airMax )
        {
            actualAir -= decreaseAir * Time.deltaTime/2;
        }
        else
        {
            actualAir -= decreaseAir * Time.deltaTime;
        }
        if (actualAir <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        LivesManagement.Instance.Health = 0;
    }

    public IEnumerator InvincibilityCouroutine()
    {
        spriteRenderer.color = invincibilityColor;
        invincibility = true;
        GameManager.Instance.Speed /= 2;
        yield return new WaitForSeconds(1);
        GameManager.Instance.Speed *= 2;
        yield return new WaitForSeconds(invincibilityTime);
        invincibility = false;
        spriteRenderer.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Surface"))
        {
            actualAir = airMax;
            audioSource.PlayOneShot(breath);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Surface"))
        {
            actualAir = airMax;
        }
    }
}
