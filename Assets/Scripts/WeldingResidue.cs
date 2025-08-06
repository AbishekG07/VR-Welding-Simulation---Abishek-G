using UnityEngine;
using UnityEngine.InputSystem;

public class WeldingResidue : MonoBehaviour
{
    public InputActionReference triggerAction;
    public Transform torchTip; // Assign TorchTip in Inspector
    public GameObject residuePrefab; // Your clay blob
    public float interval = 0.1f; // How often blobs appear
    private float timer = 0f;

    void OnEnable() => triggerAction.action.Enable();
    void OnDisable() => triggerAction.action.Disable();

    void Update()
    {
        bool triggerHeld = triggerAction.action.ReadValue<float>() > 0.1f;

        if (triggerHeld)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                timer = 0f;
                RaycastHit hit;
                // Shoot ray from tip in forward direction
                if (Physics.Raycast(torchTip.position, torchTip.forward, out hit, 0.1f))
                {
                    if (hit.collider.CompareTag("Metal"))
                    {
                        Vector3 spawnPos = hit.point + hit.normal * 0.005f;
                        Quaternion rot = Quaternion.LookRotation(hit.normal);
                        Instantiate(residuePrefab, spawnPos, rot);
                    }
                }
            }
        }
    }
}
