using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] public Zone zone;
    public void Change()
    {
        SceneManager.LoadScene("VR BaseBall(backup2)");
    }

    IEnumerator SceneOff()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadScene("VR BaseBall(backup2)");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Apllication.Quit();

#endif 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
    }
}
