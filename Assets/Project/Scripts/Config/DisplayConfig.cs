using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Config/DisplayConfig")]
public class DisplayConfig : ScriptableObject
{
    [InfoBox("체력표시", InfoMessageType.None)]
    public bool isShowHp = true;

    [InfoBox("속도표시", InfoMessageType.None)]
    public bool isShowSpd = true;
}