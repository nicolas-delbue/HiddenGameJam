using UnityEngine;

public class PlayerData : MonoBehaviour
{
    int[] currentLevelUnlocked;

    private void Awake()
    {
        //Load Data

        //After Data Load
        DontDestroyOnLoad(this.gameObject);
    }
    private void OnDestroy()
    {
        //Save Data
    }
    
}
