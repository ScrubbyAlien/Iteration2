using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuListener : MonoBehaviour
{
    [SerializeField]
    private string gameScene;

    public void LoadGameScene() {
        SceneManager.LoadScene(gameScene);
    }
}