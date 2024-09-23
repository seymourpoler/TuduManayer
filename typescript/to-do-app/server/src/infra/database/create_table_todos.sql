CREATE TABLE Todos (
    Id INTEGER PRIMARY KEY GENERATED ALWAYS AS IDENTITY,
    Description VARCHAR(255) NOT null,
    Completed BOOLEAN not null,
    Created timestamp not null
);