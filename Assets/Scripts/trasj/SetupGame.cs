using UnityEngine;
using UnityEngine.UI;


public class SetupGame : MonoBehaviour
{
    private OnClickToolButtons onClickToolButtons;

    private int[] tool1Adds = { 1, 1, 1 };
    private int[] tool2Adds = { -1, -1, -1 };
    private int[] tool3Adds = { -1, 1, 1 };

    private Text tool1Values;
    private Text tool2Values;
    private Text tool3Values;

    private void Awake()
    {
        onClickToolButtons = GameObject.FindFirstObjectByType<OnClickToolButtons>();

        SetupToolValuesText(tool1Adds, tool1Values);
        SetupToolValuesText(tool2Adds, tool2Values);
        SetupToolValuesText(tool3Adds, tool3Values);

        onClickToolButtons.tool1Adds = tool1Adds;
        onClickToolButtons.tool2Adds = tool2Adds;
        onClickToolButtons.tool3Adds = tool3Adds;
    }

    private void SetupToolValuesText(int[] tool, Text toolValues)
    {
        string text = "";

        for (int i = 0; i < tool.Length; i++)
        {
            if (tool[i] > 0)
                text += $" | +{tool[i]} | ";
            else
                text += $" | {tool[i]} | ";
        }
        toolValues.text = text;
    }
}

