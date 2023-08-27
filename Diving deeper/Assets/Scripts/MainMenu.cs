using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void PlayGame()
    {
        StartCoroutine(WaitForLoadCompletion());
    }

    public void ExitGame()
    {
        Debug.Log("Quits Game");
        Application.Quit();
    }

    private IEnumerator WaitForLoadCompletion()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Tileset", LoadSceneMode.Single);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // You can display a loading progress bar or other UI here
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Normalize progress (0.9 is the point when the scene is almost loaded)
            Debug.Log("Loading Progress: " + (progress * 100) + "%");

            // If the scene is almost loaded, activate it to complete the transition
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
