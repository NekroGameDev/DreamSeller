using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float smoothBlackout;
    [SerializeField] private bool isBlackoutOnStart;
    [SerializeField] private Image loadingScreen;
    [SerializeField] private UnityEvent onStartLoading;

    private void Start()
    {
        if (isBlackoutOnStart)
        {
            loadingScreen.gameObject.SetActive(true);
            StartCoroutine(Blackout());
        }
    }

    public void LoadScene(int m_sceneIndex)
    {
        loadingScreen.gameObject.SetActive(true);
        StartCoroutine(LoadSceneAsync(m_sceneIndex));
    }

    private IEnumerator LoadSceneAsync(int m_sceneIndex)
    {
        if (smoothBlackout < 0.1f) { smoothBlackout = 0.1f; }

        while (loadingScreen.color.a < 1)
        {
            loadingScreen.color = new Color(loadingScreen.color.r, loadingScreen.color.g, loadingScreen.color.b, loadingScreen.color.a + 1 * smoothBlackout);
            yield return null;
        }

        AsyncOperation m_operation = SceneManager.LoadSceneAsync(m_sceneIndex);

        while (!m_operation.isDone)
        {
            float m_progress = Mathf.Clamp01(m_operation.progress / 0.9f);
            //loadingBar.value = m_progress;

            yield return null;
        }
    }

    private IEnumerator Blackout()
    {
        if (smoothBlackout < 0.1f) { smoothBlackout = 0.1f; }

        while (loadingScreen.color.a > 0)
        {
            loadingScreen.color = new Color(loadingScreen.color.r, loadingScreen.color.g, loadingScreen.color.b, loadingScreen.color.a - 1 * smoothBlackout);
            yield return null;
        }
    }
}
