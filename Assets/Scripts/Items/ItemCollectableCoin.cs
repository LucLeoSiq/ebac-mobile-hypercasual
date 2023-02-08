using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    [Header("ItemCollectableCoin Setup")]
    public Collider collider;
    public bool collect = false;
    public float lerp = 5f;

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
        }
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        collider.enabled = false;
        collect = true;
    }

    protected override void Collect()
    {
        OnCollect();
    }



}
