using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMap;
        public Camera _camera;
        public Tilemap GetTileMap()
        {
            return _tileMap;
        }

        private void Update()
        {
            //_tileMap.ClearAllTiles();
            //print(Mathf.RoundToInt(UnityEngine.Input.mousePosition.x));
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            

            print(_tileMap.HasTile(Vector3Int.RoundToInt(mouseWorldPosition)));
        }
    }
}
