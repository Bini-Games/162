using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadSceneWith(string name) => 
        SceneManager.LoadScene(name);
}