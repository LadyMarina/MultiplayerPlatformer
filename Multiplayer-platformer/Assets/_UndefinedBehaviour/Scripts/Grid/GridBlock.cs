using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class GridBlock : MonoBehaviour
    {
        private SpriteRenderer _sprite;
        private Vector3[] _spriteCorners;
        private Vector3 _spriteCenter;
        private float[] _distanceBetweenCorners;
        private GridSystem _gridSystem;
        private Tilemap _tilemap;
        private Tilemap _checkTilemap;
        private Tile _CorrectCheckTileSprite;
        private Tile _WrongCheckTileSprite;

        private Vector3 _tilemapPlaceIndex;
        private Vector3 _tilemapNewPlaceIndex;

        private int indexMinCorner;
        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            
            _gridSystem = FindObjectOfType<GridSystem>();
            _tilemap = _gridSystem.GetTileMap();
            _checkTilemap = _gridSystem.GetCheckTileMap();
            _CorrectCheckTileSprite = _gridSystem.GetCorrectCheckTileSprite();
            _WrongCheckTileSprite = _gridSystem.GetWrongCheckTileSprite();
            _distanceBetweenCorners = new float[4];
        }
        private void Update()
        {
            
            _spriteCorners = GetSpriteCorners(_sprite);
            _spriteCenter = GetSpriteCenter(_sprite);
                    
            for (int i = 0; i < _spriteCorners.Length; i++)
            {
                _distanceBetweenCorners[i] = Vector3.Distance(_spriteCenter, _tilemap.GetCellCenterWorld(Vector3Int.RoundToInt(GetTilePosition(i, _spriteCorners))));
            }
              
            float minDistance = Mathf.Min(_distanceBetweenCorners);
            int index = System.Array.IndexOf(_distanceBetweenCorners, minDistance);

            _tilemapPlaceIndex = GetTilePosition(index, _spriteCorners);

            if (_tilemapPlaceIndex != _tilemapNewPlaceIndex)
            {
                _tilemapNewPlaceIndex = _tilemapPlaceIndex;
                _checkTilemap.ClearAllTiles();
            }

            if (_tilemap.HasTile(Vector3Int.RoundToInt(GetTilePosition(index, _spriteCorners))))
            {
                _checkTilemap.SetTile(Vector3Int.RoundToInt(GetTilePosition(index, _spriteCorners)), _WrongCheckTileSprite);
            }
            else
            {
                _checkTilemap.SetTile(Vector3Int.RoundToInt(GetTilePosition(index, _spriteCorners)), _CorrectCheckTileSprite);
                
            }

        }

        public static Vector3 GetTilePosition(int index, Vector3[] spriteCorners)
        {
            Vector3 vector3 = new Vector3(spriteCorners[index].x - 0.5f, spriteCorners[index].y - 0.5f, 0);
            vector3 = Vector3Int.RoundToInt(vector3);
            return vector3;
        }
        public static Vector3[] GetSpriteCorners(SpriteRenderer renderer)
        {
            Vector3 topRight = renderer.transform.TransformPoint(renderer.sprite.bounds.max);
            Vector3 topLeft = renderer.transform.TransformPoint(new Vector3(renderer.sprite.bounds.max.x, renderer.sprite.bounds.min.y, 0));
            Vector3 botLeft = renderer.transform.TransformPoint(renderer.sprite.bounds.min);
            Vector3 botRight = renderer.transform.TransformPoint(new Vector3(renderer.sprite.bounds.min.x, renderer.sprite.bounds.max.y, 0));

            return new Vector3[] { topRight, topLeft, botLeft, botRight };
        }

        public static Vector3 GetSpriteCenter(SpriteRenderer renderer)
        {
            Vector3 center = renderer.transform.TransformPoint(renderer.sprite.bounds.center);
            return center;
        }

    }
}
