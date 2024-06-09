# Shelf-Layout-Management

1. Provide CRUD operations for Shelves(Cabinets, Rows, and Lanes).
2. Store and retrieve Shelf data.
3. Support operations for moving drinks between different positions.

## API

### GET LIST OF Shelves
- METHOD: `GET`
- PATH: localhost:5089/api/v1/shelves
- BODY:
- RESPONSE:

### GET LIST OF Cabinets
- METHOD: `GET`
- PATH:
- BODY:
- RESPONSE:

### GET LIST OF Rows
- METHOD: `GET`
- PATH: localhost:5089/api/v1/shelves/cabinets/rows
- BODY:
- RESPONSE:

### GET LIST OF Lanes
- METHOD: `GET`
- PATH: localhost:5089/api/v1/shelves/cabinets/rows/lanes
- BODY:
- RESPONSE:

### GET Shelf
- METHOD: `GET`
- PATH:
- BODY:
- RESPONSE:

### GET Cabinet
- METHOD: `GET`
- PATH:
- BODY:
- RESPONSE:

### GET Row
- METHOD: `GET`
- PATH:
- BODY:
- RESPONSE:

### GET Lane
- METHOD: `GET`
- PATH:
- BODY:
- RESPONSE:


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
- RESPONSE: `201 Created`


### UPDATE Shelf
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### UPDATE Cabinet
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### UPDATE Row
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### UPDATE Lane
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### DELETE Shelf
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### DELETE Cabinet
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### DELETE Row
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### DELETE Lane
- METHOD: 
- PATH:
- BODY:
- RESPONSE:

### COMMENTS
- It was planned to implement storing and retreiving data in relational DB (PostgreSQL).
However, due to lack of time, data management is implemented in structures in memory.
- For simplicity IoC is not used
