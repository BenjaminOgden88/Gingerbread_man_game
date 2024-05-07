using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLavaTexture : MonoBehaviour
{
    public float scrollingSpeed = 0.1f;

    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Time.time * scrollingSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(move, 0));
        
    }
}
