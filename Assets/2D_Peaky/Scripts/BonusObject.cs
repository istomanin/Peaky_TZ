using UnityEngine;

public class BonusObject : InteractiveObject
{

    [SerializeField] private float bonusSpeedValue =2f;


    public override void Interact(PlayerInteraction playerInteraction)
    {
        Debug.Log("Speed Bonus Applied!");

       playerInteraction.PlayerMovement.ApplySpeedBoost(bonusSpeedValue);
       Destroy(gameObject);
    }
   
}
