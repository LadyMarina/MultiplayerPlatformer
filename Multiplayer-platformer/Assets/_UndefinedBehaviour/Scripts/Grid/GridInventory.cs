using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class GridInventory : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPointBlock;
        [SerializeField] private GameObject[] _allBlocks;
        public GameObject[] _invetoryBlocks = new GameObject[3];

        private void Start()
        {
            for (int i = 0; i < _invetoryBlocks.Length; i++)
            {
                SpawnBlocks(i);
            }
        }

        private void SpawnBlocks(int invetoryID)
        {
            GameObject instantiateBlock = Instantiate(_allBlocks[0], _spawnPointBlock[invetoryID].position, Quaternion.identity);
            instantiateBlock.GetComponent<GridBlock>().SetInvetoryIndex(invetoryID);
            _invetoryBlocks[invetoryID] = instantiateBlock;
        }

        public void DeleteBlock(int invetoryID)
        {
            //ELIMINA EL BLOCKE DE LA ID Y CREA UNO NUEVO EN LA ID
            Destroy(_invetoryBlocks[invetoryID]);
            SpawnBlocks(invetoryID);
        }
    }
}
