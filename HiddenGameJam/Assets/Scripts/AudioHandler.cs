using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioHandler : MonoBehaviour
{
    AudioClip mainMenuMusic;
    AudioClip levelMusic;
    AudioClip winMusic;
    AudioClip lossMusic;
    private void Start()
    {
        SceneManager.activeSceneChanged += ChangeSceneMusic;
        //Link to win and lose
    }
    private void ChangeSceneMusic(Scene from, Scene to)
    {
        switch(to.buildIndex)
        {
            case 0:
                break;
            case 1:
                break;
        }
    }
    private void WinMusic()
    {
        //stop all music
        //Play Win
    }
    private void LoseMusic()
    {
        //stop all music
        //Play Lose
    }
}
