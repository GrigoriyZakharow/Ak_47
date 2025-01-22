using System.Collections.Generic;
using UnityEngine;

public class ReadResult : MonoBehaviour
{
  private static int countResult;
  public static List<string> res = new List<string>(0);

  public void Start()
  {
    countResult = PlayerPrefs.GetInt("countResult");
    for (int i = 0; i < countResult; i++)
    {
      res.Add(PlayerPrefs.GetString(string.Format("{0}", i)));
    }
  }

  public static void Add(string value)
  {
    if(res.Count != 7)
    {
      res.Add(value);
    }
    else
    {
      int z = 0;
      string max = res[0];
      for (int i = 0; i < res.Count; i++)
      { 
        if(string.Compare(res[i], max) > 0)
        {
          max = res[i];
          z = i;
        }
      }
      res[z] = value;
    }
    res.Sort();
    countResult = res.Count;
    PlayerPrefs.SetInt("countResult", countResult);
    for (int i = 0; i < res.Count; i++)
    {
      PlayerPrefs.SetString(string.Format("{0}", i), res[i]);
    }
  }

  public static void RemoveResult()
  {
    PlayerPrefs.DeleteAll();
    res.Clear();
  }
}