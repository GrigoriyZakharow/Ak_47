using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

  private TimeSpan time;
  private float sec = 0f;
  private StateTimer stateTimer = StateTimer.Stopped;

  public Text textTimer;

  private void Update() {
    if (stateTimer == StateTimer.Launched) {
      sec += Time.deltaTime;
      time = TimeSpan.FromSeconds(sec);
      textTimer.text = string.Format("{0:d2}:{1:d2}:{2:d3}", time.Minutes, time.Seconds, time.Milliseconds);
    }
  }

  public void LaunchedTimer() {
    ResetTimer();
    stateTimer = StateTimer.Launched;
  }

  public void ResetTimer() {
    sec = 0f;
    textTimer.text = "00:00:00";
    StoppedTimer();
  }

  public void StoppedTimer() {
    stateTimer = StateTimer.Stopped;
  }
}