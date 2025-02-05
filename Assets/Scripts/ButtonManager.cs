using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

  private int step;
  private int index = 0;
  private StateAk stateAk = StateAk.Assembled;
  private TwoWayQueue twoWayQueue = new TwoWayQueue();

  public int Step {
    get => step;
    set {
      if (step >= 0 && step <= 7) step = value;
    }
  }
  public StateAk StateAk {
    get => stateAk;
    set {
      if(value == StateAk.EndOfAssembly || value == StateAk.EndOfDisassembly) stateAk = value;
    }
  }

  public Animation animationAk;
  public Text textWarningPanel;
  public Text textButtonDisassamblyOnTime;
  public Text textButtonAssemblyDisassemnly;
  public GameObject panel;
  public GameObject warningPanel;
  public GameObject disassemblyTrainingButton;
  public GameObject disassemblingStepTraining;
  public TimerManager timerManager;

  private void DisassemblyAndAssembly() {
    switch (stateAk) {
      case StateAk.Assembled:
        ChangeTextButtonAssemblyDisassembly("Assembly on time", "DefaultState2");
        break;
      case StateAk.Disassembled:
        ChangeTextButtonAssemblyDisassembly("Disassembly on time", "DefaultState");
        break;
      default:
        ExceptionHandling();
        break;
    }
  }

  public void DisassamblyOnTime() {
    switch (stateAk) {
      case StateAk.Assembled:
        StartAssemblingDisassembling(StateAk.BeingDisassembled, 1);
        break;
      case StateAk.Disassembled:
        StartAssemblingDisassembling(StateAk.BeingCollected, 6);
        break;
      case StateAk.BeingDisassembled:
        AbortAssemblingDisassembling("Disassembly on time");
        break;
      case StateAk.BeingCollected:
        AbortAssemblingDisassembling("Assembly on time");
        break;
      case StateAk.EndOfDisassembly:
        FinishAssemblingDisassembling("Assembly on time");
        break;
      case StateAk.EndOfAssembly:
        FinishAssemblingDisassembling("Disassembly on time");
        break;
      default:
        ExceptionHandling();
        break;
    }
  }

  private void DisassemblyTraining() {
    switch (stateAk) {
      case StateAk.Assembled:
        NewListAnim();
        disassemblyTrainingButton.SetActive(false);
        disassemblingStepTraining.SetActive(true);
        stateAk = StateAk.UnderStudy;
        break;
      default:
        ExceptionHandling();
        break;
    }
  }

  private void ExitTraining() {
    panel.SetActive(false);
    disassemblyTrainingButton.SetActive(true);
    disassemblingStepTraining.SetActive(false);
    stateAk = StateAk.Assembled;
    animationAk.Play("DefaultState");
  }

  private void ExitTooltipPanel() {
    panel.SetActive(false);
  }

  private void ExitWarningPanel() {
    warningPanel.SetActive(false);
  }

  private void NextStepDisassembly() {
    if (index != twoWayQueue.count && animationAk.isPlaying is false) {
      string containerString = twoWayQueue.RemoveFirst();
      animationAk[containerString].speed = 1f;
      animationAk[containerString].time = 0f;
      animationAk.Play(containerString);
      twoWayQueue.AddLast(containerString);
      index++;
    }
  }

  private void BackStepDisassembly() {
    if (index > 0 && animationAk.isPlaying is false) {
      string containerString = twoWayQueue.RemoveLast();
      animationAk[containerString].time = animationAk[containerString].length;
      animationAk[containerString].speed = -1f;
      animationAk.Play(containerString);
      twoWayQueue.AddFirst(containerString);
      index--;
    }
  }

  private void NewListAnim() {
    index = 0;
    twoWayQueue.Clear();

    for (int i = 1; i < 7; i++) {
      twoWayQueue.AddLast($"Animation{i}");
    }
  }

  private void ChangeTextButtonAssemblyDisassembly(string text, string nameAnimationAk) {
    ChangeStateAk();
    animationAk.Play(nameAnimationAk);
    ChangeTextButton(textButtonAssemblyDisassemnly);
    ChangeTextButton(textButtonDisassamblyOnTime, text);
  }

  private void StartAssemblingDisassembling(StateAk state, int value) {
    step = value;
    timerManager.LaunchedTimer();
    stateAk = state;
    ChangeTextButton(textButtonDisassamblyOnTime, "Stop");
  }

  private void AbortAssemblingDisassembling(string text) {
    NewListAnim();
    timerManager.ResetTimer();
    animationAk.Play("DefaultState");
    ChangeStateAk();
    ChangeTextButton(textButtonDisassamblyOnTime, text);
  }

  private void FinishAssemblingDisassembling(string text) {
    timerManager.StoppedTimer();
    ChangeStateAk();
    ChangeTextButton(textButtonAssemblyDisassemnly);
    ChangeTextButton(textButtonDisassamblyOnTime, text);
  }

  private void ExceptionHandling() {
    warningPanel.SetActive(true);

    switch (stateAk) {
      case StateAk.Assembled:
        textWarningPanel.text = "The Kalashnikov assault rifle is now assembled.";
        break;
      case StateAk.Disassembled:
        textWarningPanel.text = "The Kalashnikov assault rifle is now disassembled.";
        break;
      case StateAk.BeingDisassembled:
        textWarningPanel.text = "The Kalashnikov assault rifle is currently being disassembled.";
        break;
      case StateAk.BeingCollected:
        textWarningPanel.text = "The Kalashnikov assault rifle is currently in the assembly stage.";
        break;
      case StateAk.UnderStudy:
        textWarningPanel.text = "The Kalashnikov assault rifle is currently under study.";
        break;
    }
  }

  private void ChangeStateAk() {
    switch (stateAk) {
      case StateAk.EndOfDisassembly:
      case StateAk.Assembled:
        stateAk = StateAk.Disassembled;
        break;
      case StateAk.BeingCollected:
      case StateAk.BeingDisassembled:
      case StateAk.EndOfAssembly:
      case StateAk.Disassembled:
        stateAk = StateAk.Assembled;
        break;
    }
  }

  private void ChangeTextButton(Text textButton, string text = "") {
    switch (textButton.text) {
      case "Assembly":
        textButton.text = "Disassembly";
        break;
      case "Disassembly":
        textButton.text = "Assembly";
        break;
      default:
        textButton.text = text;
        break;
    }
  }
}