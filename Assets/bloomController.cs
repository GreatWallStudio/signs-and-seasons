using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class bloomController : MonoBehaviour
{
    [SerializeField] PostProcessVolume _postProcessVolume;
    private Bloom _bloom;

    public void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _bloom);
        _bloom.intensity.value = 0.1f;
    }

    public void AdjustBloom(float bloomAmount)
    {
        _bloom.intensity.value = bloomAmount; 

    }
}
