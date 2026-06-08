using UnityEngine;

public class NoteObject : InteractiveObject
{
    [SerializeField] private string noteTitle;
    [TextArea]
    [SerializeField] private string noteText;


    public override void Interact(PlayerInteraction playerInteraction)
    {
        playerInteraction.AddToHistory("Read a note: " + noteTitle);
        
        playerInteraction.NoteUIController.OpenNote(noteTitle, noteText);

       

        Destroy(gameObject);
    }
}
