using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl_Lei : MonoBehaviour
{
    //���Ƽ��س����ķ���
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
        //���������������뵽ָ���ĳ���
        Load_Scene(sceneName);
    }

    public void Load_Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
