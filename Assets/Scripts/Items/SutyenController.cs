using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SutyenController : MonoBehaviour
{
    public GameObject sutyen;
    private bool canTake;
    public GameObject cursor;
    private JsonController json;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        json = FindObjectOfType<JsonController>();
        sutyen.SetActive(true);
        canTake = false;
        cursor.SetActive(false);
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canTake==true && Input.GetKeyDown(KeyCode.E))
        {
            json.player.isTake = true;
            json.SaveJson();
            sutyen.SetActive(false);
            cursor.SetActive(false);
            text.SetActive(false);
        }
        if (json.player.isTake==true) // Sutyen bir kere alindi ise bir daha alinamaz.
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") {
            canTake = true;
            cursor.SetActive(true);
            text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            canTake = false;
            cursor.SetActive(false);
            text.SetActive(false);
        }   
    }
}
