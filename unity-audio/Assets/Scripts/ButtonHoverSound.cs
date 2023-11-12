using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverSound;
    public AudioClip clickSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound)
        {
            audioSource.clip = hoverSound;
            audioSource.Play();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound)
        {
            audioSource.clip = clickSound;
            audioSource.Play();
        }
    }
}
