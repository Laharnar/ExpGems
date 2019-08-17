using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChange : MonoBehaviour
{
    [SerializeField] string[] uiTags;
    [SerializeField] GameObject[] uiObjs;
    [SerializeField] string defaultMenu;

    Dictionary<string, GameObject> data;

    private void Awake()
    {
        data = new Dictionary<string, GameObject>();
        for (int i = 0; i < uiTags.Length; i++)
        {
            data.Add(uiTags[i], uiObjs[i]);
            uiObjs[i].transform.localPosition = new Vector3(200, 0, 0);
        }
        LoadUI(defaultMenu);
    }

    public void LoadUI(string uiTag)
    {
        for (int i = 0; i < uiObjs.Length; i++)
        {
            uiObjs[i].SetActive(false);
            uiObjs[i].transform.localPosition = new Vector3(200, 0, 0);
        }
        data[uiTag].SetActive(true);
        data[uiTag].transform.localPosition = new Vector3(0, 0, 0);
    }
}
