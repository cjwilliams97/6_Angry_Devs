using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWTimer : MonoBehaviour
{
    public static bool InCountdown;
    public static float seconds;
    public static bool TimerFinished = false;
    public static bool TimerInterrupted = false; //Keeps track if the timer expired without interruption from StopTimer()

    virtual public void StartTimer(float DesiredTime)
    {
        InCountdown = true;
        seconds = DesiredTime;
        StartCoroutine(StartTime(DesiredTime));
    }
    public void StopTimer()
    {
        TimerInterrupted = true;
        TimerFinished = true;
    }
    IEnumerator StartTime(float DesiredTime)
    {
        InCountdown = true;
        yield return new WaitForSeconds(DesiredTime);
        if (!TimerFinished)
        {
            TimerFinished = true;
            InCountdown = false;
        }
    }
}

public class BarrelTimer : CWTimer
{
    public int NumBarrelsAtFailure = 0;
    private bool TestStatus = true;
    public BarrelManager BarrelMan;
    override public void StartTimer(float DesiredTime)
    {
        seconds = DesiredTime;
        StartCoroutine(StartTimeBarrel(DesiredTime));
    }
    IEnumerator StartTimeBarrel(float DesiredTime)
    {
        InCountdown = true;
        yield return new WaitForSeconds(DesiredTime);
        if (InCountdown)
        {
            int NumBarrelsAtFailure = BarrelManager.barrel_count;
            TestStatus = false;
            TimerFinished = true;
            InCountdown = false;
        }
    }
}
