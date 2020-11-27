using UnityEngine;
public class BoxCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Destroyer_Box")
        {
            Destroy(gameObject);
        }
    }
}
