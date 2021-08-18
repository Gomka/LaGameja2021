using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private string m_NPCName;
    [SerializeField] private AudioClip m_NPCVoice;
    [SerializeField] private DialogueNode m_FirstNode;

    public DialogueNode FirstNode => m_FirstNode;
    public string NPCName => m_NPCName;
    public AudioClip NPCVoice => m_NPCVoice;
}
