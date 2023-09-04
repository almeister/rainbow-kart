using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
  private TextMeshProUGUI lapCounterText;
  private int laps = 1;
  private int checkpointsPassed = 0;

  void Start()
  {
    GameObject lapCounter = GameObject.Find("LapCounter");
    lapCounterText = lapCounter.GetComponent<TextMeshProUGUI>();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.name.Equals("StartFinishLine") && checkpointsPassed.Equals(5))
    {
      checkpointsPassed = 0;
      laps += 1;
      if (laps.Equals(4))
      {
        lapCounterText.SetText("Finished!!");
      }
      else
      {
        lapCounterText.SetText(laps.ToString());
      }
    }
    else if (other.name.StartsWith("AICheckpoint"))
    {
      var splitName = other.name.Split('-');
      var checkpointNumber = int.Parse(splitName[splitName.Length - 1]);

      Debug.Log($"Checkpoint {checkpointNumber} passed.");

      if (checkpointNumber == (checkpointsPassed + 1))
      {
        checkpointsPassed = checkpointNumber;
        Debug.Log($"Checkpoints passed: {checkpointsPassed}.");
      }
    }

  }
}
