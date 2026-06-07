using TMPro;
using UnityEngine;

public class NoteUIController : MonoBehaviour
{

    [SerializeField] private GameObject notePanel;


    [SerializeField] private TMP_Text  title;

    [TextArea]
    [SerializeField] private TMP_Text text;




    [SerializeField] private PlayerInteraction playerInteraction;

    private void Start()
    {
        notePanel.SetActive(false);
    }



    public void OpenNote(string noteTitle, string noteText)
    {

        Debug.Log("2");
        notePanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game


        title.text = noteTitle;
        text.text = noteText;




    }


    public void CloseNote()
    {
        notePanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
}
