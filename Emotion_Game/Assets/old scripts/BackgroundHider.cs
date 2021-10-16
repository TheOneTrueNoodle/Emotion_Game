using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHider : MonoBehaviour
{
    private SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("trigger checker"))
        {
            m_SpriteRenderer.enabled = false;

        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("trigger checker"))
        {
            m_SpriteRenderer.enabled = true;
        }

    }
}
