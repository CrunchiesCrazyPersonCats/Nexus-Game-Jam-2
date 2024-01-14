using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner_D : MonoBehaviour
{
    public MagicMixer _mixer;
    public ElementObject_SO _elementObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mixer.AddElement(_elementObject);
        }
    }
}
