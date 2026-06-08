using UnityEngine;

public class BonusObject : InteractiveObject
{

    [SerializeField] private float bonusSpeedValue = 2f;


    public override void Interact(PlayerInteraction playerInteraction)
    {

        playerInteraction.AddToHistory("Picked up a speed boost! Speed increased by " + bonusSpeedValue + "x for 4 seconds.");
        playerInteraction.PlayerMovement.ApplySpeedBoost(bonusSpeedValue);

        Destroy(gameObject);
    }

}
