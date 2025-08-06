using UnityEngine;

public class TorchPowerButton : MonoBehaviour
{
    public WeldingTool weldingTool;  // Drag the torch with the script attached

    public void PowerOn()
    {
        weldingTool.torchPowerOn = true;
        Debug.Log("Torch ON");
    }

    public void PowerOff()
    {
        weldingTool.torchPowerOn = false;
        Debug.Log("Torch OFF");
    }
}
