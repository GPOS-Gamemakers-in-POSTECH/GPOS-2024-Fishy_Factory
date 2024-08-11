using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowInteraction : MonoBehaviour
{
    public Transform player;
    public float interactionDistance = 1.5f;
    public KeyCode interactionKey = KeyCode.E;
    
    // save the name of departureMap to choose the correct position of player
    public static string departureMap;

    [SerializeField] 
    private string sceneName; // select scene to move into

    public Image fadeImage;
    private float fadeDuration = 1f;
    
    void Start()
    {
        // fade in
        StartCoroutine(FadeFunction(1f));
    }

    void Update()
    {
        // calculate distance between player and arrow
        float distance = Vector3.Distance(player.position, transform.position);

        // if close enough, change scene when press E
        if(distance <= interactionDistance )
        {
            //Debug.Log("Close Enough to Interact");
            if (Input.GetKeyDown(interactionKey))
            {
                StartCoroutine(FadeAndLoadScene());
            }
        }
    }

    IEnumerator FadeAndLoadScene()
    {
        // fade out
        yield return StartCoroutine(FadeFunction(0f));

        // save the departureMap name
        departureMap = SceneManager.GetActiveScene().name;
        Debug.Log("departure map is : " + departureMap);
        
        // load the new scene
        SceneManager.LoadScene(sceneName);


    }

    IEnumerator FadeFunction(float index) // 0 : fade out, 1 : fade in
    {
        float elapsedTIme = 0f;
        Color color = fadeImage.color;
        while (elapsedTIme < fadeDuration)
        {
            elapsedTIme += Time.deltaTime;
            color.a = Mathf.Lerp(index, 1f - index, elapsedTIme / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
    }
}