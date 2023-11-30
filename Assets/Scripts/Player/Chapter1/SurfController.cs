using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfController : MonoBehaviour
{
    public bool surfing;
    private PlayerController player;
    private JsonController json;
    private float counter;
    public float maxTime;
    private float originalGravity;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        json = FindObjectOfType<JsonController>();
        originalGravity = player.rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.rb.gravityScale);

        if (player.onGround ==false )
        {
            counter += Time.deltaTime;

        }
        else {
            counter = 0;
            surfing = false;
        }

        if (counter >= maxTime && json.player.isTake==true ) //saya� verilen s�reyi ge�erse ve s�tyen al�nd� ise
        {
            if (Input.GetKey(KeyCode.Space)) //Space'e bas�l� tutulduk�a
            {
                if (!surfing)
                {

                    surfing = true;
                    player.anim.SetTrigger("surfing");
                }
            } else if (Input.GetKeyUp(KeyCode.Space))//Space'e basmay� b�rak�nca
            {
                surfing = false;
                player.anim.SetTrigger("down");

            }
        }

        if (surfing ==true && player.rb.velocity.y <0)
        {
            player.rb.gravityScale = 0.1f;
        }else  {
            player.rb.gravityScale = originalGravity;
        }
    }
}
