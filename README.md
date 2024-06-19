# Shelf-Layout-Management

1. Provide CRUD operations for Shelves(Cabinets, Rows, and Lanes).
2. Store and retrieve Shelf data.
3. Support operations for moving drinks between different positions.

## API

### CREATE Shelf
- METHOD: `POST`
- PATH: api/v1/shelves
- BODY: 
```JSON
{
  "Cabinets": [
    {
      "Number": 1,
      "Rows": [
        {
          "Number": 1,
          "Lanes": [
            {
              "Number": 1,
              "JanCode": "4902102112457",
              "Quantity": 10,
              "PositionX": 5
            },
            {
              "Number": 2,
              "JanCode": "4902102112457",
              "Quantity": 10,
              "PositionX": 10
            }
          ],
          "PositionZ": 50,
          "Size": {
            "Height": 40
          }
        },
        {
          "Number": 2,
          "Lanes": [
            {
              "Number": 3,
              "JanCode": "4902102112518",
              "Quantity": 13,
              "PositionX": 5
            },
            {
              "Number": 4,
              "JanCode": "4902102112525",
              "Quantity": 14,
              "PositionX": 10
            }
          ],
          "PositionZ": 100,
          "Size": {
            "Height": 40
          }
        }
      ],
      "Position": {
        "X": 10,
        "Y": 20,
        "Z": 0
      },
      "Size": {
        "Width": 100,
        "Depth": 50,
        "Height": 200
      }
    }
  ]
}
```
- PARAMETERS: -
- RESPONSE: `201 Created`

### READ LIST OF Shelves
- METHOD: `GET`
- PATH: api/v1/shelves
- BODY: -
- PARAMETERS: -
- RESPONSE: `200 OK`

### READ Shelf
- METHOD: `GET`
- PATH: api/v1/shelves/{shelfd}
- BODY: -
- PARAMETERS: shelfd
- RESPONSE: `200 OK`
- 
### UPDATE Shelf
- METHOD: `PUT`
- PATH: api/v1/shelves/{shelfId}
- BODY:
  ```JSON
  {}
  ```
- PARAMETERS: shelfId
- RESPONSE: `200 OK`

### DELETE Shelf
- METHOD: `DELETE`
- PATH: api/v1/shelves/{shelfId}
- BODY: -
- PARAMETERS: shelfId
- RESPONSE: `204 No Content`
  

### CREATE Cabinet
- METHOD: `POST`
- PATH: api/v1/shelves/{shelfId}/cabinets
- BODY:
  ```JSON
  {
    "Number": 1
  }
  ```
- PARAMETERS: shelfId
- RESPONSE: `201 Created`

### READ LIST OF Cabinets
- METHOD: `GET`
- PATH: api/v1/shelves/{shelfId}/cabinets
- BODY: -
- PARAMETERS: shelfId
- RESPONSE: `200 OK`

### READ Cabinet
- METHOD: `GET`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}
- BODY: -
- PARAMETERS: shelfId, cabinetId
- RESPONSE: `200 OK`

### UPDATE Cabinet
- METHOD: `PUT`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}
- BODY:
  ```JSON
  {
    "Number": 3000
  }
  ```
- PARAMETERS: shelfId, cabinetId
- RESPONSE: `200 OK`

### DELETE Cabinet
- METHOD: `DELETE`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}
- BODY: -
- PARAMETERS: shelfId, cabinetId
- RESPONSE: `204 No Content`


### CREATE Row
- METHOD: `POST`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows
- BODY:
  ```JSON
  {
    "Number": 2
  }
  ```
- PARAMETERS: shelfId, cabinetId
- RESPONSE: `201 Created`

### READ LIST OF Rows
- METHOD: `GET`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows
- BODY: -
- PARAMETERS: shelfId, cabinetId
- RESPONSE: `200 OK`

### READ Row
- METHOD: `GET`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}
- BODY: -
- PARAMETERS: shelfId, cabinetId, rowId
- RESPONSE: `200 OK`

### UPDATE Row
- METHOD: `PUT`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}
- BODY:
  ```JSON
  {
    "Number": 2000
  }
  ```
- PARAMETERS: shelfId, cabinetId, rowId
- RESPONSE: `200 OK`

### DELETE Row
- METHOD: `DELETE`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}
- BODY: -
- PARAMETERS: shelfId, cabinetId, rowId
- RESPONSE: `204 No Content`
  

### CREATE Lane
- METHOD: `POST`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes
- BODY:
  ```JSON
  {
    "Number": 4
  }
  ```
- PARAMETERS: shelfId, cabinetId, rowId
- RESPONSE: `201 Created`

### READ LIST OF Lanes
- METHOD: `GET`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes
- BODY: -
- PARAMETERS: -
- RESPONSE: `200 OK`

### READ Lane
- METHOD: `GET`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes/{laneId}
- BODY: -
- PARAMETERS: -
- RESPONSE: `200 OK`

### UPDATE Lane
- METHOD: `PUT`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes/{laneId}
- BODY:
  ```JSON
  {
    "Number": 1000
  }
  ```
- PARAMETERS: shelfId, cabinetId, rowId, laneId
- RESPONSE: `200 OK`

### DELETE Lane
- METHOD: `DELETE`
- PATH: api/v1/shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes/{laneId}
- BODY: -
- PARAMETERS: shelfId, cabinetId, rowId, laneId
- RESPONSE: `204 No Content`


### ADD Sku
- METHOD: `POST`
- PATH: api/v1/skus/add
- BODY: laneId, count
- PARAMETERS: -
- RESPONSE: `200 OK`

### REMOVE Sku
- METHOD: `POST`
- PATH: api/v1/skus/remove
- BODY: laneId, count
- PARAMETERS: -
- RESPONSE: `200 OK`
  
### MOVE Sku
- METHOD: `POST`
- PATH: api/v1/skus/move
- BODY: sourceLaneId, targetLaneId, count
- PARAMETERS: -
- RESPONSE: `204 No Content`

### COMMENTS
- Currently data management is implemented in memory. The plan is to store data in relational DB (PostgreSQL).
- IoC is not used for simplicity.
