using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    Player _player;
    public float interactDistance = 2f;
    public List<KeyCode> keys = new List<KeyCode>();
    Vector2 lookDirection = Vector2.zero;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        RaycastHit2D hit = GetInteractableObject();
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key) && hit)
            {
                HandleInteractions(key, hit);
            }
        }
    }

    RaycastHit2D GetInteractableObject()
    {
        Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 1f);

        // Can not look in diagonals
        if (!Mathf.Approximately(dir.x, 0.0f) || !Mathf.Approximately(dir.y, 0.0f))
        {
            lookDirection.Set(dir.x, dir.y);
            lookDirection.Normalize();
        }

        return Physics2D.Raycast(transform.position, lookDirection, interactDistance);
    }

    void HandleInteractions(KeyCode key, RaycastHit2D hit)
    {
        switch (key)
        {
            case KeyCode.G:
                if (hit.transform.parent.TryGetComponent(out MagicMixer magicMixer))
                {
                    IObject spell = magicMixer.GrabSpell();
                    if (spell == null)
                    {
                        Debug.Log($"Grab item? False.");
                    } else
                    {
                        Debug.Log($"Grab item? {_player.SetItemCarried(spell)}");
                    }
                }
                break;
            default: break;
        }
    }
}
