using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteResult : MonoBehaviour
{
  public GameObject btn1;
  public GameObject btn2;
  public List<GameObject> list;
  public List<Text> txt;

  public void Update()
  {
    if(!Time.flag)
    {
      if(btn2.activeInHierarchy)
      {
        for (int i = 0; i < ReadResult.res.Count; i++)
        {
          txt[i].text = ReadResult.res[i];
          list[i].SetActive(true);
        }
      }
    }
  }

  public void WriteRes()
  {
    for (int i = 0; i < ReadResult.res.Count; i++)
    {
      txt[i].text = ReadResult.res[i];
      list[i].SetActive(true);
    }
    btn2.SetActive(true);
    btn1.SetActive(false);
  }

  public void ActiveResFalse()
  {
    for (int i = 0; i < ReadResult.res.Count; i++)
    {
      list[i].SetActive(false);
    }
    btn1.SetActive(true);
    btn2.SetActive(false);
  }

  public void RemoveTable()
  {
    for (int i = 0; i < ReadResult.res.Count; i++)
    {
      list[i].SetActive(false);
    }
    ReadResult.RemoveResult();
  }
}