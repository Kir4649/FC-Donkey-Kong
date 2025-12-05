using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBottn: MonoBehaviour
{
    public void GoToStage1()
    {
        SceneManager.LoadScene("Main");
    }
}
