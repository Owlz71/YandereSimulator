using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cinemachine;
using UnityEngine.Rendering;

public class EroSystemUI : BaseUIState
{
    [SerializeField]
    private GameObject character;
    public List<GameObject> characters;
    [SerializeField]
    private GameObject player;
    public GameObject mainCam;
    public GameObject eroCam;


    // UI Buttons
    private List<Button> PoseButtons;

    private Button FirstPersonViewButton;
    private Button ThirdPersonViewButton;

    private Button PrevCharacterButton;
    private Button NextCharacterButton;

    public override void Awake()
    {
        base.Awake();


        // Pose��ť
        PoseButtons = new List<Button>
        {
            _document.rootVisualElement.Q<Button>("Pose1"),
            _document.rootVisualElement.Q<Button>("Pose2"),
            _document.rootVisualElement.Q<Button>("Pose3")
        };
        for (int i = 0; i < PoseButtons.Count; i++)
        {
            var button = PoseButtons[i];
            int capturedID = i + 1; // ��1��ʼ��ţ�ÿ����ť��Ӧһ������ ID

            if (button == null)
            {
                Debug.LogError($"Pose button {i + 1} not found in the UI Document.");
                continue;
            }

            button.RegisterCallback<ClickEvent>(evt =>
            {
                Debug.Log($"Pose Button {capturedID} Clicked");
                character.GetComponent<Animator>().SetInteger("ani_id", capturedID);
            });
        }


        //View��ť
        FirstPersonViewButton = _document.rootVisualElement.Q("FirstPersonView") as Button;
        FirstPersonViewButton.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("First Person View Button Clicked");
        });

        ThirdPersonViewButton = _document.rootVisualElement.Q("ThirdPersonView") as Button;
        ThirdPersonViewButton.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("Third Person View Button Clicked");
            eroCam.GetComponent<CinemachineFreeLook>().Follow = character.transform;
            eroCam.GetComponent<CinemachineFreeLook>().LookAt = character.transform;
        });

        //��ɫ�л�
        PrevCharacterButton = _document.rootVisualElement.Q<Button>("PrevCharacter");
        PrevCharacterButton.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("Previous Character Button Clicked");
        });

        NextCharacterButton = _document.rootVisualElement.Q<Button>("NextCharacter");
        NextCharacterButton.RegisterCallback<ClickEvent>(evt =>
        {
            Debug.Log("Next Character Button Clicked")
        });
    }

    public override void Start()
    {
        base.Start();
        character.GetComponent<Animator>().SetTrigger("ero");
        //player.GetComponent<PlayerMove>().enabled=false;
        player.gameObject.SetActive(false);
        eroCam.SetActive(true);
        mainCam.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed, changing state to Main");
            _UIStateMachine.ChangeState(UIStateMachine.UIState.Main);
        }
    }
    public virtual void OnDisable()
    {
        base.OnDisable();
        //�ָ����
        player.gameObject.SetActive(true);
        eroCam.SetActive(false);
        mainCam.SetActive(true);
    }

}
