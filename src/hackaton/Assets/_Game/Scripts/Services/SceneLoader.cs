using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadAsyncSceneBy(string name) => 
        SceneManager.LoadScene(name);
}