using UnityEngine;

public class RepeatTimer
{
    private float _repeatTime;
    private float _lastTime;

    public bool Done => Time.time >= _lastTime + _repeatTime;
    public bool DoneWithReset
    {
        get
        {
            if(Done)
            {
                Reset();
                return true;
            }

            return false;
        }
    }

    public RepeatTimer(float repeatTime)
    {
        _repeatTime = repeatTime;
        _lastTime = -999;
    }

    public void Reset()
    {
        _lastTime = Time.time;
    }

    public void SetTime(float time)
    {
        _repeatTime = time;
    }
}