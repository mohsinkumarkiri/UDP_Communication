using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PageSwitcher : MonoBehaviour
{
    public static PageSwitcher instance;
    public List<GameObject> pageList;
    private int buttonClickCount = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        buttonClickCount = 0;
        switchPages(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void switchPages(int pageIndex)
    {
        foreach (GameObject page in pageList)
        {
            page.SetActive(false);
        }
        pageList[pageIndex].SetActive(true);
    }

    public void switchSettingPage(int pageIndex)
    {
        buttonClickCount++;
        if (buttonClickCount == 5)
        {
            foreach (GameObject page in pageList)
            {
                page.SetActive(false);
            }
            pageList[pageIndex].SetActive(true);
            buttonClickCount = 0;
        }
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
