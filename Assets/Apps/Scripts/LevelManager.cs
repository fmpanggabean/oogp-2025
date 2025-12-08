using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void ChangeScene(string sceneName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneName);

        while (ao.isDone == false)
        {
            Debug.Log($"Progress: {ao.progress * 100}%");
            await Awaitable.EndOfFrameAsync();
        }
        Debug.Log($"Scene has been loaded.");
    }
}
