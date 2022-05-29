using UnityEngine;
using UnityEngine.SceneManagement;

public class MyScenesManager : MonoBehaviour
{
    public void LSwitchSceneOn(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void LSwitchSceneOn(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
