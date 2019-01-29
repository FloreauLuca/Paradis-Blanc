using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Slider airSlider;

    [SerializeField] private GameObject postprocessGameObject;
    [SerializeField] private GameObject endPanel;
    

    [SerializeField] private float pourcentageBloomActivation; // pourcentage à partir dulequel le bloom s'active

    // Start is called before the first frame update
    void Start()
    {
        airSlider.maxValue = GameManager.Instance.Player.AirMax;
        airSlider.value = GameManager.Instance.Player.ActualAir;
    }

    // Update is called once per frame
    void Update()
    {
        airSlider.value = GameManager.Instance.Player.ActualAir;
        if (GameManager.Instance.Player.ActualAir <= GameManager.Instance.Player.AirMax * (pourcentageBloomActivation/100))
        {
            postprocessGameObject.SetActive(true);
        }
        else
        {
            postprocessGameObject.SetActive(false);
        }

        if (GameManager.Instance.end)
        {
            endPanel.SetActive(true);
        }
    }
    
    
}
