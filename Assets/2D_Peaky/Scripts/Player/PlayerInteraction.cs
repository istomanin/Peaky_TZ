using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private NoteUIController noteUIController;
    public PlayerMovement PlayerMovement { get; private set; }
    public HealthController HealthController { get; private set; }




    private List<string> history = new List<string>();
    public List<string> History => history;

    private InteractiveObject currentInteractiveObject;

    private bool isEPressed;

    public NoteUIController NoteUIController => noteUIController;


    private void Awake()
    {

        PlayerMovement = GetComponent<PlayerMovement>();
        HealthController = GetComponent<HealthController>();

    }

    private void Start()
    {

        GameInput.Instance.OnPlayerPressE += PlayerPressE_performed;

    }



    private void Update()
    {
        if (currentInteractiveObject == null)
        {
            return;
        }

        if (!currentInteractiveObject.IsAutoInteract())
        {

            if (isEPressed)
            {
                currentInteractiveObject.Interact(this);
                isEPressed = false;
            }

        }

    }

    public void AddToHistory(string entry)
    {
        history.Add(entry);
        //Debug.Log("History Updated: " + entry);
       
    }


    private void PlayerPressE_performed(object sender, EventArgs e)
    {
        isEPressed = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out InteractiveObject interactiveObject))
        {

            if (interactiveObject.IsAutoInteract())
            {
                interactiveObject.Interact(this);
            }
            else
            {
                currentInteractiveObject = interactiveObject;
            }

        }





    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out InteractiveObject interactiveObject) && interactiveObject == currentInteractiveObject)
        {
            currentInteractiveObject = null;
        }

    }
}
