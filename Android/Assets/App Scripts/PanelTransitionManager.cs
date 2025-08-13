using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

public class PanelTransitionManager : MonoBehaviour
{
    public GameObject[] panels; // Assign your panels here
    public List<GameObject> items = new List<GameObject>();
    public float fadeTime = 1f;
    public float transitionDuration = 0.5f; // Duration of the transition

    private GameObject currentPanel;

    private void Start()
    {
        // Ensure only the first panel is active at the start
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        if (panels.Length > 0)
        {
            currentPanel = panels[0];
            currentPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) StartCoroutine("itemsAnimation");
    }

    public void SwitchToPanel(int panelIndex)
    {
        if (panelIndex < 0 || panelIndex >= panels.Length || panels[panelIndex] == currentPanel)
            return;

        GameObject nextPanel = panels[panelIndex];
        AnimatePanelTransition(currentPanel, nextPanel);
        
    }

    private void AnimatePanelTransition(GameObject fromPanel, GameObject toPanel)
    {
        // Disable interaction during transition
        CanvasGroup fromCanvasGroup = fromPanel.GetComponent<CanvasGroup>() ?? fromPanel.AddComponent<CanvasGroup>();
        CanvasGroup toCanvasGroup = toPanel.GetComponent<CanvasGroup>() ?? toPanel.AddComponent<CanvasGroup>();

        fromCanvasGroup.interactable = false;
        toCanvasGroup.interactable = false;

        toPanel.SetActive(true);

        // Fade out the current panel
        fromCanvasGroup.DOFade(0, transitionDuration).OnComplete(() =>
        {
            fromPanel.SetActive(false);
            fromCanvasGroup.alpha = 1; // Reset alpha for future transitions
        });

        // Fade in the new panel
        toCanvasGroup.alpha = 0; // Start from transparent
        toCanvasGroup.DOFade(1, transitionDuration).OnComplete(() =>
        {
            currentPanel = toPanel;
            toCanvasGroup.interactable = true;
        });
    }

    IEnumerator itemsAnimation()
    {
        foreach (var item in items)
        {
            item.transform.localPosition = Vector3.zero;
        }

        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
