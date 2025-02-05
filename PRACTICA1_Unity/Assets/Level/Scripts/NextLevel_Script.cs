using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel_Script : MonoBehaviour
{
    public GameManager_Script GameManager;
    public Animator animator;
    IEnumerator SceneChanger()
    {
        FadeToLevel();
        yield return new WaitForSeconds(2f);
        loadNextLevel();
    }
    void loadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    // Start is called before the first frame update
    void Awake()
    {
        GameManager = GameObject.FindObjectOfType<GameManager_Script>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //si el objecte que fa collide amb el trigger de Next Level es el "Player", va al nivell de Index+1
        if (collision.CompareTag("Player"))
        {
            //loadNextLevel();
            StartCoroutine(SceneChanger());
            FadeToLevel();

        }
    }
}