using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{


    public PlayerMovement PlayerMovement { get; private set; }
    public HealthController HealthController { get; private set; }


    private InteractiveObject currentInteractiveObject;




    private void Awake()
    {

        PlayerMovement = GetComponent<PlayerMovement>();

        HealthController = GetComponent<HealthController>();

    }

    private void Update()
    {
        if (currentInteractiveObject == null)
        {
            return;
        }

        if (!currentInteractiveObject.IsAutoInteract() && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractiveObject.Interact(this);
        }

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
