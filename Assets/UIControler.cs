using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    [SerializeField] GameObject panel;
    //[SerializeField] Slider HPBar;
    //[SerializeField] Slider  ManaBar;

    void Start()
    {
        panel.SetActive(false);
        //HPBar.value = HPBar.maxvalue;
        //ManaBar.value = ManaBar.maxvalue * 0.7f;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) panel.SetActive(true);
        if (Input.GetKeyUp(KeyCode.E)) panel.SetActive(false);
    }
}
