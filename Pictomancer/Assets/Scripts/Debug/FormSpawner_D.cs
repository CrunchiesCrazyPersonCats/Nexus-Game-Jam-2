using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormSpawner_D : MonoBehaviour
{
    public MagicMixer _mixer;
    public FormObject_SO _formObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mixer.AddForm(_formObject);
        }
    }
}
