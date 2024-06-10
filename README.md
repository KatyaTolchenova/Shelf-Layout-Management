# Shelf-Layout-Management

1. Provide CRUD operations for Shelves(Cabinets, Rows, and Lanes).
2. Store and retrieve Shelf data.
3. Support operations for moving drinks between different positions.

## API

### GET LIST OF Shelves
- METHOD: `GET`
- PATH: localhost:5089/api/v1/shelves
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK

### GET LIST OF Cabinets
- METHOD: `GET`
- PATH: shelves/{shelfId}/cabinets
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK

### GET LIST OF Rows
- METHOD: `GET`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK

### GET LIST OF Lanes
- METHOD: `GET`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK

### GET Shelf
- METHOD: `GET`
- PATH: shelves/{shelfd}
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK

### GET Cabinet
- METHOD: `GET`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK

### GET Row
- METHOD: `GET`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK

### GET Lane
- METHOD: `GET`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes/{laneId}
- BODY: -
- PARAMETERS: -
- RESPONSE: 200 OK


### CREATE Shelf
- METHOD: `POST`
- PATH: localhost:5089/api/v1/shelves
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
              "JanCode": "4902102112464",
              "Quantity": 15,
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
- PARAMETERS: 
- RESPONSE: `201 Created`

### CREATE Cabinet
- METHOD: `POST`
- PATH: shelves/{shelfId}/cabinets
- BODY:
  ```JSON
  ```
- PARAMETERS: 
- RESPONSE: `201 Created`

### CREATE Row
- METHOD: `POST`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows
- BODY:
  ```JSON
  ```
- PARAMETERS: 
- RESPONSE: `201 Created`

### CREATE Lane
- METHOD: `POST`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes
- BODY:
  ```JSON
  ```
- RESPONSE: `201 Created`

### UPDATE Shelf
- METHOD: `PUT`
- PATH: shelves/{shelfId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### UPDATE Cabinet
- METHOD: `PUT`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### UPDATE Row
- METHOD: `PUT`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### UPDATE Lane
- METHOD: `PUT`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes/{laneId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### DELETE Shelf
- METHOD: `DELETE`
- PATH: shelves/{shelfId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### DELETE Cabinet
- METHOD: `DELETE`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### DELETE Row
- METHOD: `DELETE`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### DELETE Lane
- METHOD: `DELETE`
- PATH: shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes/{laneId}
- BODY:
- PARAMETERS: 
- RESPONSE:

### COMMENTS
- It was planned to implement storing and retreiving data in relational DB (PostgreSQL).
However, due to lack of time, data management is implemented in structures in memory.
- IoC is not used for simplicity.
