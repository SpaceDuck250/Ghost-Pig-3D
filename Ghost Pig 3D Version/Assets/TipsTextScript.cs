using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TipsTextScript : MonoBehaviour
{
    public GhostCollisionChecker checker;

    public TextMeshProUGUI tipsText;

    public string onTransformIntoText;
    public string onObjectEnterText;

    public float transformedWaitTime;
    public float enteredWaitTime;

    private void Start()
    {
        GhostCollisionChecker.OnTransformInto += OnTransformInto;
        GhostCollisionChecker.OnObjectEnter += OnObjectEnter;
    }

    private void OnDestroy()
    {
        GhostCollisionChecker.OnTransformInto -= OnTransformInto;
        GhostCollisionChecker.OnObjectEnter -= OnObjectEnter;
    }

    private void OnTransformInto(TransformableData arg1, GameObject arg2)
    {
        StopAllCoroutines();
        tipsText.text = onTransformIntoText;
        StartCoroutine(WaitThenSetTextEmpty(transformedWaitTime));
    }

    private void OnObjectEnter(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }

        TransformableData transformData = obj.GetComponent<TransformableObjScript>().transformableData;

        string nullCase = "Null";
        string objectName = transformData != null ? transformData.objName : nullCase;

        StopAllCoroutines();
        tipsText.text = onObjectEnterText + objectName ;
        StartCoroutine(WaitThenSetTextEmpty(enteredWaitTime));
    }

    private IEnumerator WaitThenSetTextEmpty(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        tipsText.text = string.Empty;
    }
}
