
using UnityEngine;
using UnityEngine.UI;

public abstract class TriggerableBase : MonoBehaviour
{
    public abstract void OnStart(bool success);
    public abstract void OnCanContinueToNextObject();

    public abstract void ContinueToNextObject(bool success);

    public KeyCode FirstKey;
    public Text TxtKey;
}
