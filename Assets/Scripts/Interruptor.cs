using UnityEngine;
using UnityEngine.Events;

public class Interruptor : MonoBehaviour
{
    [SerializeField]
    private UnityEvent actions;

    public void Activate()
    {
        actions.Invoke();
    }
}
