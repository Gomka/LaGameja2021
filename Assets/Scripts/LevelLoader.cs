using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator animator;
    private Transform player;
    [SerializeField] private bool hasPlayer = true;

    private void Awake()
    {
        if(hasPlayer)
        {
            player = FindObjectOfType<InputHandler>().gameObject.transform;

            LoadCurrentCoords(SceneManager.GetActiveScene().name);
        } 
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadScene(levelName));
    }

    IEnumerator LoadScene(string levelName)
    {
        if(hasPlayer) SaveCurrentCoords(SceneManager.GetActiveScene().name);
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelName);
    }

    private void SaveCurrentCoords(string sceneName)
    {
        PlayerPrefs.SetFloat(sceneName + "X", player.position.x);
        PlayerPrefs.SetFloat(sceneName + "Y", player.position.y);
        PlayerPrefs.SetFloat(sceneName + "Z", player.position.z);
    }

    private void LoadCurrentCoords(string sceneName)
    {
        if(PlayerPrefs.GetInt(sceneName) == -5)
        {
            player.position = new Vector3(PlayerPrefs.GetFloat(sceneName + "X"), PlayerPrefs.GetFloat(sceneName + "Y"), PlayerPrefs.GetFloat(sceneName + "Z"));
        } 
        else
        {
            PlayerPrefs.SetInt(sceneName, -5);
        }

    }
}
