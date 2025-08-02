using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UIStateMachine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public UIStateMachine _UIStateMachine;
    //����
    //private UIDocument currentDocument;
    //public UIDocument mainDocument;
    //public UIDocument eroDocument;
    //public UIDocument debugDocument;

    public GameObject currentUI;
    public GameObject eroUI;
    public GameObject debugUI;
    public GameObject mainUI;

    private void Awake()
    {
        Instance = this;
        if (_UIStateMachine == null)
        {
            _UIStateMachine =new UIStateMachine();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            _UIStateMachine.ChangeState(UIStateMachine.UIState.Debug);
        }
    }

    public void HideCurrentUI()
    {
        currentUI.SetActive(false);
    }

    public void ShowCurrentUI(UIState state)
    {
        if (currentUI != null)
        {
            switch (state)
            {
                case UIState.EroSystem:
                    currentUI = eroUI;
                    break;
                case UIState.Main:
                    currentUI = mainUI;
                    break;
                case UIState.Debug:
                    currentUI = debugUI;
                    break;
            }
            currentUI.SetActive(true);
        }
    }
    public void HideAllPanels()
    {
        // �ҵ����������� UIDocument ���
        UIDocument[] allDocuments = FindObjectsOfType<UIDocument>();

        foreach (var doc in allDocuments)
        {
            // ���ö�Ӧ�� GameObject ���ر� UI
            doc.gameObject.SetActive(false);
        }
    }
}
