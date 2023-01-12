using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    #region Private Fields
    //Serialized
    [SerializeField] private string[] _scenesToLoad;
    //Non-Serialized
    #endregion Private Fields

    #region Public Fields
    #endregion Public Fields

    #region Monobehavior Methods

    private void Start()
    {
        StartCoroutine(LoadScenes());
    }

    #endregion Monobehavior Methods

    #region Private Methods

    /// <summary>
	/// Checks if a scene is loaded
	/// </summary>
	/// <param name="i_nameOfSceneToCheck"></param>
	/// <returns></returns>
	private bool CheckIfSceneIsLoaded(string i_nameOfSceneToCheck)
    {
        bool sceneIsLoaded = false;

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == i_nameOfSceneToCheck)
            {
                sceneIsLoaded = true;
            }
        }

        return sceneIsLoaded;
    }

    /// <summary>
    /// Loads sincle scene by name
    /// </summary>
    /// <param name="i_scene"></param>


    #endregion Private Methods

    #region Public Methods
    #endregion Public Methods

    #region Coroutines

    /// <summary>
    /// Loads the designated scenes
    /// </summary>
    /// <param name="i_sceneToLoad"></param>
    /// <returns></returns>
    private IEnumerator LoadScenes()
    {
        List<string> loadedSceneNames = new List<string>();

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            loadedSceneNames.Add(SceneManager.GetSceneAt(i).name);
        }

        for (int i = 0; i < _scenesToLoad.Length; i++)
        {
            string sceneToLoad = _scenesToLoad[i];
            yield return StartCoroutine(LoadSingleScene(sceneToLoad));
        }
    }

    private IEnumerator LoadSingleScene(string i_scene)
    {
        if (!CheckIfSceneIsLoaded(i_scene))
        {
            Debug.Log($"Loading Scene: {i_scene}");
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(i_scene, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            Debug.Log($"Loaded Scene Async: {i_scene}");
        }
    }

    #endregion Coroutines

    #region Events

    /// <summary>
    /// Callback for event for loading new scene
    /// </summary>
    /// <param name="i_args"></param>
    public void OnLoadNewScene(string i_args)
    {
        StartCoroutine(LoadSingleScene(i_args));
    }

    #endregion Events
}
