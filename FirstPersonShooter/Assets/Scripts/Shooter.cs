using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private bool isFiring = false;
    RaycastHit hit;


    /*void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * 100);
        if (Physics.Raycast(ray, out hit, 1000) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isFiring = true;
        }
    }*/
}
