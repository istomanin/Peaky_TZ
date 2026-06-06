using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField]protected bool isAutoInteract;

    public bool IsAutoInteract()
    {
        return isAutoInteract;
    }

    public abstract void Interact(PlayerInteraction playerInteraction);
}