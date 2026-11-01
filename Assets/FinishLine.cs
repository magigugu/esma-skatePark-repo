using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public Text finishText;

    private bool gameFinished = false;

    private void Start()
    {
        finishText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Skateboard" && !gameFinished)
        {
            gameFinished = true;

            finishText.gameObject.SetActive(true);

            Debug.Log("YOU FINISHED THE GAME!");

            Time.timeScale = 0f;
        }
    }
}

