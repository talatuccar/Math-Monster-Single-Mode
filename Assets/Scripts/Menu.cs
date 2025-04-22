using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject guidePanel;
    public void GuidePanel()
    {
        if (guidePanel != null)
            guidePanel.SetActive(!guidePanel.activeSelf);
        else
            Debug.LogWarning("GuidePanel reference has not been assigned!");
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
