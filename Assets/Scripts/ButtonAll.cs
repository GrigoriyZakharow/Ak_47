using UnityEngine;

public class ButtonAll : MonoBehaviour
{
  public Animation anim;
  public GameObject btn;

  public GameObject btn1;
  public GameObject btn2;

  public void Pl1()
  {
    btn1.SetActive(false);
    btn2.SetActive(false);
    anim.Play();
    btn.SetActive(true);
    gameObject.SetActive(false);
  }
}