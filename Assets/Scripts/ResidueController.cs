using UnityEngine;
using UnityEngine.UI; // Add this namespace for the Slider type

public class ResidueController : MonoBehaviour
{
    public WeldingTool weldingTool;         // Reference to your script
    public Slider controlSlider;            // Assign in Inspector
    public Text valueText;

    void Start()
    {
        controlSlider.onValueChanged.AddListener(UpdateResidueSettings);
       
        UpdateResidueSettings(controlSlider.value);  // Apply initial value
        
    }

    void UpdateResidueSettings(float value)
    {
        weldingTool.residueInterval = value;

        // Assuming residueScale is not defined in WeldingTool, we add a local variable here
        float residueScale = Mathf.Lerp(0.05f, 0.3f, value); // Size from small to large
        Debug.Log($"Residue Scale: {residueScale}"); // Log the value for debugging
        weldingTool.residueInterval = 0.001f;
        weldingTool.residueScale = Mathf.Lerp(0.005f, 0.3f, value);
        valueText.text = $"Residue: {value:0.000}";
    }


}
