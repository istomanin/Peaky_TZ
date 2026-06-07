using UnityEngine;

public class NoteObject : InteractiveObject
{
    [SerializeField] private string noteTitle;
    [TextArea]
    [SerializeField] private string noteText;


    public override void Interact(PlayerInteraction playerInteraction)
    {
        Debug.Log("1");
        playerInteraction.NoteUIController.OpenNote(noteTitle, noteText);

        Destroy(gameObject);
    }
}
