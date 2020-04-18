using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bar;
    private void Start()
    {
        bar = transform.Find("Bar");

    }
    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 5f);
    }
    public void SetColor(Color color)
    {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
    public void DestroyHealthbar()
    {
        Destroy(gameObject);
    }
}