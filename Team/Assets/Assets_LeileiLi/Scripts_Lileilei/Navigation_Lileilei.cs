using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * This class class set the navigaiton.
 * @Lileilei
 */
public class Navigation_Lileilei : MonoBehaviour
{
    /*
     * Change scene method.
     */
    public void loadScene(string name)
    {
        SceneManager.LoadScene(name);
        DynamicGI.UpdateEnvironment();
    }
   
}
