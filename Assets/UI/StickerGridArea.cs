using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StickerGridArea : MonoBehaviour
{
    [SerializeField] private int pageNumber;
    [SerializeField] private int rowId;
    [SerializeField] private int colId;
    [SerializeField] private int rowsUnlocked;
    [SerializeField] private int gridObjectPerRow;
    [SerializeField] private int totalNumberOfGridObjects;
    [SerializeField] private GameObject currentSelectedGridObject;
    [SerializeField] private GameObject currentSelectionOutlineObject;
    [SerializeField] private GameObject[] gridObjectArray;
    [SerializeField] private GameObject gridObjectPrefab;
    
    private void Start() 
    {
        CalculateNumberOfGridObjects();
        CreateGridObjectArray();
    }
    
    private void Update() {
        ChangeCurrentSelectedOutlinePosition(currentSelectedGridObject.transform.position);
    }

    private void CalculateNumberOfGridObjects()
    {
        totalNumberOfGridObjects = rowsUnlocked * gridObjectPerRow;
    }

    private void CreateGridObjectArray()
    {
        gridObjectArray = new GameObject[totalNumberOfGridObjects];

        for (int i=0 ; i < gridObjectArray.Length ; i++)
        {
            //Creates a new instance of the Grid Object Prefab, sets it as a child of this UI component so the grid layout can place it and set a unique ID
            gridObjectArray[i] = (GameObject)Instantiate(gridObjectPrefab);
            gridObjectArray[i].transform.SetParent(this.transform, false);
            gridObjectArray[i].GetComponent<GridObject>().SetGridObjectId(i);

            gridObjectArray[i].GetComponent<GridObject>().SetPageNumber(pageNumber);
            gridObjectArray[i].GetComponent<GridObject>().SetColPosition(colId);
            gridObjectArray[i].GetComponent<GridObject>().SetRowPosition(rowId);
            CheckColId();
            CheckRowId();

            gridObjectArray[i].GetComponent<GridObject>().SetDebugText();
        }

        SetColRowToZero();
        SetFirstSelectedGridObject(gridObjectArray[0]);
    }

    private void SetColRowToZero()
    {
        rowId = 0;
        colId = 0;
    }

    private void SetFirstSelectedGridObject(GameObject gridObject)
    {
        currentSelectedGridObject = gridObject;
    }

    private void CheckColId()
    {        
        colId++;
        if (colId == 4) {colId = 0; rowId++;}
    }

    private void CheckRowId()
    {
        if (rowId == 4) {rowId = 3;}
    }

    private void ChangeCurrentSelectedOutlinePosition(Vector3 newPosition)
    {
        currentSelectionOutlineObject.transform.position = newPosition;
    }
    
    public Vector3 FetchCurrentGridObjectPosition()
    {
        return currentSelectedGridObject.transform.position;
    }

    private int CheckCurrentSelectedGridObjectRowPosition()
    {
        return currentSelectedGridObject.GetComponent<GridObject>().FetchRowPosition();
    }

    private int CheckCurrentSelectedGridObjectColPosition()
    {
        return currentSelectedGridObject.GetComponent<GridObject>().FetchColPosition();
    }

    private int CheckCurrentSelectedGridObjectId()
    {
        return currentSelectedGridObject.GetComponent<GridObject>().FetchGridObjectId();
    }

    private void ChangeCurrentSelectedGridObject(int gridObjectId)
    {
        currentSelectedGridObject = gridObjectArray[gridObjectId];
    }
}
