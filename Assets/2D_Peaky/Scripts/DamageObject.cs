using UnityEngine;

public class DamageObject : InteractiveObject
{


    [SerializeField] private int damageAmount = 3;



    public override void Interact(PlayerInteraction playerInteraction)
    {

        playerInteraction.AddToHistory("Took damage from an object!");
        playerInteraction.HealthController.TakeDamage(damageAmount);
      
        
    
        Destroy(gameObject);
    }




}
