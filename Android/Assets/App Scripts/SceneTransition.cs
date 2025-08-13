using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    public PageSwitcher pageSwitcherINS;
    public Animator transitionAnim;
    public int pageIndex;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(loadPage());
        }
    }

    IEnumerator loadPage()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        pageSwitcherINS.switchPages(1);
        
    }
}
