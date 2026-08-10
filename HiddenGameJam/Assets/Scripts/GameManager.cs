using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxLevelNumber;
    private void Start()
    {
        CEventSystem.current.onWin += WinLevel;
        CEventSystem.current.onLose += LoseLevel;
    }
    private void OnDestroy()
    {
        CEventSystem.current.onWin -= WinLevel;
        CEventSystem.current.onLose -= LoseLevel;
    }
    private void WinLevel(bool win)
    {
        //Do some form of anim or sound
        //Open WinMenu
        CEventSystem.current.OpenWin(win);
    }
    private void LoseLevel(bool lose)
    {
        //Do some form of anim or sound
        //Open LoseMenu
        CEventSystem.current.OpenLose(lose);
    }
    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 <= maxLevelNumber)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
            
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
