using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManagement : MonoBehaviour
{
    public GameObject lives1, lives2, lives3;
    [SerializeField] private GameObject UIMort;

    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        lives1.gameObject.SetActive(true);
        lives2.gameObject.SetActive(true);
        lives3.gameObject.SetActive(true);
        UIMort.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (health)
        {
            case 3:
                lives1.gameObject.SetActive(true);
                lives2.gameObject.SetActive(true);
                lives3.gameObject.SetActive(true);
                break;
            case 2:
                lives1.gameObject.SetActive(false);
                break;
            case 1:
                lives1.gameObject.SetActive(false);
                lives2.gameObject.SetActive(false);
                break;
            case 0:
                lives1.gameObject.SetActive(false);
                lives2.gameObject.SetActive(false);
                lives3.gameObject.SetActive(false);
                UIMort.gameObject.SetActive(true);
                break;
        }
    }
}
