using UnityEngine;

public class Viwe : MonoBehaviour
{

  public Animation animCam;
  public Animation ak;
  public GameObject btn1;
  public GameObject btn2;

  public void Anim()
  {
    btn1.SetActive(false);
    btn2.SetActive(true);
    animCam.Play("Camera1");
    ak.Play("1");
  }

  public void AnimBack()
  {
    btn2.SetActive(false);
    btn1.SetActive(true);
    animCam.Play("Camera2");
    ak.Play("2");
  }
}