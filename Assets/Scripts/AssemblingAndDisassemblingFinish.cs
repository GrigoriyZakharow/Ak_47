using UnityEngine;

public class AssemblingAndDisassemblingFinish : MonoBehaviour {

  public Animation animationAk;
  public ButtonManager buttonManager;

  private void Update() {
    if (animationAk.isPlaying is false) {
      switch (buttonManager.StateAk) {
        case StateAk.EndOfAssembly:
        case StateAk.EndOfDisassembly:
          buttonManager.DisassamblyOnTime();
          break;
      }
    }
  }
}