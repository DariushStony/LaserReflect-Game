using UnityEngine;

public class ChangeParent_Level14 : MonoBehaviour
{
    private int childrenCount;

    void Start()
    {
        childrenCount = gameObject.transform.parent.childCount;
    }

    void ChangeParent()
    {
        if (gameObject.transform.parent.childCount < childrenCount)
        {
            gameObject.transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ChangeParent();
    }
}
