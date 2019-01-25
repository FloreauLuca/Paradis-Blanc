using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private float speed;


    [SerializeField] private float airMax; // Comme les chaussures XD
    public float AirMax => airMax;
    
    [SerializeField] private float decreaseAir;
    private float actualAir;
    public float ActualAir => actualAir;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        actualAir = airMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") || Input.touchCount>0)
        {
            rigidbody2D.AddForce(Vector2.down*speed);
        }

        actualAir -= decreaseAir * Time.deltaTime;
        if (actualAir <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        LivesManagement.Instance.health = 0;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Surface"))
        {
            actualAir = airMax;
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
