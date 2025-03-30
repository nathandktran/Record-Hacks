using UnityEngine;

public class Slider : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
			
	}

	// Update is called once per frame
	void Update()
	{
		int pot = GameManager.instance.potData;
		float x = ((float)(pot-2048) / 650) * -1;
		Vector3 newPosition = transform.position;
		newPosition.x = x;  // Change the x value to 5
		transform.position = newPosition;  // Apply the new position to the object
	}
}
