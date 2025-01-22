using UnityEngine;
using UnityEngine.UI;

public class TextPos : MonoBehaviour
{
  public string txt1;
  public string txt2;
  public string txt3;
  public string txt4;
  public string txt5;
  public string txt6;
  public string txt7;
  public string txt8;
  public string txt9;
  public string txt10;
  public string txt11;
  public string txt12;
  public string txt13;
  public string txt14;

  public Text txt;

  public void Update()
  {
    switch (DownObject.bigStep)
    {
      case 1:
        txt.text = txt1;
        break;
      case 2:
        txt.text = txt2;
        break;
      case 3:
        txt.text = txt3;
        break;
      case 4:
        txt.text = txt4;
        break;
      case 5:
        txt.text = txt5;
        break;
      case 6:
        txt.text = txt6;
        break;
      case 7:
        txt.text = txt7;
        break;
      case 8:
        txt.text = txt8;
        break;
      case 9:
        txt.text = txt9;
        break;
      case 10:
        txt.text = txt10;
        break;
      case 11:
        txt.text = txt11;
        break;
      case 12:
        txt.text = txt12;
        break;
      case 13:
        txt.text = txt13;
        break;
      case 14:
        txt.text = txt14;
        break;
      default:
        break;
    }
  }
}