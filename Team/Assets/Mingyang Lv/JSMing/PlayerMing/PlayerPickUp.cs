
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerPickUp : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;
    public string sceneName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >=5)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
            SceneManager.LoadScene(sceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
