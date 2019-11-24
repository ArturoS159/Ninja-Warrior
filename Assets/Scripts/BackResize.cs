 using System.Collections;
 using UnityEngine;
 [RequireComponent (typeof (SpriteRenderer))]

 public class BackResize : MonoBehaviour {

     void Start () {
         Resize ();
     }

     void Resize () {
         SpriteRenderer sr = GetComponent<SpriteRenderer> ();
         transform.localScale = new Vector3 (1, 1, 1);

         float width = sr.sprite.bounds.size.x;
         float height = sr.sprite.bounds.size.y;

         float worldScreenHeight = Camera.main.orthographicSize * 2f; // 10f
         float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width; // 10f

        Vector3 imgScale = new Vector3(1f, 1f, 1f)
        {
            x = worldScreenWidth / width,
            y = worldScreenHeight / height
        };

        transform.localScale = imgScale;
     }
 }