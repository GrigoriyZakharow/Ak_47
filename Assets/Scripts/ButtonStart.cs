using UnityEngine;

public class ButtonStart : MonoBehaviour
{
  public GameObject btn1;
  public GameObject btn2;
  public static bool flagStart;
  public GameObject img;
  public GameObject btn;

  public void Start()
  {
    flagStart = true;
  }
  
  public void Go()
  {
    flagStart = false;
    img.SetActive(true);
    btn.SetActive(true);
    gameObject.SetActive(false);
    btn1.SetActive(false);
    btn2.SetActive(false);
  }
}