
# BookDemo

BookDemo is a simple ASP.NET Core Web API project designed to manage a collection of books. It demonstrates how to create, read, update, and delete books using basic CRUD operations. The project exposes a set of endpoints that allow interaction with a book collection through HTTP requests.


## Features

- **Get all books**: Retrieve a list of all books.
- **Get book by ID**: Retrieve a single book by its ID.
- **Create a new book**: Add a new book to the collection.
- **Update an existing book**: Modify an existing book's details.
- **Delete a book**: Remove a book from the collection.
- **Partially update a book**: Update specific fields of a book.

  
## Getting Started

To get started with the project, clone this repository and open it in your preferred IDE or text editor. Follow these steps to run the API locally:

```bash
git clone https://github.com/oguzhanoxel/BookDemo
cd BookDemo
```

Restore the dependencies

```bash
dotnet restore
```

Run the project

```bash
dotnet run
```

  
## API Endpoints

### Retrieve all books in the collection.

```http
  GET /api/books
```

##### Response:
 - ```200 OK```: Returns a list of books.

 ```
 [
    {
        "id": 1,
        "title": "Moby Dick",
        "price": 15.99
    },
    {
        "id": 2,
        "title": "Pride and Prejudice",
        "price": 9.49
    },
    {
        "id": 3,
        "title": "War and Peace",
        "price": 20.00
    }
]
 ```

### Retrieve a specific book by its ID.

```http
  GET /api/books/{id:int}
```

##### Parameters:
- ```id```: The ID of the book.

##### Response:
 - ```200 OK```: Returns the book with the specified ID.
 - ```404 Not Found```: If the book does not exist.
 ```
{
    "title": "New Book Title",
    "price": 19.99
}
 ```

### Create a new book.

```http
  POST /api/books
```

##### Request body:
 ```
{
    "title": "New Book Title",
    "price": 19.99
}
 ```

##### Response:
 - ```201 Created```: The new book is added to the collection.
 - ```400 Bad Request```: If catching an exception.

### Update an existing book.

```http
  PUT /api/books/{id:int}
```

##### Parameters:
- ```id```: The ID of the book to update.

##### Request body:
 ```
{
    "title": "Updated Book Title",
    "price": 17.99
}
 ```

##### Response:
 - ```200 OK```: Returns the updated book.
 - ```404 Not Found```: If the book does not exist.

### Delete a book by its ID.

```http
  DELETE /api/books/{id:int}
```

##### Parameters:
- ```id```: The ID of the book to delete.

##### Response:
 - ```204 No Content```: The book is deleted successfully.
 - ```404 Not Found```: If the book does not exist.

### Partially update a book's fields.

```http
  PATCH /api/books/{id:int}
```

##### Parameters:
- ```id```: The ID of the book to update.

##### Request body:
 ```
[
    { "op": "replace", "path": "/title", "value": "Partially Updated Title" }
]
 ```

##### Response:
 - ```204 No Content```: The book is updated.
 - ```404 Not Found```: If the book does not exist.
