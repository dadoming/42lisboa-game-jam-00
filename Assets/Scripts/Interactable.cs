using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

	public bool isInRange;
	public KeyCode interactKey;
	public string interactText;
	public UnityEvent interactAction;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (isInRange) // If the player is in range
		{
			if (Input.GetKeyDown(interactKey)) // If the player presses the interact key
			{
				interactAction.Invoke(); //Fire event
			}
		}
    }

	// Aproximou-se do objeto
	// Change the Player Tag to the tag you are using for the player
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			isInRange = true;
			Debug.Log("Player in range");
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			isInRange = false;
			Debug.Log("Player out of range");
		}
	}
}
