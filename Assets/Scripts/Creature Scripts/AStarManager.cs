using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Random = System.Random;

public class AStarManager : MonoBehaviour
{
    [SerializeField] Tilemap walkableTilemap;
    [SerializeField] Transform idie;
    //[SerializeField] Transform highlight;
    [SerializeField] private float speed;
    private IEnumerator astarCoroutine;
    private List<Spot> path;
    [SerializeField] private Animator anim;
    private float totalSpeed;
    [SerializeField] private SpriteRenderer bird;

    //Note: In C#, variables without an access modifier are private by default
    Vector3Int[,] walkableArea;
    Astar astar;
    BoundsInt bounds;

    private Vector3Int GridPositionOfMouse3D
    {
        get
        {
            return walkableTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private Vector2Int GridPositionOfMouse2D => (Vector2Int)GridPositionOfMouse3D;

    private Vector2Int GridPositionOfIdie
    {
        get
        {
            return (Vector2Int)walkableTilemap.WorldToCell(idie.position);
        }
    }

    private void Start()
    {
        //Trims any empty cells from the edges of the tilemap
        walkableTilemap.CompressBounds();
        bounds = walkableTilemap.cellBounds;

        CreateGrid();
        astar = new Astar(walkableArea, bounds.size.x, bounds.size.y);

        StartCoroutine(movement());
    }

    private void CreateGrid()
    {
        walkableArea = new Vector3Int[bounds.size.x, bounds.size.y];
        for (int x = bounds.xMin, i = 0; i < (bounds.size.x); x++, i++)
        {
            for (int y = bounds.yMin, j = 0; j < (bounds.size.y); y++, j++)
            {
                if (walkableTilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    walkableArea[i, j] = new Vector3Int(x, y, 0);
                }
                else
                {
                    walkableArea[i, j] = new Vector3Int(x, y, 1);
                }
            }
        }
    }

    private void Update()
    {
        //totalSpeed = Mathf.Abs(Input.GetAxisRaw("Horizontal") * speed) + Mathf.Abs(Input.GetAxisRaw("Vertical") * speed);
        //anim.SetFloat("birdSpeed", totalSpeed);
        //anim.SetFloat("birdSpeed", idie.transform.position.magnitude);
    }

    bool checkWalkable(Vector3Int positionOfMouse)
    {
        for (int i = 0; i < (bounds.size.x); i++)
        {
            for (int j = 0; j < (bounds.size.y); j++)
            {
                if (walkableArea[i, j] == positionOfMouse)
                {
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator movement()
    {
        while (true)
        {
            /*int randX = UnityEngine.Random.Range(0, bounds.size.x - 1);
            int randY = UnityEngine.Random.Range(0, bounds.size.y - 1);
            var target = walkableArea[randX, randY];*/
            int randX = UnityEngine.Random.Range(0, walkableArea.GetLength(0));
            int randY = UnityEngine.Random.Range(0, walkableArea.GetLength(1));

            var target = walkableArea[randX, randY];
            
            if (checkWalkable(target))
            {
                path = astar.CreatePath(walkableArea, GridPositionOfIdie, (Vector2Int)target, true);
                while (path == null)
                {
                    randX = UnityEngine.Random.Range(0, walkableArea.GetLength(0));
                    randY = UnityEngine.Random.Range(0, walkableArea.GetLength(1));
                    target = walkableArea[randX, randY];
                    path = astar.CreatePath(walkableArea, GridPositionOfIdie, (Vector2Int)target, true);
                    yield return null;
                }
                yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 5f));
                foreach (var spot in path)
                {
                    var targetPos = new Vector2(spot.X, spot.Y);
                    while (Vector2.Distance(GridPositionOfIdie, new Vector2(spot.X, spot.Y)) > 0.1f)
                    {
                        anim.SetFloat("birdSpeed", 1f);
                        idie.transform.position = Vector2.MoveTowards(idie.transform.position, targetPos,(speed * Time.deltaTime));
                        if (idie.transform.position.x < targetPos.x)
                        {
                            bird.flipX = true;
                        }
                        else if (idie.transform.position.x > targetPos.x)
                        {
                            bird.flipX = false;
                        }
                        yield return null;
                    }
                }
                anim.SetFloat("birdSpeed", 0f);
                
                /*for (int i = 0; i < path.Count; i++)
                {
                    var targetPos = new Vector2(path[i].X, path[i].Y);
                    while (Vector2.Distance(GridPositionOfIdie, new Vector2(path[i].X, path[i].Y)) > 0.1f)
                    {
                        idie.transform.position = Vector2.MoveTowards(idie.transform.position, targetPos,(speed * Time.deltaTime));
                        yield return null;
                    }
                }*/
                
                yield return new WaitForSeconds(UnityEngine.Random.Range(3f, 7f));
                anim.SetBool("canInteract", true);
                yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 4f));
                anim.SetBool("canInteract", false);
                yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 5f));
            }
            yield return null;
        }
    }
}
