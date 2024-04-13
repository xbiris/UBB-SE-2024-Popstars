DROP DATABASE IF EXISTS se_2024;

CREATE DATABASE se_2024;

USE se_2024;

CREATE TABLE Creator (
    id INT IDENTITY(1,1) PRIMARY KEY,
    fullname VARCHAR(255),
    username VARCHAR(255),
    email VARCHAR(255),
    country VARCHAR(255),
    birthdate VARCHAR(255),
    socialmedialink VARCHAR(255),
    description VARCHAR(255),
    profilePicPath VARCHAR(255),
    password VARCHAR(255)
);

CREATE TABLE Album (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(255),
    releasedate VARCHAR(255),
    genre VARCHAR(255),
    photourl VARCHAR(255),
    creator_id INT,
    FOREIGN KEY (creator_id) REFERENCES Creator(id)
);

CREATE TABLE Song (
    id INT IDENTITY(1,1) PRIMARY KEY,
    title VARCHAR(255),
    song_length INT, 
    songUrl VARCHAR(255),
    album_id INT,
    FOREIGN KEY (album_id) REFERENCES Album(id)
);

INSERT INTO Creator (fullname, username, email, country, birthdate, socialmedialink, description, profilePicPath, password) VALUES
('John Doe', 'johndoe', 'johndoe@example.com', 'USA', '1980-01-01', 'link', 'desc', 'path' ,'password123'),
('Jane Smith', 'janesmith', 'jane@example.com', 'UK', '1985-05-15', 'link', 'desc', 'path', 'pass456'),
('Alice Johnson', 'alicej', 'alice@example.com', 'Canada', '1990-07-22', 'link', 'desc', 'path', 'alicepass789');

INSERT INTO Album (title, releasedate, genre, photourl, creator_id) VALUES
('Sunset Boulevard', '2021-06-01', 'Pop', 'http://example.com/photo1.jpg', 1),
('Morning Rise', '2022-03-15', 'Rock', 'http://example.com/photo2.jpg', 1),
('Quantum Leap', '2023-01-20', 'Electronic', 'http://example.com/photo3.jpg', 2);

INSERT INTO Song (title, song_length, songUrl, album_id) VALUES
('Golden Hour', 240, 'http://example.com/song1.mp3', 1),
('Twilight Zone', 215, 'http://example.com/song2.mp3', 1),
('Daybreak', 180, 'http://example.com/song3.mp3', 2),
('Event Horizon', 305, 'http://example.com/song4.mp3', 3);
