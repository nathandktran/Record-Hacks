using UnityEngine;
using UnityEngine.SceneManagement;

public class resetManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("reset manager updated");
        
        // if (Input.GetKeyDown(KeyCode.R)) // Change this to your button input
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }

        int reset = GameManager.instance.resetData;

        if (reset == 1) // Change this to your button input
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.instance.gameFinished = 0;
            GameManager.instance.startPlaying = false;
            BeatScroller.hasStarted = false;

        }
    }
}
