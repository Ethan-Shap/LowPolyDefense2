using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Text.RegularExpressions;

public class SceneManagement : MonoBehaviour {	

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

	public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static int CurrentLevelNumber()
    {
        int level = -1;
        int.TryParse(Regex.Replace(SceneManager.GetActiveScene().name, @"\D", string.Empty), out level);
        return level;
    }

    public static string CurrentLevelName()
    {
        return SceneManager.GetActiveScene().name;
    }
}