using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject txtGameOver;
    public Slider sliderHealthPlayer;

    private static UIManager instance;

    public static UIManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

}
