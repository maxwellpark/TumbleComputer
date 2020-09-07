using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// we need negative z rot. to flip right (the initial flip) 
//
// change the anchor pt on the prefab to invert this 
// and have it intuitive (positive)
public class Toggle : MonoBehaviour
{
	public GameObject trigger0; // right 
	public GameObject trigger1; // left 

	// geometry too simple? 

	// byte is the smallest integral type 
	public byte value = 0;
	public bool state;

	// breakout?
	float zDelta = 90f;
	float leeway = 1f;

	//// rename 
	//GameObject marble;
	//GameObject trigger0;
	//GameObject trigger1;

	void Start()
    {
		//marble = GameObject.Find("Marble"); 
		//trigger0 = GameObject.Find("Trigger0");
		//trigger1 = GameObject.Find("Trigger1");
	}
	
	public void ToggleState() 
	{
		// rotate/static flip 
		// flip bit 
		//
		state = !state;
		MachineManager.decimalTotal += state ? 1 : -1; 

		// before or after updating state value?
		//
		SuddenRotation(state); 

		
	}

	// move to utils class 
	// then apply to all comps. 
	//
	//IEnumerator GradualRotation()
	//{
	//	float timer = 90f;
	//	while (timer > 0)
	//	{
	//		// transform.Rotate
	//	}
	//}

	// justify clarity of movement...
	void SuddenRotation(bool state)
    {
		transform.eulerAngles += state ? new Vector3(0f, 0f, -zDelta) : new Vector3(0f, 0f, zDelta); 
    }

    void Update()
    {
		// need to constrain to x too 
		//if (marble.transform.position.y <= trigger0.transform.position.y + leeway ||
		//	marble.transform.position.y <= trigger1.transform.position.y + leeway)
  //      {
		//	ToggleState(); 
  //      }
    }
}
