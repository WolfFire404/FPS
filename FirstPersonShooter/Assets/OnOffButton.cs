using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class OnOffButton : MonoBehaviour
{



	RaycastHit hit;

	void Update ()
	{


		if (hit) {
			ToggleThisBitchUpNibba ();
		}
	}


	void ToggleThisBitchUpNibba ()
	{
		

		if (GlobalVariables.thisShitOn == true) {
			var rend = GetComponent<Renderer> ();

			rend.material.color = new UnityEngine.Color (0, 0, 0);

			GlobalVariables.thisShitOn = false;
			

		} else {

			var rend = GetComponent<Renderer> ();

			rend.material.color = new UnityEngine.Color (1, 0, 1);

			GlobalVariables.thisShitOn = true;
		}

		

	}
}


