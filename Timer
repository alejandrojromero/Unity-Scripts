using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    public string mzero = " ";
    public string szero = " ";

    void Update()
    {
        UpdateTimerUI();
    }
    //call this on update
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        if (minuteCount < 10)
        {
            mzero = "0";
        }
        else
        {
            mzero = "";
        }
        if (secondsCount < 10)
        {
            szero = "0";
        }
        else
        {
            szero = "";
        }
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
            timerText.text = "Elapsed Time:  " + mzero + minuteCount + ":" + szero + (int)secondsCount;
    }
}
