using System;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
  public static bool flagSave;
  public static bool flag;
  public Text txt;
  public static float sec;
  public TimeSpan time;

  static Time()
  {
    sec = 0;
    flag = false;
    flagSave = false;
  }

  void Update()
  {
    if(flag)
    {
      sec += UnityEngine.Time.deltaTime;
      time = TimeSpan.FromSeconds(sec);
      txt.text = string.Format("{0:d2}:{1:d2}:{2:d3}", time.Minutes, time.Seconds, time.Milliseconds);
    }
    else if(flagSave && !flag)
    {
      ReadResult.Add(txt.text);
      flagSave = false;
    }
  }
}