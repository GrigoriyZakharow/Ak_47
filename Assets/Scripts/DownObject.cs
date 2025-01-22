using System.Collections.Generic;
using UnityEngine;

public class DownObject : MonoBehaviour
{
  public Animation error;
  public Animation errorText;
  public Animation anim;
  public int step;
  public int step1;
  public int step2;
  public List<Collider> col;

  public static int bigStep;

  public DownObject()
  {
    step = step1;
  }

  static DownObject()
  {
    bigStep = 1;
  }

  private void Update()
  {
    if(UnityEngine.Time.timeScale != 0.75f)
    {
      if (step == 4 && bigStep == step)
      {
        for (int i = 0; i < col.Count; i++)
        {
          col[i].enabled = true;
        }
      }
      else if (step == 6 && bigStep == step)
      {
        for (int i = 0; i < col.Count; i++)
        {
          col[i].enabled = true;
        }
      }
    }
  }

  private void OnMouseDown()
  {
    if (UnityEngine.Time.timeScale != 0.75f && !ButtonStart.flagStart)
    {
      if (!Time.flag)
      {
        Time.flag = true;
      }
      if (step == bigStep)
      {
        anim.Play();
        if (step == step1)
        {
          step = step2;
        }
        else
        {
          step = step1;
        }
      }
      else
      {
        error.Play();
        errorText.Play();
        gameObject.GetComponent<Outline>().OutlineColor = Color.red;
        Invoke("Whi", 0.5f);
      }
    }
  }

  private void Whi()
  {
    gameObject.GetComponent<Outline>().OutlineColor = Color.white;
  }
}