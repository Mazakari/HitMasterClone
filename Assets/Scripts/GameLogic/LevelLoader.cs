//Roman Baranov 12.05.2022

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        GameplayEvents.OnLevelComplete.AddListener(RestartLevel);    
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Restart current scene
    /// </summary>
    private void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    #endregion
}
