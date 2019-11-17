using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerTwoMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector2 screenBounds;
    SpriteRenderer sprite;
    float pos;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos = speed * Time.deltaTime + transform.position.y;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            pos = -1 * speed * Time.deltaTime + transform.position.y;
        }
        var newYPos = Mathf.Clamp(pos, -screenBounds.y + sprite.bounds.extents.y, screenBounds.y-sprite.bounds.extents.y);
        transform.position=new Vector2(transform.position.x,newYPos);
    }
}
