using UnityEngine;
using UnityEngine.UI;
public class ProgressIndicator : MonoBehaviour
{
    public Image progressBar; 
    private int maxDifference;
    public void Initialize(int firstGuess)
    {
        maxDifference = firstGuess;
        gameObject.SetActive(true);
    }
    public void UpdateProgress(int playerResult)
    {
        int difference = playerResult;
        float fillAmount = 1f - (float)difference / maxDifference;
        progressBar.fillAmount = Mathf.Clamp01(fillAmount);
        progressBar.color = Color.Lerp(Color.red, Color.green, fillAmount);
    }
}
