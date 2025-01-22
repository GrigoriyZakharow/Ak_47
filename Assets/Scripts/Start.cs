using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
  public void Reload()
  {
    ReadResult.res.Clear();
    SceneManager.LoadScene(0);
    UnityEngine.Time.timeScale = 1f;
    DownObject.bigStep = 1;
    Time.flag = false;
    Time.flagSave = false;
  }
}