using UnityEngine;

public class StartAllAnim1 : MonoBehaviour
{
  public Animation anim;

  public Animation anim1;
  public Animation anim2;
  public Animation anim3;
  public Animation anim4;
  public Animation anim5;
  public Animation anim6;
  public Animation anim7;

  public AnimationClip clp1;
  public AnimationClip clp2;

  public void Anim1()
  {
    UnityEngine.Time.timeScale = 0.75f;
    anim1.Play();
  }

  public void Anim2()
  {
    anim2.Play();
  }
  public void Anim3()
  {
    anim3.Play();
  }
  public void Anim4()
  {
    anim4.Play();
  }
  public void Anim5()
  {
    anim5.Play();
  }
  public void Anim6()
  {
    anim6.Play();
  }
  public void Anim7()
  {
    anim7.Play();
    if (anim.clip != clp2) anim.clip = clp2;
  }
}