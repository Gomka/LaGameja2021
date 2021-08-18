using System;
using UnityEngine;

[Serializable]
public class DialogueChoice
{
    [SerializeField]
    private string m_ChoicePreview;
    [SerializeField]
    private DialogueNode m_ChoiceNode;

    public string ChoicePreview => m_ChoicePreview;
    public DialogueNode ChoiceNode => m_ChoiceNode;
}

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    [TextArea(3, 10)]
    [SerializeField] private string m_DialogueLine;

    [SerializeField]
    private DialogueChoice[] m_Choices;

    public string dialogueLine => m_DialogueLine;
    public DialogueChoice[] Choices => m_Choices;
}