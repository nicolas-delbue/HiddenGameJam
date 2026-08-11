using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject LevelSelectPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject CreditsPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainMenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void SwapToPanel(GameObject panel)
    {
        DisableAllPanels();
        panel.SetActive(true);
    }
    private void DisableAllPanels()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlaySelectedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
