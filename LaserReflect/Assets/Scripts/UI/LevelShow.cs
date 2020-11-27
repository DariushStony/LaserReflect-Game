using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelShow : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = (SceneManager.GetActiveScene().buildIndex).ToString();
    }
}
