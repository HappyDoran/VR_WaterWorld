using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Particle : MonoBehaviour
{
    public bool playAura = false; //파티클 제어 bool
    public ParticleSystem particleObject; //파티클시스템
    public XRBaseInteractable interactable;

    private void Start()
    {
        playAura = false;
        particleObject.Play();
    }


    private void Update()
    {
        if (playAura)                    
            particleObject.Play();       
        else if (!playAura)                
            particleObject.Stop();        
    }
    public void StartWatering(BaseInteractionEventArgs args)
    {
        playAura = !playAura;
    }

    public void StopWatering(BaseInteractionEventArgs args)
    {
        playAura = false;
    }
}