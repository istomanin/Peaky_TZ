using TMPro;
using UnityEngine;

public class NoteUIController : MonoBehaviour
{

    [SerializeField] private GameObject notePanel;


    [SerializeField] private TMP_Text  title;

  
    [SerializeField] private TMP_Text text;




    [SerializeField] private PlayerInteraction playerInteraction;

    private void Start()
    {
        notePanel.SetActive(false);
    }



    public void OpenNote(string noteTitle, string noteText)
    {

        notePanel.SetActive(true);
        playerInteraction.PlayerMovement.DisableMovement();
        title.text = noteTitle;
        text.text = noteText;

    }


    public void CloseNote()
    {
        notePanel.SetActive(false);
        playerInteraction.PlayerMovement.EnableMovement();
    }
}
