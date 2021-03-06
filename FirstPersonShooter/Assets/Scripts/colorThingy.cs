﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorThingy : MonoBehaviour
{
    private bool alive = false;

    public bool Alive
    {
        get { return alive; }
        set
        {
            alive = value;
            GetComponent<Renderer>().material.color = alive ? UnityEngine.Color.red : UnityEngine.Color.white;
        }
    }

    public void SwitchColor()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            alive = !alive;
            GetComponent<Renderer>().material.color = alive ? UnityEngine.Color.red : UnityEngine.Color.white;
        }
    }
}
