using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public UnityEvent Win,Lose,Tutorial;
    private Rigidbody _rb;
    private int tut;
    public GameObject tutorial;
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        Tutorial.Invoke();
        if (tut == PlayerPrefs.GetInt("DidTutorial"))
        {
            tutorial.SetActive(false);
        }
    }
    public void didTutorial()
    {
       
        PlayerPrefs.SetInt("DidTutorial", 0);
        PlayerPrefs.Save();
        
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Win"))
        {
            Win.Invoke();
            UnlockNewLvl();
        }

        if (collision.gameObject.CompareTag("Lose"))
        {
            Lose.Invoke();
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            _rb.constraints = RigidbodyConstraints.None;
        }
    }
    
    void UnlockNewLvl()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
