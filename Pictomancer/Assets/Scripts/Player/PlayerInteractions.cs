using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    Player _player;
    public float interactDistance = 2f;
    List<KeyCode> keys = new List<KeyCode>();
    Vector2 lookDirection = Vector2.zero;
    int mask;

    private void Awake()
    {
        mask = LayerMask.GetMask(Constants.LAYER_INTERACTIBLE);
        _player = GetComponent<Player>();
        keys.Add(KeyCode.G); // Interact Key : Grab and Put
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

        return Physics2D.Raycast(transform.position, lookDirection, interactDistance, mask);
    }

    void HandleInteractions(KeyCode key, RaycastHit2D hit)
    {
        switch (key)
        {
            case KeyCode.G: // Grab and Pick
                if (_player.IsCarrying())
                {
                    PutDownItem(hit);
                } else
                {
                    GrabItem(hit);
                }
                break;
            default: break;
        }
    }

    #region GrabAndPick
    void GrabItem(RaycastHit2D hit)
    {
        Debug.Log(hit);
        IObject obj = null;
        if (hit.transform.parent.TryGetComponent(out MagicMixer magicMixer))
        {
            obj = magicMixer.GrabSpell();
        } else if (hit.transform.TryGetComponent(out ExchangeTile tile))
        {
            obj = tile.GetSpell();
        }
        if (obj == null)
        {
            Debug.Log($"Grab item? False.");
        }
        else
        {
            Debug.Log($"Grab item? {_player.SetItemCarried(obj)}");
        }
    }
    void PutDownItem(RaycastHit2D hit)
    {
        IObject obj = _player.GetCarriedItem();
        if (obj == null) return;
        if (hit.transform.TryGetComponent(out ExchangeTile tile))
        {
            if (obj is SpellObject_SO)
            {
                bool res = tile.PutDownSpell((SpellObject_SO)obj);
                if (res) _player.ConfirmRemovalCarriedItem();
                Debug.Log($"Put down item? {res}");
            } else
            {
                Debug.Log("Put down item? False, no spell so.");
            }
            
        }
    }
    #endregion
}
