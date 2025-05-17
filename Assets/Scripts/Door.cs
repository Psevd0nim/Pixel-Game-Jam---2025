using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Tilemap _roofTilemap;

    private Coroutine coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("Enter");
        if(coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(HideOrShowRoof(true));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetTrigger("Exit");
    }

    private IEnumerator HideOrShowRoof(bool hide)
    {
        float time = 2;
        while (time > 0)
        {
            yield return null;
            time -= Time.deltaTime;
            Color color = _roofTilemap.color;
            float changeValue = Time.deltaTime / time;
            color.a += hide ? -changeValue : changeValue;
            _roofTilemap.color = color;
        }
    }
}
