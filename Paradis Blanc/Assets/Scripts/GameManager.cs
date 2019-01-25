using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }


    [SerializeField] private float initialSpeed;
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private PlayerMouvement player;  // permet d'avoir accès au player de n'importe où
    public PlayerMouvement Player => player;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        SetupScene();
    }

    void SetupScene() // initialise le niveau
    {
        player = GameObject.FindObjectOfType<PlayerMouvement>();
        speed = initialSpeed;
    }

    void Update()
    {
        
    }
}
