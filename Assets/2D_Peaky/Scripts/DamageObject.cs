using UnityEngine;

public class DamageObject : InteractiveObject
{


    [SerializeField] private int damageAmount = 3;



    public override void Interact(PlayerInteraction playerInteraction)
    {
        Debug.Log("Interact.");
        playerInteraction.HealthController.TakeDamage(damageAmount);
        Debug.Log("Player has taken damage.");

        Destroy(gameObject);
    }




}
