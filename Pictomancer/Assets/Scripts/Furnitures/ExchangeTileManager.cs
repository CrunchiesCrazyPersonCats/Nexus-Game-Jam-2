using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeTileManager : MonoBehaviour
{
    List<ExchangeTile> _tiles = new List<ExchangeTile>();

    #region "TileManager"
    public void RegisterTile(ExchangeTile tile)
    {
        if (!_tiles.Contains(tile))
        {
            _tiles.Add(tile);
        }
    }
    #endregion

    #region "SpellHandler"
    public SpellObject_SO GetOldestSpell()
    {
        foreach (ExchangeTile tile in _tiles)
        {
            SpellObject_SO so = tile.GetSpell();
            if (so != null)
            {
                return so;
            }
        }
        return null;
    }
    #endregion
}
