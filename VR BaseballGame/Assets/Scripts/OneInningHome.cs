using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneInningHome : MonoBehaviour
{
    [SerializeField] public Run2HomeBase Run2HomeBase;
    public Text Home;
    // Start is called before the first frame update
    void Start()
    {
        Home = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Run2HomeBase.Home == true)
        {
            Home.text = "" + Run2HomeBase.HomeScore;
        }
    }
}
