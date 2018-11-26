using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Event_Die : MonoBehaviour
{
    [Header("触发Die事件，然后整个GameObject死亡")]
    public UnityEvent _Die;

    [ContextMenu("Die")]
    public void Die()
    {
        _Die.Invoke();
        Destroy(gameObject);
    }
}
