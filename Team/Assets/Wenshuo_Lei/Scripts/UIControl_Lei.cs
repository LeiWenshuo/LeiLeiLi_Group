using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl_Lei : MonoBehaviour
{
    //控制加载场景的方向
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnyClickContine()
    {
        //点击任意键继续进入到指定的场景
        Load_Scene(sceneName);
    }

    public void Load_Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
