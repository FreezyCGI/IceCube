
using UnityEngine;

public abstract class TriggerableBase : MonoBehaviour
{
    public abstract void OnTriggerSuccess();
    public abstract void OnTriggerFailed();
}
