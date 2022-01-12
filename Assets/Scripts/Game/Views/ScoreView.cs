using UnityEngine;

/// <summary>
/// View of Score component.
/// Updates a text with value inside Score component.
/// </summary>
public class ScoreView : MonoBehaviour, IView<Score>
{
    [SerializeField] private TextMesh m_text;

    public void ComponentUpdate(ref Score p_component)
    {
        m_text.text = p_component.Value.ToString();
    }
}