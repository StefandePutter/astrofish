using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnd : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.CompareTag("Player")) 
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
