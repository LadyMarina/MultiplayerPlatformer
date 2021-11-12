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
        [SerializeField] private Tile _correctCheckTileSprite;
        [SerializeField] private Tile _wrongCheckTileSprite;
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
            return _correctCheckTileSprite;
        }
        public Tile GetWrongCheckTileSprite()
        {
            return _wrongCheckTileSprite;
        }
        private void Update()
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        }
    }
}
