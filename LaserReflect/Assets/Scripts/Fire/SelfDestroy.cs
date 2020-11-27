
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float Time;

    void Update()
    {
        Destroy(gameObject, Time);
    }
}
