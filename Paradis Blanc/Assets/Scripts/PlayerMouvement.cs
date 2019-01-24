using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") || Input.touchCount>0)
        {
            rigidbody2D.AddForce(Vector2.down*speed);
        }
    }
}
