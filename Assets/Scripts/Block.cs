using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int block_hp; //ブロックHP

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            block_hp--;

            if (block_hp <= 0)
            {
                //アイテムを1/Xの確立で生成
                if (Random.Range(0, 1) == 0)
                {
                    GameManager.instance.ItemGenerate();
                }
                Destroy(gameObject);
            }
        }
    }
}