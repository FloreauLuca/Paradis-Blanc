using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManagement : MonoBehaviour
{
    public GameObject lives1, lives2, lives3;
    [SerializeField] private GameObject UIMort;

    // C'est un singleton, ça permet d'avoir accès à toutes les variables public sans mettre de variables en static
    public static LivesManagement Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public int health;

    void Start()
    {
        health = 3;
        lives1.gameObject.SetActive(true);
        lives2.gameObject.SetActive(true);
        lives3.gameObject.SetActive(true);
        UIMort.gameObject.SetActive(false);
    }


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
                Time.timeScale = 0f;
                break;
        }
    }
}
