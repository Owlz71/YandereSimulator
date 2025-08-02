using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class EroSystemUI : BaseUIState
{
    [SerializeField]
    GameObject character;

    private Button PoseButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed, changing state to Main");
            _UIStateMachine.ChangeState(UIStateMachine.UIState.Main);
        }

    }
    public virtual void Awake()
    {
        base.Awake();
        // = _document.rootVisualElement.Q("AnimationButton") as Button;

        //character.GetComponent<Animator>().SetInteger("ani_id", ani_id);
    }

    private void OnEroSystemClick(ClickEvent evt)
    {
        Debug.Log("Animation System Button Clicked");
        _UIStateMachine.ChangeState(UIStateMachine.UIState.EroSystem);
    }

}