using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class GridBlock : MonoBehaviour
    {
        [Header("SPRITES & GRIDS")]
        [SerializeField] private Tile _blockTileSprite;
        private SpriteRenderer _sprite;
        private GridSystem _gridSystem;
        private Tilemap _tilemap;
        private Tilemap _checkTilemap;
        private Tile _correctCheckTileSprite;
        private Tile _wrongCheckTileSprite;
        private GridInventory _gridInventory;
        private BoxCollider2D _boxCollider2D;

        [Header("POSITION SPRITES & CORNERS")]
        private Vector3[] _spriteCorners;
        private Vector3 _spriteCenter;
        private Vector3 _tilemapPlaceIndex;
        private Vector3 _tilemapNewPlaceIndex;
        private float[] _distanceBetweenCorners;

        [Header("EXTRAS")]
        private bool _itCanBePlace;
        private int _indexBetweenCorners;
        private int _invetoryID;

        private int indexMinCorner;
        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _gridSystem = FindObjectOfType<GridSystem>();
            _gridInventory = FindObjectOfType<GridInventory>();
            _tilemap = _gridSystem.GetTileMap();
            _checkTilemap = _gridSystem.GetCheckTileMap();
            _correctCheckTileSprite = _gridSystem.GetCorrectCheckTileSprite();
            _wrongCheckTileSprite = _gridSystem.GetWrongCheckTileSprite();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _distanceBetweenCorners = new float[4];

            _boxCollider2D.isTrigger = true;
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
            _indexBetweenCorners = System.Array.IndexOf(_distanceBetweenCorners, minDistance);

            _tilemapPlaceIndex = GetTilePosition(_indexBetweenCorners, _spriteCorners);

            if (_tilemapPlaceIndex != _tilemapNewPlaceIndex)
            {
                _tilemapNewPlaceIndex = _tilemapPlaceIndex;
                _checkTilemap.ClearAllTiles();
            }

            if (_tilemap.HasTile(Vector3Int.RoundToInt(GetTilePosition(_indexBetweenCorners, _spriteCorners))))
            {
                _checkTilemap.SetTile(Vector3Int.RoundToInt(GetTilePosition(_indexBetweenCorners, _spriteCorners)), _wrongCheckTileSprite);
                _itCanBePlace = false;
            }
            else
            {
                _checkTilemap.SetTile(Vector3Int.RoundToInt(GetTilePosition(_indexBetweenCorners, _spriteCorners)), _correctCheckTileSprite);
                _itCanBePlace = true;
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

        public void PlaceBlock()
        {
            if (_itCanBePlace)
            {
                _tilemap.SetTile(Vector3Int.RoundToInt(GetTilePosition(_indexBetweenCorners, _spriteCorners)), _blockTileSprite);
                _boxCollider2D.isTrigger = false;
                _gridInventory.DeleteBlock(_invetoryID);
            }
            else
            {
                Debug.Log("RETURN");
            }
        }


        public void SetInvetoryIndex(int ID)
        {
            _invetoryID = ID;
        }
    }
}
