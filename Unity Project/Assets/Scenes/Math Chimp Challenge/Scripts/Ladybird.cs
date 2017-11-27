using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ladybird : MonoBehaviour
{   
    public List<GameObject> GetSpots()
    {
        return (from Transform child in transform select child.gameObject).ToList();
    }



    public void SetVisibleSpots(int numberOfSpots)
    {
        var spots = GetSpots();
        Shuffler.Shuffle(spots);
        foreach (var obj in spots)
        {
            obj.SetActive(false);
        }
        for (var i = 0; i < numberOfSpots; i++)
        {
            spots[i].SetActive(true);
        }
    }
    
}
