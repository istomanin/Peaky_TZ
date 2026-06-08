using TMPro;
using UnityEngine;


public class HistoryUIController : MonoBehaviour
{
    
    [SerializeField] private PlayerInteraction playerInteraction;


    [SerializeField] private GameObject historyPanel;
    [SerializeField] private TMP_Text historyText;

    private void Start()
    {
        historyPanel.SetActive(false);
    }




    public void OpenHistory()
    {
        historyPanel.SetActive(true);
        playerInteraction.PlayerMovement.DisableMovement();
        historyText.text = "";
        int counter = 1;
        foreach (string entry in playerInteraction.History)
        {
            historyText.text += counter + ". " + entry + "\n";
            counter++;
        }

    }

    public void CloseHistory()
    {
        historyPanel.SetActive(false);
        playerInteraction.PlayerMovement.EnableMovement();
    }
}
