create database se_2024

use se_2024

CREATE TABLE Creator (
    id INT PRIMARY KEY,
    fullname VARCHAR(255),
    username VARCHAR(255) UNIQUE,
    email VARCHAR(255) UNIQUE,
    country VARCHAR(255),
    birthdate DATE,
    password VARCHAR(255)
);

CREATE TABLE Album (
    id INT PRIMARY KEY,
    title VARCHAR(255),
    releasedate DATE,
    genre VARCHAR(255),
    photourl VARCHAR(255),
    creator_id INT,
    FOREIGN KEY (creator_id) REFERENCES Creator(id)
);

CREATE TABLE Song (
    id INT PRIMARY KEY,
    title VARCHAR(255),
    song_length INT, 
    songUrl VARCHAR(255),
    album_id INT,
    FOREIGN KEY (album_id) REFERENCES Album(id)
);

INSERT INTO Creator (id, fullname, username, email, country, birthdate, password) VALUES
(1, 'John Doe', 'johndoe', 'johndoe@example.com', 'USA', '1980-01-01', 'password123'),
(2, 'Jane Smith', 'janesmith', 'jane@example.com', 'UK', '1985-05-15', 'pass456'),
(3, 'Alice Johnson', 'alicej', 'alice@example.com', 'Canada', '1990-07-22', 'alicepass789');

INSERT INTO Album (id, title, releasedate, genre, photourl, creator_id) VALUES
(1, 'Sunset Boulevard', '2021-06-01', 'Pop', 'http://example.com/photo1.jpg', 1),
(2, 'Morning Rise', '2022-03-15', 'Rock', 'http://example.com/photo2.jpg', 1),
(3, 'Quantum Leap', '2023-01-20', 'Electronic', 'http://example.com/photo3.jpg', 2);


INSERT INTO Song (id, title, song_length, songUrl, album_id) VALUES
(1, 'Golden Hour', 240, 'http://example.com/song1.mp3', 1),
(2, 'Twilight Zone', 215, 'http://example.com/song2.mp3', 1),
(3, 'Daybreak', 180, 'http://example.com/song3.mp3', 2),
(4, 'Event Horizon', 305, 'http://example.com/song4.mp3', 3);