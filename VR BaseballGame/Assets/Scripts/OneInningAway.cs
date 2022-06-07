using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneInningAway : MonoBehaviour
{
    [SerializeField] public Run2HomeBase Run2HomeBase;
    public Text Away;
    // Start is called before the first frame update
    void Start()
    {
        Away = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Run2HomeBase.Away == true)
        {
            Away.text = "" + Run2HomeBase.AwayScore;
        }

    }
}
