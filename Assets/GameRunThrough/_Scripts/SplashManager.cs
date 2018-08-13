using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SplashManager : MonoBehaviour
{
    public string timeTillLoad;
    public Text timeTillLoadGuiText;

    private bool stuffIsLoaded;
    // Use this for initialization
    void Start()
    {
        this.stuffIsLoaded = false;
        StartCoroutine(DoBuisness());
    }

    IEnumerator DoBuisness()
    {
        yield return new WaitForSeconds(5);
        this.stuffIsLoaded = true;
        this.timeTillLoadGuiText.text = (5 - Time.timeSinceLevelLoad).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.stuffIsLoaded)
        {
			MoveOnToNextScene();
        }
    }



    void MoveOnToNextScene()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

    }
}
