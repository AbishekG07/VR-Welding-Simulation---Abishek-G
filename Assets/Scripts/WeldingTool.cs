using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WeldingTool : MonoBehaviour
{
    public InputActionReference triggerAction;        // Assign in Inspector
    public ParticleSystem sparkEffect;                // Sparks effect
    public AudioSource weldSound;                     // Optional sound
    public GameObject residuePrefab;                  // Clay blob
    public Transform torchTip;                        // Spawn position
    public float residueInterval = 0.1f;              // Delay between blobs
    public float residueScale = 0.0001f;                 // Set by UI slider
    public bool torchPowerOn = true;
    



    private XRGrabInteractable grabInteractable;
    private bool isHeld = false;
    private float timer = 0f;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        triggerAction.action.Enable();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnDisable()
    {
        triggerAction.action.Disable();
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    void Update()
    {
        if (!isHeld || !torchPowerOn)
        {
            if (sparkEffect.isPlaying)
            {
                sparkEffect.Stop();

            }
            return;
        }
        

        float triggerValue = triggerAction.action.ReadValue<float>();

        if (triggerValue > 0.1f)
        {
            if (!sparkEffect.isPlaying)
                sparkEffect.Play();

            if (weldSound != null && !weldSound.isPlaying)
                weldSound.Play();

            TrySpawnResidue();
        }
        else
        {
            if (sparkEffect.isPlaying)
                sparkEffect.Stop();

            if (weldSound != null && weldSound.isPlaying)
                weldSound.Stop();
        }
    }

    void TrySpawnResidue()
    {
        timer += Time.deltaTime;
        if (timer < residueInterval) return;

        if (Physics.Raycast(torchTip.position, torchTip.forward, out RaycastHit hit, 0.15f))
        {
            if (hit.collider.CompareTag("Metal"))
            {
                Vector3 spawnPos = hit.point + hit.normal * 0.005f;
                Quaternion rot = Quaternion.LookRotation(hit.normal);

                GameObject residue = Instantiate(residuePrefab, spawnPos, rot);
                residue.transform.SetParent(hit.collider.transform); // Stick to surface

                //  This line sets the scale of the residue based on UI value
                residue.transform.localScale = Vector3.one * residueScale;

                timer = 0f;
            }
        }
    }


    void OnGrabbed(SelectEnterEventArgs args) => isHeld = true;
    void OnReleased(SelectExitEventArgs args)
    {
        isHeld = false;
        if (sparkEffect.isPlaying) sparkEffect.Stop();
        if (weldSound != null && weldSound.isPlaying) weldSound.Stop();
    }
}
