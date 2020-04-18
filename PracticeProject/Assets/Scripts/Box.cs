using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //UIController.onChangeColorClick += ApplyRandColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UIController.onChangeColorClick += ApplyRandColor;
    }

    private void OnDisable()
    {
        UIController.onChangeColorClick -= ApplyRandColor;
    }

    void ApplyRandColor()
    {
        RecolorCommand recolor = new RecolorCommand(this.gameObject, new Color( Random.value, Random.value, Random.value));
        recolor.Execute();

        CommandManager.Instance.AddCommand(recolor);
    }
}
