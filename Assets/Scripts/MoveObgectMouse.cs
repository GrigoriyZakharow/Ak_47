using UnityEngine;

public class MoveObgectMouse : MonoBehaviour
{
  public GameObject btn1;
  public GameObject btn2;
  public Camera camer;
  public GameObject backObject; 

  void Update()
  {
    if(UnityEngine.Time.timeScale != 0.75f && !ButtonStart.flagStart)
    {
      if (backObject != null)
      {
        backObject.GetComponent<Outline>().OutlineWidth = 0;
      }
      Ray ray = camer.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      if (Physics.Raycast(ray, out hit, 100))
      {
        if (hit.collider.gameObject.GetComponent<Outline>())
        {
          hit.collider.gameObject.GetComponent<Outline>().OutlineWidth = 3;
          backObject = hit.collider.gameObject;
        }
      }
    }
  }

  public void Nul1()
  {
    btn1.SetActive(false);
    btn2.SetActive(false);
  }

  public void Nul2()
  {
    btn1.SetActive(true);
    btn2.SetActive(true);
  }

  public void Meth()
  { 
    gameObject.GetComponent<MouseViwe>().enabled = true;
  }

  public void Meth2()
  {
    gameObject.GetComponent<MouseViwe>().enabled = false;
  }
}