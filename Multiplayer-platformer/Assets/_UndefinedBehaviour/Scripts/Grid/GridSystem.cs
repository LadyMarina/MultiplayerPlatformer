using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class GridSystem : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private Tilemap _checkTileMap;
        [SerializeField] private Tile _CorrectCheckTileSprite;
        [SerializeField] private Tile _WrongCheckTileSprite;
        public Tilemap GetTileMap()
        {
            return _tileMap;
        }

        public Tilemap GetCheckTileMap()
        {
            return _checkTileMap;
        }


        public Tile GetCorrectCheckTileSprite()
        {
            return _CorrectCheckTileSprite;
        }
        public Tile GetWrongCheckTileSprite()
        {
            return _WrongCheckTileSprite;
        }
        private void Update()
        {
            //_tileMap.ClearAllTiles();
            //print(Mathf.RoundToInt(UnityEngine.Input.mousePosition.x));
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
           // print(_tileMap.HasTile(Vector3Int.RoundToInt(mouseWorldPosition)));
        }
    }
}
