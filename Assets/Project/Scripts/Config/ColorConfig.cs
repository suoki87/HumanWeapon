using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Config/ColorConfig")]
public class ColorConfig : ScriptableObject
{
    public Color[] colors;
}