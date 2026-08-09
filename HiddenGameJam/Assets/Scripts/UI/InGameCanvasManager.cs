using UnityEngine;

public class InGameCanvasManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        pausePanel.SetActive(false);

        //Subscribe to events
        CEventSystem.current.onWin += WinPanel;
        CEventSystem.current.onLose += LosePanel;
        CEventSystem.current.onPause += PauseMenu;
    }
    private void OnDestroy()
    {
        CEventSystem.current.onWin -= WinPanel;
        CEventSystem.current.onLose -= LosePanel;
        CEventSystem.current.onPause -= PauseMenu;
    }
    //Win Menu Functions
    private void WinPanel(bool toggle)
    {
        winPanel.SetActive(toggle);
        CEventSystem.current.PauseInputs(toggle);
    }
    //Lose Menu Functions
    private void LosePanel(bool toggle)
    {
        losePanel.SetActive(toggle);
        CEventSystem.current.PauseInputs(toggle);
    }
    //Pause Menu Functions
    private void PauseMenu(bool toggle)
    {
        pausePanel.SetActive(toggle);
        CEventSystem.current.PauseInputs(toggle);
    }
    //Shared Functions

}
