using System;
using System.Collections;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float countdownTime = 30f;
    private float currentTime;
    public TextMeshProUGUI timerText;

    public static event Action OnTimerEnd;
    void Start()
    {
        currentTime = countdownTime;
        StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            timerText.text = currentTime.ToString("0");
            yield return new WaitForSeconds(1f);
            currentTime--;

            CheckTime();
        }

        timerText.text = "0";
        OnTimerEnd?.Invoke(); 
    }
    void CheckTime()
    {
        if (currentTime < 10)
        {
            timerText.color = Color.red;
        }
    }
}
