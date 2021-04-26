using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BcricksScript : MonoBehaviour
{
    public int points;
    public int doubleHits;
    public Sprite hitSprite;
    public void BreakBrick()
    {
        doubleHits--;
        GetComponent<SpriteRenderer>().sprite = hitSprite;
        
    }
}
