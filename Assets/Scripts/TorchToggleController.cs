using UnityEngine;
using UnityEngine.UI;

public class TorchToggleController : MonoBehaviour
{
    public Toggle torchToggle;
    public WeldingTool weldingTool;

    void Start()
    {
        torchToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        weldingTool.torchPowerOn = isOn;
    }
}
