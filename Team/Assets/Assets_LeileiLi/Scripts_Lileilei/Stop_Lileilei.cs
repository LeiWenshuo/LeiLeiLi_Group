using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//场景
/*
 * This class class set the quit action.
 * @Lileilei
 */
public class Stop_Lileilei : MonoBehaviour
{
    public AudioClip mainSound;
    public AudioSource source;
    public int i;
    public int j;

    /*
     * Quit game method.
     */
    public void quit()
        
        {
       
            #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//编辑状态下退出
            #else
                        Application.Quit();//打包编译后退出
#endif
       
        }
    


}
