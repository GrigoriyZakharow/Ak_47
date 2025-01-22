using UnityEngine;

public class ChangeAnimOneDutal : MonoBehaviour
{
  public AnimationClip clip1;
  public AnimationClip clip2;
  public Animation anim;

  public void AnipChange1()
  {
    anim.clip = clip2;
    DownObject.bigStep++;
  }
  public void AnipChange2()
  {
    anim.clip = clip1;
    DownObject.bigStep++;
  }
  public void NullBigStep()
  {
    if(UnityEngine.Time.timeScale != 0.75f)
      Time.flagSave = true;
    anim.clip = clip1;
    DownObject.bigStep = 1;
    Time.flag = false;
    Time.sec = 0;
    UnityEngine.Time.timeScale = 1f;
  }
}