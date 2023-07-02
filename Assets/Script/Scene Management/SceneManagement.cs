using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
  
    
    public GameObject loadingScreen;
    public Slider loadingSlider;
    
    public void LoadLevel(int lvl)
    {
        StartCoroutine(LoadAsync(lvl));
    }

    IEnumerator LoadAsync(int lvl)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(lvl);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;

            yield return null;
        }
    }

   
}
