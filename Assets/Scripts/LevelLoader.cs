using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadScene(levelName));
    }

    IEnumerator LoadScene(string levelName)
    {
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(levelName);
    }
}
