using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Number : MonoBehaviour
{
    Button numberButton;
    TextMeshProUGUI panelText;
    public static bool canChooseNumber = true;
    void Start()
    {
        numberButton = GetComponent<Button>();
        panelText = GetComponent<TextMeshProUGUI>();
        numberButton.onClick.AddListener(SendToPanel);
    }
    void SendToPanel()
    {
        if (canChooseNumber)
        {
            int tempNumber = int.Parse(panelText.text);
            MainPanel.instance.PrintNumber(tempNumber, this);         
        }     
    } 
    public void UpdateText(int intervalResult)
    {       
        panelText.text = intervalResult.ToString();      
    }
    public void ActiveButton(bool isActive)
    {
        numberButton.interactable = isActive;
    }
    void OnDestroy()
    {
        numberButton.onClick.RemoveAllListeners();
    }
}
