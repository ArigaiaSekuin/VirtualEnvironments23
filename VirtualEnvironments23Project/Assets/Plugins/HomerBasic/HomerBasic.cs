using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Homer;
using UnityEngine.Events;

public class HomerBasic : MonoBehaviour
{

    public string HomerProjectNameAndExtension = "homer.json";
    public string FlowName;

    private HomerProject homerProject;
    private HomerFlowRunning runningFlow;

    [Header("Canvas Elements")]

    public Transform FlowCanvas;
    //public TMP_Text FlowTitle;
    public TextMeshProUGUI ActorName;
    public TextMeshProUGUI NodeContentText;
    public Transform Choices;
    public Transform ChoicePrefab;
    public Button NextButton;

    public UnityEvent StartDialogueEvent;
    public UnityEvent EndDialogueEvent;

    // Start is called before the first frame update
    void Start()
    {
        homerProject = HomerJsonParser.LoadHomerProject(HomerProjectNameAndExtension);
        HomerProjectRunning.SetUp(homerProject);

        Debug.Log($"Project Title {homerProject._name}\n");

        InitializeFlow(FlowName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitializeFlow(string flowName)
    {
        foreach (var flow in homerProject._flows)
        {
            if (flow._name == flowName)
            {
                StartDialogueEvent.Invoke();

                runningFlow = HomerFlowRunning.Instantiate(flow);

                runningFlow.SetUp(homerProject);

                FlowCanvas.gameObject.SetActive(true);

                //FlowTitle.text = runningFlow.Flow._name;

                Debug.Log($"\nFlow Title {runningFlow.Flow._name}\n");

                DrawNode();

                break;
            }

        }
    }

    public void DrawNode()
    {
        if (runningFlow.SelectedNode == null)
        {
            //GetContent("THE END");
            NextButton.gameObject.SetActive(false);
            Debug.Log("THE END");
        }
        else
        {
            string nodeType = runningFlow.SelectedNode.GetNodeType();

            if (nodeType == NodeType.choice || nodeType == NodeType.text)
            {
                HomerActor actor = runningFlow.SelectedNode.GetActor();
                ActorName.text = actor._name;
            }

            if (runningFlow.SelectedNode.Node.GetNodeType() == HomerNode.NodeType.CHOICE)
            {
                PrintChoicesContent();
            }
            else if (runningFlow.SelectedNode.Node.GetNodeType() == HomerNode.NodeType.TEXT &&
                     runningFlow.SelectedNode.Node._elements.Length > 0)
            {
                PrintTextContent();
            }
            else
            {
                Next();
            }
        }

    }

    protected void PrintTextContent()
    {
        HomerElement element = runningFlow.SelectedNode.GetTextElement();
        string text = runningFlow.SelectedNode.GetParsedText(element);

        NodeContentText.text = text;
        NodeContentText.gameObject.SetActive(true);

        Choices.gameObject.SetActive(false);
        NodeContentText.gameObject.SetActive(true);
        NextButton.gameObject.SetActive(true);

    }

    protected void PrintChoicesContent()
    {
        List<HomerElement> choices = runningFlow.SelectedNode.GetAvailableChoiceElements();

        Transform headerTextPlaceHolder = Choices.Find("Header");
        Transform ButtonsBox = Choices.Find("Buttons");
        foreach (Transform child in ButtonsBox)
        {
            Destroy(child.gameObject);
        }

        headerTextPlaceHolder.GetComponent<TextMeshProUGUI>().text = "";

        HomerElement header = runningFlow.SelectedNode.Node._header;
        string headerText = runningFlow.SelectedNode.GetParsedText(header);

        if (headerText != null)
            headerTextPlaceHolder.GetComponent<TextMeshProUGUI>().text = headerText;

        int idx = 0;
        foreach (HomerElement choice in choices)
        {

            string text = runningFlow.SelectedNode.GetParsedText(choice);
            Transform choiceElement = Instantiate(ChoicePrefab, ButtonsBox.transform);
            choiceElement.GetComponentInChildren<TMP_Text>().text = text;
            choiceElement.GetComponent<Button>().onClick.AddListener(() => {
                Choose(choice);
            });
            idx++;
        }

        Choices.gameObject.SetActive(true);
        NodeContentText.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(false);

    }

    public void Choose(HomerElement choice)
    {
        Next(choice._id);
    }

    public void Next(string elementId = null)
    {
        HomerNode nextNode = runningFlow.NextNode(elementId);

        if (nextNode == null)
        {
            //InitializeFlow(runningFlow._selectedFlowId);
            Debug.Log("---------------- THE END ----------------");

            EndDialogueEvent.Invoke();
        }
        else
            DrawNode();
    }

    
}
