using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractino : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interaction;

    public GameObject Instructions;

    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
        Instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interaction.Invoke();
                Instructions.SetActive(true);
            }
        }

        if (!isInRange)
        {
            Instructions.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;

            Debug.Log("Print InRange");

            Instructions.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;

            Debug.Log("Out of Rabge");

            Instructions.SetActive(false);
        }
    }
}
