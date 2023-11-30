using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectsInteract : MonoBehaviour
{
    [SerializeField] private GameObject cursor;
    private bool isEnter;
    [SerializeField] private string roomName;
    private JsonController json;
    private PlayerController player;
        private void Start()
    {
        cursor.SetActive(false);
        isEnter = false;
        json = FindObjectOfType<JsonController>();
        player = FindObjectOfType<PlayerController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter==true && Input.GetKeyDown(KeyCode.E)) //Ben bunu oyunlarda sahne gecisi icin kullanýyorum
        {
            if (SceneManager.GetActiveScene().name =="Antre") // Tek  bir oda olusturup girdigimiz konumdan tekrardan çýkýyoruz
            {
                json.player.xPos = player.transform.position.x;//girmeden önce x position'ýnýn save alýyorum.
                json.SaveJson();
            }
            if (roomName=="Girl's_room")
            {
                json.player.inGirlRoom = true;
            }
            if (roomName == "Bedroom")
            {
                json.player.inBedRoom = true;

            }

            SceneManager.LoadScene(roomName);
            json.player.roomName=roomName;
            json.SaveJson();
            Destroy(cursor);
            roomName = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            cursor.SetActive(true);
            isEnter = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cursor.SetActive(false);
            isEnter = false;
        }
    }
}
