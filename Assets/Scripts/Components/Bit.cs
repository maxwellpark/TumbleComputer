using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bit : MonoBehaviour
{
	// Right side trigger 
	public GameObject trigger0;
	
	// Left side trigger 
	public GameObject trigger1; 

	public byte value = 0;
	public bool state;

	public void ToggleState() 
	{
		state = !state;
		SuddenRotation(state); 
	}

	void SuddenRotation(bool state)
    {
		transform.eulerAngles += state ? new Vector3(
			0f, 0f, -MachineConstants.bitZRotation) : new Vector3(0f, 0f, MachineConstants.bitZRotation); 
    }
}
