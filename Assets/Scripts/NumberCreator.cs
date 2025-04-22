using UnityEngine;
using TMPro;
public class NumberCreator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI twoDigitsText;
    [SerializeField] TextMeshProUGUI[] numbersText;
    void Start()
    {
        MakeNumber();
        MakeTwoDigit();
    }
    void MakeNumber()
    {
        for (int i = 0; i < numbersText.Length; i++)
        {
            int tempNumber = Random.Range(1, 10);
            numbersText[i].text = tempNumber.ToString();
        }
    }
    void MakeTwoDigit()
    {
        int twoDigitNumber = Random.Range(25, 75);
        twoDigitsText.text = twoDigitNumber.ToString();
    }
}
