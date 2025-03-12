using UnityEngine;
using UnityEngine.UI;

public class ToolVisual : MonoBehaviour
{
    [SerializeField] private Tool _tool;
    [SerializeField] private Text _valuesText;
    
    public Text toolText;
    public Button toolButton;

    public void UpdateToolVisual()
    {
        int[] offsets = _tool.GetOffsets();
        _valuesText.text = $" | {offsets[0]} | {offsets[1]} | {offsets[2]} | ";
    }
}
