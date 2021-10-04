using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Screen.SetResolution(1024, 576, false);
        yield return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            LoadGame();
        if (Input.GetKey(KeyCode.Q))
            QuitGame();
    }

    private IEnumerator WaitUntilFrameLoad()
    {
        yield return new WaitForEndOfFrame();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
