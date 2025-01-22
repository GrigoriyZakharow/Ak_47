using UnityEngine;

public class ChangeAnimTwoDutal : MonoBehaviour
{
  public AnimationClip clip1;
  public AnimationClip clip2;
  public AnimationClip clip3;
  public AnimationClip clip4;
  public Animation anim;

  public void AnipChange1()
  {
    anim.clip = clip2;
    DownObject.bigStep++;
  }
  public void AnipChange2()
  {
    anim.clip = clip3;
    DownObject.bigStep++;
  }
  public void AnipChange3()
  {
    anim.clip = clip4;
    DownObject.bigStep++;
  }
  public void AnipChange4()
  {
    anim.clip = clip1;
    DownObject.bigStep++;
  }
}