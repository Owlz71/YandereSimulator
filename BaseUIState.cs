using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseUIState : MonoBehaviour
{
    [SerializeField]
    protected UIDocument _document;
    public AudioSource audioSource;

    protected UIStateMachine _UIStateMachine;
    private List<Button> _buttons;

    public virtual void Start()
    {
        _UIStateMachine = UIManager.Instance._UIStateMachine;
        if (audioSource == null)
            Debug.Log("AudioSource is not assigned in BaseUIState. Please assign it in the inspector.");

    }
    public virtual void Awake()
    {
        _document = GetComponent<UIDocument>();

        _buttons = _document.rootVisualElement.Query<Button>().ToList();
        foreach (Button button in _buttons)
        {
            button.RegisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }

    public virtual void OnDisable()
    {

        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].UnregisterCallback<ClickEvent>(OnAllButtonsClick);
        }
    }



    private void OnAllButtonsClick(ClickEvent evt)
    {
        audioSource.Play();
    }
}
