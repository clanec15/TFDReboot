using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IDMenu : MonoBehaviour
{
    public GameObject placeholder;
    public RectTransform parent;
    public IDDetector IDdt;
    public int ycoord;
    public int i = 0;
    public bool finished;


    void OnEnable()
    {
        finished = false;
    }


    void Update() {

        if(!finished){
            foreach (int IntTag in IDdt.TagInt)
            {
                ycoord = (282 - (127*i));

                Vector3 newpos = new Vector3(parent.transform.position.x - 509, parent.transform.position.y + ycoord, 0);
                // Instantiate the prefab at the current spawn position
                GameObject instantiatedPrefab = Instantiate(placeholder, newpos, Quaternion.identity, parent);
                // Optionally, you can modify the instantiatedPrefab here, e.g. set its transform parent, scale, rotation, etc.
                instantiatedPrefab.GetComponent<Transform>().position = newpos;
                instantiatedPrefab.GetComponent<Transform>().GetChild(0).GetComponent<TextMeshProUGUI>().text = "ID: " + IDdt.TagInt[i].ToString();
                i++;
            }
            finished = true;
        }
    }

    void OnDisable()
    {
        i = 0;
        foreach(Transform child in parent){
            Destroy(child.gameObject);
        }
    }
}
