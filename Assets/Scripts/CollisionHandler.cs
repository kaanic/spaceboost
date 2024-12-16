using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Alright then.");
                break;
            case "Finish":
                LoadNextScene();
                break;
            case "Fuel":
                Debug.Log("Fueled.");
                break;
            default:
                ReloadLevel();
                break;
        }

        void LoadNextScene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;

            int nextScene = currentScene + 1;
            if (nextScene == SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }

            SceneManager.LoadScene(nextScene);
        }

        void ReloadLevel()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
}
