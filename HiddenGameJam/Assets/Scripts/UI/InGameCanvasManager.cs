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

        //Change on Win to onOpenWinPanel, so onWin can go to GameManager
        CEventSystem.current.onOpenWin += WinPanel;
        CEventSystem.current.onOpenLose += LosePanel;
        CEventSystem.current.onPause += PauseMenu;
    }
    private void OnDestroy()
    {
        CEventSystem.current.onOpenWin -= WinPanel;
        CEventSystem.current.onOpenLose -= LosePanel;
        CEventSystem.current.onPause -= PauseMenu;
    }
    //Win Menu Functions
    private void WinPanel(bool toggle)
    {
        winPanel.SetActive(toggle);
        CEventSystem.current.PauseInputs(toggle);
        CEventSystem.current.CanPause(!toggle);
    }
    //Lose Menu Functions
    private void LosePanel(bool toggle)
    {
        losePanel.SetActive(toggle);
        CEventSystem.current.PauseInputs(toggle);
        CEventSystem.current.CanPause(!toggle);
    }
    //Pause Menu Functions
    private void PauseMenu(bool toggle)
    {
        pausePanel.SetActive(toggle);
        CEventSystem.current.PauseInputs(toggle);
    }
    //Shared Functions

}
