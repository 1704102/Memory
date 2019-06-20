using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 dest_position;
    Quaternion dest_rotation;

    Vector3 ori_position;
    Quaternion ori_rotation;
    public bool rotated = false;

    public string image;
    public bool isPlayed;
    GameLogic logic;

    void Start()
    {
        logic = GameObject.Find("Plane").GetComponent<GameLogic>();

        ori_position = transform.position;
        ori_rotation = transform.rotation;

        Vector3 rotation = dest_rotation.eulerAngles;
        rotation.x += 180;
        dest_rotation = Quaternion.Euler(rotation);
        
    }  
    
    // Update is called once per frame
    void Update()
    {
        if (rotated) {
            transform.rotation = Quaternion.Lerp(transform.rotation, dest_rotation, 2f * Time.deltaTime);
        } else {
            transform.rotation = Quaternion.Lerp(transform.rotation, ori_rotation, 2f * Time.deltaTime);
        }
    }

    private void OnMouseDown() {
        logic.TakeTurn(this);
    }

    public void TurnCard() {
        if (rotated) {
            rotated = false;
        } else {
            rotated = true;
        }
       
    }

    public void SetSprite(Sprite sprite, string image) {
        Texture texture = sprite.texture;
        Material m = transform.GetChild(1).GetComponent<MeshRenderer>().material;
        m.mainTexture = texture;
        this.image = image;
    }
}
