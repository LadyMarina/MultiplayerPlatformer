using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UndefinedBehaviour.MultiplayerPlatformer
{
    public class GridInventory : MonoBehaviour
    {
        private bool _isDragActive = false;
        private Vector2 _screenPosition;
        private Vector3 _wordPosition;
        private GridBlock _lastGridBlock;

        private void Awake()
        {
            GridInventory[] controllers = FindObjectsOfType<GridInventory>();
            if (controllers.Length > 1)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (_isDragActive && (UnityEngine.Input.GetMouseButtonUp(0) ||( UnityEngine.Input.touchCount == 1 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Ended)))
            {
                Drop();
                return;
            }

            if (UnityEngine.Input.GetMouseButton(0))
            {
                Vector3 mousePos = UnityEngine.Input.mousePosition;
                _screenPosition = new Vector2(mousePos.x, mousePos.y);
            }
            else if (UnityEngine.Input.touchCount > 0)
                _screenPosition = UnityEngine.Input.GetTouch(0).position;
            else
                return;

            _wordPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

            if (_isDragActive)
                Drag();
            else 
            {
                RaycastHit2D hit = Physics2D.Raycast(_wordPosition, Vector2.zero);
                if (hit.collider != null)
                {
                    GridBlock gridBlock = hit.transform.gameObject.GetComponent<GridBlock>();
                    if (gridBlock != null)
                    {
                        _lastGridBlock = gridBlock;
                        InitDrag();
                    }
                }
            }
        }

        void InitDrag()
        {
            _isDragActive = true;
        }

        void Drag()
        {
            _lastGridBlock.transform.position = new Vector2(_wordPosition.x, _wordPosition.y);
        }

        void Drop()
        {
            _lastGridBlock.PlaceBlock();
            _isDragActive = false;
        }
    }
}
