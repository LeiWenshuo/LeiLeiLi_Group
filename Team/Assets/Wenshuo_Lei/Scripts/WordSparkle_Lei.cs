using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WordSparkle_Lei : MonoBehaviour
{
    public float blinkSpeed;//��˸�ٶ�
    private bool isAddAlpha;//�Ƿ�����͸����
    private float timer;//��ʱ��
    public float timeval = 1;//ʱ����

    private Text t;//ָ������ͼƬ
    private void Start()
    {
        t = GetComponent<Text>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (isAddAlpha)
        {
            t.color += new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (timer >= timeval)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, 1);
                isAddAlpha = false;
                timer = 0;
            }
        }
        else
        {
            t.color -= new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (timer >= timeval)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
                isAddAlpha = true;
                timer = 0;
            }
        }
    }

}