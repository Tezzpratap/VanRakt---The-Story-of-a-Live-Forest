using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneTransition : MonoBehaviour
{
	[SerializeField] private string defaultSceneName = "GameScene";
	[SerializeField] private float transitionDelay;

	public void LoadDefaultScene()
	{
		LoadScene(defaultSceneName);
	}

	public void LoadScene(string sceneName)
	{
		if (string.IsNullOrWhiteSpace(sceneName))
			return;

		StartCoroutine(LoadSceneAfterDelay(sceneName));
	}

	public void LoadSceneByIndex(int sceneIndex)
	{
		StartCoroutine(LoadSceneByIndexAfterDelay(sceneIndex));
	}

	public void ReloadCurrentScene()
	{
		LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
	}

	/// <summary>
	/// Exits the game. Wire this to the Exit button on the Landing Page.
	/// Works in both the Unity Editor and built applications.
	/// </summary>
	public void ExitGame()
	{
		Debug.Log("ExitGame() called. Quitting application...");

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}

	private IEnumerator LoadSceneAfterDelay(string sceneName)
	{
		Time.timeScale = 1f;

		if (transitionDelay > 0f)
			yield return new WaitForSeconds(transitionDelay);

		SceneManager.LoadScene(sceneName);
	}

	private IEnumerator LoadSceneByIndexAfterDelay(int sceneIndex)
	{
		Time.timeScale = 1f;

		if (transitionDelay > 0f)
			yield return new WaitForSeconds(transitionDelay);

		SceneManager.LoadScene(sceneIndex);
	}
}
