//Roman Baranov 12.05.2022

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private Text _tapToStartText = null;
    private string _text = "Tap To Start";
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _tapToStartText.text = _text;
        _tapToStartText.gameObject.SetActive(true);

        GameplayEvents.OnLevelComplete.AddListener(RestartLevel);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Time.timeScale = 1f;
            _tapToStartText.gameObject.SetActive(false);
        }
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
