using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject BlockPrefab;

    List<Vector3> BlockPositions = new List<Vector3>();
    Block[] Blocks;

    private void Awake()
    {
        Blocks = GetComponentsInChildren<Block>();

        foreach(Block block in Blocks)
        {
            BlockPositions.Add(block.transform.position);
        }

        ResetBlocks();
    }

    public void ResetBlocks()
    {
        for(int i = Blocks.Length - 1; i >= 0; i--)
        {
            if(Blocks[i] != null)
            {
                Destroy(Blocks[i].gameObject);
            }
        }

        for(int i = 0; i < BlockPositions.Count; i++)
        {
            GameObject newBlockOgj = GameObject.Instantiate(BlockPrefab, BlockPositions[i], Quaternion.identity, transform);
            Blocks[i] = newBlockOgj.GetComponent<Block>(); 
        }
    }
}
