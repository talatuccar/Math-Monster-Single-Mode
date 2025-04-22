using UnityEngine;
using TMPro;
public class MainPanel : MonoBehaviour
{
    public static MainPanel instance;
    Number numberInstance;
    GameManager gameManager; 
    private string tempMark; 
    public int tempNumber1 { get; private set; } = 0;  
    public int tempNumber2 { get; private set; } = 0;  

    int intermediateResult;
    public int IntermediateResult => intermediateResult;
    int panelIndex;
    [SerializeField] TextMeshProUGUI[] panelText;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameManager=GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    } 
    public void PrintNumber(int number,Number usedNumber)
    {
        numberInstance=usedNumber;
        if (tempNumber1 == 0)
        {
            tempNumber1 = number;
            PrintProcess(tempNumber1);
            Number.canChooseNumber = false;
            numberInstance.ActiveButton(false);
        }
        else
        {
            tempNumber2 = number;
            PrintProcess(tempNumber1, tempNumber2, tempMark);

        }
    }
    public void GetMark(string mark)
    {
        tempMark = mark;
        PrintProcess(tempNumber1, tempMark);
    }
    void PrintProcess(int tempNum)
    {
        panelText[panelIndex].text = tempNum.ToString();
    }
    void PrintProcess(int tempNum, string mark)
    {
        panelText[panelIndex].text = tempNum.ToString() + tempMark;
    }
    void PrintProcess(int tempNum1, int tempNum2, string mark)
    {
        intermediateResult = TempResult(mark);    
        panelText[panelIndex].text = $"{tempNum1}{tempMark}{tempNum2}={intermediateResult}";
        numberInstance.UpdateText(intermediateResult);       
        gameManager.CurrentBestNumber(IntermediateResult);
        panelIndex++;
        ResetTempNumbers();
        Number.canChooseNumber = true;
    }
    int TempResult(string mark)
    {
        switch (mark)
        {
            case "-":
                return tempNumber1 - tempNumber2;
            case "+":
                return tempNumber1 + tempNumber2;
            case "x":
                return tempNumber1 * tempNumber2;
            case "/":
                return tempNumber1 / tempNumber2;

            default:
                return 0;

        }
    }
    void ResetTempNumbers()
    {
        tempNumber1 = 0;
        tempNumber2 = 0;
    } 
}
