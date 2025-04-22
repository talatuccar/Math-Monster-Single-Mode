using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] ProgressIndicator progressIndicator;
    private int targetNumber;
    public int TargetNumber
    {
        get => targetNumber;
        private set
        {
            targetNumber = value;
            targetText.text = targetNumber.ToString();
        }
    }

    [SerializeField] TextMeshProUGUI targetText;

    public GameObject resultPanel;
    private int LoverLimit { get; } = 250;
    private int UpperLimit { get; } = 800;
    public TextMeshProUGUI resultText, differenceText; 
    Color successColor = new Color(0, 1, 0, 1);
    Color failedColor = new Color(1, 0, 0, 1);
    void Start()
    {
        PlayerPrefs.DeleteAll();
        TargetNumberDefine();
    }
    void TargetNumberDefine() => TargetNumber = Random.Range(LoverLimit, UpperLimit);

    public void CurrentBestNumber(int currentNumber)
    {
        if (PlayerPrefs.HasKey("BestNumber"))
        {
            int difference = Mathf.Abs(currentNumber - targetNumber);
            if (difference == 0)
            {
                SuccessPanel();
                return;
            }

            if (difference < PlayerPrefs.GetInt("BestNumber"))
            {
                PlayerPrefs.SetInt("BestNumber", difference);
                progressIndicator.UpdateProgress(PlayerPrefs.GetInt("BestNumber"));
            }
        }
        else
        {
            int firstDifference = Mathf.Abs(currentNumber - targetNumber);
            PlayerPrefs.SetInt("BestNumber", firstDifference);
            progressIndicator.Initialize(PlayerPrefs.GetInt("BestNumber"));
        }
    }
    public void CompareResult(int playerResult)
    {
        if (playerResult == 0)
        {
            SuccessPanel();    
        }
        else
        {
            resultPanel.SetActive(true);
            resultPanel.GetComponent<Image>().color = failedColor;
            resultText.text = "FAILED!";
            resultText.color = Color.white;
            differenceText.gameObject.SetActive(true);
            differenceText.text = $"Difference: {playerResult}";
        }
    }
    void SuccessPanel()
    {
        Time.timeScale = 0f;
        resultPanel.SetActive(true);
        resultPanel.GetComponent<Image>().color = successColor;
        resultText.text = "SUCCESS!";
        resultText.color = Color.white;
        differenceText.gameObject.SetActive(false);
    }
    void TimerEnded()
    {
        CompareResult(PlayerPrefs.GetInt("BestNumber"));
        progressIndicator.gameObject.SetActive(false);
    }
    void OnEnable() => Timer.OnTimerEnd += TimerEnded;
    void OnDisable() => Timer.OnTimerEnd -= TimerEnded;
    public void RestartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
