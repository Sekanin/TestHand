using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button _playButton; // 1

    private void Start() // 2
    {
        _playButton.onClick.AddListener(LoadScene); // 3
    }

    private void LoadScene() // 4
    {
        SceneManager.LoadScene("PlayScene"); // 5
    }
}
