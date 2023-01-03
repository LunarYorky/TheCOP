using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using TheCoP.Scripts__components_.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject GameMenu;
    
    private GameSelectPanelController _controller;

    private void Start()
    {
        _controller = GetComponentInChildren<GameSelectPanelController>(true);
    }

    public void GameMenuSwitch()
    {
        _controller.Switch();
    }
    

}
