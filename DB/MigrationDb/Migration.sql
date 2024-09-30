create table users
(
    id uuid primary key,
    userName varchar unique,
    email varchar unique,
    passwordHash varchar not null,
    createdAt timestamp with time zone
);

create table authors
(
    id uuid primary key,
    firstName varchar not null,
    lastName varchar not null,
    dateOfBirth timestamp with time zone,
    biography varchar not null,
    createdAt timestamp with time zone
);


create table categories
(
    id uuid primary key,
    name varchar unique,
    createdAt timestamp with time zone
);

create table books
(
    id uuid primary key,
    title varchar not null,
    description varchar not null,
    isbn varchar unique,
    publishedDate timestamp with time zone,
    authorId uuid,
    categoryId uuid,
    createdAt timestamp with time zone,
    Foreign key(authorId) references authors(id) on delete cascade,
    Foreign key(categoryId) references categories(id) on delete cascade
);


create table bookRentals
(
    id uuid primary key,
    bookId uuid,
    userId uuid,
    rentalDate timestamp with time zone,
    returnDate timestamp with time zone,
    createdAt timestamp with time zone,
    Foreign key(bookId) references books(id) on delete cascade,
    Foreign key(userId) references users(id) on delete cascade
);
