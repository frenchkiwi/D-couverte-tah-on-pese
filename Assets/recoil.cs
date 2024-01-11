using System.Collections;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public float recoilForce = 1f;
    public float recoilDuration = 0.1f;

    private Vector3 originalPosition;
    private bool isRecoiling = false;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !isRecoiling)
        {
            StartCoroutine(RecoilEffect());
        }
    }

    IEnumerator RecoilEffect()
    {
        isRecoiling = true;

        Vector3 recoilPosition = originalPosition - transform.forward * recoilForce;

        float elapsed = 0f;

        while (elapsed < recoilDuration)
        {
            transform.localPosition = Vector3.Lerp(originalPosition, recoilPosition, elapsed / recoilDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        isRecoiling = false;
    }
}
