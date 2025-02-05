using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAndHoverDetail : MonoBehaviour {

  private Outline containerOutline;
  private Outline previousObjectOutline;
  private StateOutline stateOutline = StateOutline.White;

  public int step;
  public string descriptionDetail;
  public AnimationClip clip;
  public Animation animationAk;
  public Animation animationDetail;
  public ButtonManager buttonManager;
  public GameObject Panel;
  public Text textDescription;

  private void Update() {
    if(PanelsIsNotActive() is true) {
      if (buttonManager.StateAk != StateAk.Assembled && buttonManager.StateAk != StateAk.Disassembled) {

        if (previousObjectOutline is not null) {
          previousObjectOutline.OutlineWidth = 0;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
          containerOutline = hit.collider.gameObject.GetComponent<Outline>();
          if (stateOutline == StateOutline.White) {
            containerOutline.OutlineWidth = 0.2f;
            previousObjectOutline = containerOutline;
          }
          else if (stateOutline == StateOutline.Red) {
            animationDetail.Play();
            stateOutline = StateOutline.White;
          }
        }
      }
      else {
        if (previousObjectOutline is not null) {
          previousObjectOutline.OutlineWidth = 0;
        }
      }
    }
  }

  private void OnMouseDown() {
    if(PanelsIsNotActive() is true) {
      if (buttonManager.StateAk == StateAk.UnderStudy) {
        textDescription.text = descriptionDetail;
        Panel.SetActive(true);
      }
      ChangeStepAnim(buttonManager.StateAk);
    }
  }

  private void ChangeStepAnim(StateAk state) {
    if (buttonManager.Step == step && animationAk.isPlaying is false) {
      switch(state) {
        case StateAk.BeingDisassembled:
          buttonManager.Step += 1;
          animationAk.clip = clip;
          animationAk[clip.name].time = 0;
          animationAk[clip.name].speed = 1f;
          break;
        case StateAk.BeingCollected:
          buttonManager.Step -= 1;
          animationAk.clip = clip;
          animationAk[clip.name].time = animationAk[clip.name].length;
          animationAk[clip.name].speed = -1f;
          break;
      }
      animationAk.Play();
      switch(buttonManager.Step) {
        case 0:
          buttonManager.StateAk = StateAk.EndOfAssembly;
          break;
        case 7:
          buttonManager.StateAk = StateAk.EndOfDisassembly;
          break;
      }
    }
    else {
      stateOutline = StateOutline.Red;
    }
  }

  private bool PanelsIsNotActive() => EventSystem.current.IsPointerOverGameObject() is false;
}