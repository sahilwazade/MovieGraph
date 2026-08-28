using System.Text.RegularExpressions;

namespace MovieGraph.Infrastructure.Seed
{
    public static class SeedData
    {
        public static readonly string SeedScript = """
        // ============================================================
        // GENRES
        // ============================================================

        MERGE (:Genre {
            id: 'genre-1',
            name: 'Science Fiction'
        })

        MERGE (:Genre {
            id: 'genre-2',
            name: 'Action'
        })

        MERGE (:Genre {
            id: 'genre-3',
            name: 'Thriller'
        })

        MERGE (:Genre {
            id: 'genre-4',
            name: 'Drama'
        })

        MERGE (:Genre {
            id: 'genre-5',
            name: 'Adventure'
        })

        MERGE (:Genre {
            id: 'genre-6',
            name: 'Crime'
        })

        MERGE (:Genre {
            id: 'genre-7',
            name: 'Fantasy'
        })

        MERGE (:Genre {
            id: 'genre-8',
            name: 'Mystery'
        })


        // ============================================================
        // DIRECTORS
        // ============================================================

        MERGE (:Director {
            id: 'director-1',
            name: 'Christopher Nolan'
        })

        MERGE (:Director {
            id: 'director-2',
            name: 'James Cameron'
        })

        MERGE (:Director {
            id: 'director-3',
            name: 'Denis Villeneuve'
        })

        MERGE (:Director {
            id: 'director-4',
            name: 'David Fincher'
        })

        MERGE (:Director {
            id: 'director-5',
            name: 'Peter Jackson'
        })

        MERGE (:Director {
            id: 'director-6',
            name: 'Frank Darabont'
        })

        MERGE (:Director {
            id: 'director-7',
            name: 'Quentin Tarantino'
        })

        MERGE (:Director {
            id: 'director-8',
            name: 'Jon Favreau'
        })


        // ============================================================
        // ACTORS
        // ============================================================

        MERGE (:Actor {
            id: 'actor-1',
            name: 'Leonardo DiCaprio'
        })

        MERGE (:Actor {
            id: 'actor-2',
            name: 'Matthew McConaughey'
        })

        MERGE (:Actor {
            id: 'actor-3',
            name: 'Christian Bale'
        })

        MERGE (:Actor {
            id: 'actor-4',
            name: 'Tom Hardy'
        })

        MERGE (:Actor {
            id: 'actor-5',
            name: 'Cillian Murphy'
        })

        MERGE (:Actor {
            id: 'actor-6',
            name: 'Joseph Gordon-Levitt'
        })

        MERGE (:Actor {
            id: 'actor-7',
            name: 'Anne Hathaway'
        })

        MERGE (:Actor {
            id: 'actor-8',
            name: 'Morgan Freeman'
        })

        MERGE (:Actor {
            id: 'actor-9',
            name: 'Brad Pitt'
        })

        MERGE (:Actor {
            id: 'actor-10',
            name: 'Keanu Reeves'
        })

        MERGE (:Actor {
            id: 'actor-11',
            name: 'Sam Worthington'
        })

        MERGE (:Actor {
            id: 'actor-12',
            name: 'Zoe Saldana'
        })

        MERGE (:Actor {
            id: 'actor-13',
            name: 'Hugh Jackman'
        })

        MERGE (:Actor {
            id: 'actor-14',
            name: 'Robert Downey Jr.'
        })

        MERGE (:Actor {
            id: 'actor-15',
            name: 'Chris Evans'
        })


        // ============================================================
        // USERS
        // ============================================================

        MERGE (:User {
            id: 'user-1',
            name: 'Sahil',
            email: 'sahil@example.com'
        })

        MERGE (:User {
            id: 'user-2',
            name: 'Rahul',
            email: 'rahul@example.com'
        })

        MERGE (:User {
            id: 'user-3',
            name: 'Aman',
            email: 'aman@example.com'
        })

        MERGE (:User {
            id: 'user-4',
            name: 'Priya',
            email: 'priya@example.com'
        })

        MERGE (:User {
            id: 'user-5',
            name: 'Neha',
            email: 'neha@example.com'
        })

        MERGE (:User {
            id: 'user-6',
            name: 'Arjun',
            email: 'arjun@example.com'
        })

        MERGE (:User {
            id: 'user-7',
            name: 'Riya',
            email: 'riya@example.com'
        })

        MERGE (:User {
            id: 'user-8',
            name: 'Vikram',
            email: 'vikram@example.com'
        })

        MERGE (:User {
            id: 'user-9',
            name: 'Ananya',
            email: 'ananya@example.com'
        })

        MERGE (:User {
            id: 'user-10',
            name: 'Karan',
            email: 'karan@example.com'
        })


        // ============================================================
        // MOVIES
        // ============================================================

        MERGE (:Movie {
            id: 'movie-1',
            title: 'Inception',
            releaseYear: 2010,
            rating: 8.8,
            description: 'A skilled thief enters dreams to steal valuable secrets.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/oYuLEt3zVCKq57qu2F8dT7NIa6f.jpg'
        })

        MERGE (:Movie {
            id: 'movie-2',
            title: 'Interstellar',
            releaseYear: 2014,
            rating: 8.7,
            description: 'Explorers travel through a wormhole searching for a new home.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/gEU2QniE6E77NI6lCU6MxlNBvIx.jpg'
        })

        MERGE (:Movie {
            id: 'movie-3',
            title: 'The Dark Knight',
            releaseYear: 2008,
            rating: 9.0,
            description: 'Batman faces a criminal mastermind who wants to create chaos.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg'
        })

        MERGE (:Movie {
            id: 'movie-4',
            title: 'The Prestige',
            releaseYear: 2006,
            rating: 8.5,
            description: 'Two rival magicians compete to create the ultimate illusion.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/5MXyQO7YZ5PKWe0d9a2A7l9YV1.jpg'
        })

        MERGE (:Movie {
            id: 'movie-5',
            title: 'Oppenheimer',
            releaseYear: 2023,
            rating: 8.6,
            description: 'The story of the scientist who helped develop the atomic bomb.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg'
        })

        MERGE (:Movie {
            id: 'movie-6',
            title: 'Tenet',
            releaseYear: 2020,
            rating: 7.3,
            description: 'A secret agent uses inverted time to prevent a global catastrophe.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/k68nPLbIST6NP96lQaaRIsw6t8.jpg'
        })

        MERGE (:Movie {
            id: 'movie-7',
            title: 'Dunkirk',
            releaseYear: 2017,
            rating: 7.8,
            description: 'Allied soldiers attempt to escape a dangerous wartime situation.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/ebSnODDg9lbsMIaWg2uAbjn7TO5.jpg'
        })

        MERGE (:Movie {
            id: 'movie-8',
            title: 'Memento',
            releaseYear: 2000,
            rating: 8.4,
            description: 'A man with short-term memory loss searches for his attacker.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/yuNs09hvpHVU1cBTCAk9zxsL2oW.jpg'
        })

        MERGE (:Movie {
            id: 'movie-9',
            title: 'Avatar',
            releaseYear: 2009,
            rating: 7.9,
            description: 'A former marine becomes involved in the struggle of an alien world.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/kyeqWdyUXW608qlYkRqosgbbJyK.jpg'
        })

        MERGE (:Movie {
            id: 'movie-10',
            title: 'Titanic',
            releaseYear: 1997,
            rating: 7.9,
            description: 'Two people from different backgrounds fall in love aboard a famous ship.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/9xjZS2rlVxm8SFx8kPC3aIGCOYQ.jpg'
        })

        MERGE (:Movie {
            id: 'movie-11',
            title: 'The Matrix',
            releaseYear: 1999,
            rating: 8.7,
            description: 'A hacker discovers that reality is not what it appears to be.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg'
        })

        MERGE (:Movie {
            id: 'movie-12',
            title: 'The Lord of the Rings',
            releaseYear: 2001,
            rating: 8.8,
            description: 'A group of heroes begins a dangerous journey to destroy a powerful ring.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/6oom5QYQ2yQTMJIbnvbkblA0cH.jpg'
        })

        MERGE (:Movie {
            id: 'movie-13',
            title: 'The Shawshank Redemption',
            releaseYear: 1994,
            rating: 9.3,
            description: 'A prisoner maintains hope while serving a long sentence.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/adAqmzscm4xSYDHw81xiwiLwbhU.jpg'
        })

        MERGE (:Movie {
            id: 'movie-14',
            title: 'Fight Club',
            releaseYear: 1999,
            rating: 8.8,
            description: 'An unhappy man becomes involved in an underground fighting organization.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/pB8BM7pdSp6B6Ih7QZ4DrQ3PmJK.jpg'
        })

        MERGE (:Movie {
            id: 'movie-15',
            title: 'Forrest Gump',
            releaseYear: 1994,
            rating: 8.8,
            description: 'A kind-hearted man experiences important moments in American history.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/arw2vcBveWOVZr6pxd9XTd1TdQa.jpg'
        })

        MERGE (:Movie {
            id: 'movie-16',
            title: 'The Godfather',
            releaseYear: 1972,
            rating: 9.2,
            description: 'The aging head of a crime family prepares his successor.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/3bhkrj58Vtu7enYsRolD1fZdja1.jpg'
        })

        MERGE (:Movie {
            id: 'movie-17',
            title: 'Pulp Fiction',
            releaseYear: 1994,
            rating: 8.9,
            description: 'Several interconnected stories unfold around crime and violence.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/d5iIlFn5s0ImszYzBPb8JPIfbXD.jpg'
        })

        MERGE (:Movie {
            id: 'movie-18',
            title: 'Gladiator',
            releaseYear: 2000,
            rating: 8.5,
            description: 'A Roman general seeks revenge after losing everything.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/ty8TTRagGfD8w5j0FfK4v7eZ1w5.jpg'
        })

        MERGE (:Movie {
            id: 'movie-19',
            title: 'Avengers: Endgame',
            releaseYear: 2019,
            rating: 8.4,
            description: 'The Avengers attempt to reverse a devastating event.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/or06FN3Dka5tukK1eB6Q0c4b8L.jpg'
        })

        MERGE (:Movie {
            id: 'movie-20',
            title: 'Spider-Man: No Way Home',
            releaseYear: 2021,
            rating: 8.2,
            description: 'Spider-Man faces villains from different realities.',
            posterUrl: 'https://image.tmdb.org/t/p/w500/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg'
        })


        // ============================================================
        // ACTED_BY RELATIONSHIPS
        // ============================================================

        MATCH (m:Movie {id: 'movie-1'})
        MATCH (a:Actor {id: 'actor-1'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-1'})
        MATCH (a:Actor {id: 'actor-6'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-1'})
        MATCH (a:Actor {id: 'actor-7'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-2'})
        MATCH (a:Actor {id: 'actor-2'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-2'})
        MATCH (a:Actor {id: 'actor-7'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-3'})
        MATCH (a:Actor {id: 'actor-3'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-3'})
        MATCH (a:Actor {id: 'actor-4'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-3'})
        MATCH (a:Actor {id: 'actor-8'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-4'})
        MATCH (a:Actor {id: 'actor-3'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-4'})
        MATCH (a:Actor {id: 'actor-4'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-5'})
        MATCH (a:Actor {id: 'actor-5'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-5'})
        MATCH (a:Actor {id: 'actor-3'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-6'})
        MATCH (a:Actor {id: 'actor-4'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-6'})
        MATCH (a:Actor {id: 'actor-5'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-7'})
        MATCH (a:Actor {id: 'actor-4'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-7'})
        MATCH (a:Actor {id: 'actor-5'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-8'})
        MATCH (a:Actor {id: 'actor-1'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-8'})
        MATCH (a:Actor {id: 'actor-6'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-9'})
        MATCH (a:Actor {id: 'actor-11'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-9'})
        MATCH (a:Actor {id: 'actor-12'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-10'})
        MATCH (a:Actor {id: 'actor-1'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-11'})
        MATCH (a:Actor {id: 'actor-10'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-12'})
        MATCH (a:Actor {id: 'actor-13'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-12'})
        MATCH (a:Actor {id: 'actor-8'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-13'})
        MATCH (a:Actor {id: 'actor-8'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-14'})
        MATCH (a:Actor {id: 'actor-9'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-15'})
        MATCH (a:Actor {id: 'actor-15'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-16'})
        MATCH (a:Actor {id: 'actor-14'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-17'})
        MATCH (a:Actor {id: 'actor-9'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-17'})
        MATCH (a:Actor {id: 'actor-14'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-18'})
        MATCH (a:Actor {id: 'actor-13'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-19'})
        MATCH (a:Actor {id: 'actor-14'})
        MERGE (m)-[:ACTED_BY]->(a)

        MATCH (m:Movie {id: 'movie-19'})
        MATCH (a:Actor {id: 'actor-15'})
        MERGE (m)-[:ACTED_BY]->(a)


        MATCH (m:Movie {id: 'movie-20'})
        MATCH (a:Actor {id: 'actor-14'})
        MERGE (m)-[:ACTED_BY]->(a)


        // ============================================================
        // DIRECTED_BY RELATIONSHIPS
        // ============================================================

        MATCH (m:Movie {id: 'movie-1'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-2'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-3'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-4'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-5'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-6'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-7'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-8'})
        MATCH (d:Director {id: 'director-1'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-9'})
        MATCH (d:Director {id: 'director-2'})
        MERGE (m)-[:DIRECTED_BY]->(d)

        MATCH (m:Movie {id: 'movie-10'})
        MATCH (d:Director {id: 'director-2'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-11'})
        MATCH (d:Director {id: 'director-3'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-12'})
        MATCH (d:Director {id: 'director-5'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-13'})
        MATCH (d:Director {id: 'director-6'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-14'})
        MATCH (d:Director {id: 'director-4'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-15'})
        MATCH (d:Director {id: 'director-6'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-16'})
        MATCH (d:Director {id: 'director-7'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-17'})
        MATCH (d:Director {id: 'director-7'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-18'})
        MATCH (d:Director {id: 'director-7'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-19'})
        MATCH (d:Director {id: 'director-8'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        MATCH (m:Movie {id: 'movie-20'})
        MATCH (d:Director {id: 'director-8'})
        MERGE (m)-[:DIRECTED_BY]->(d)


        // ============================================================
        // HAS_GENRE RELATIONSHIPS
        // ============================================================

        MATCH (m:Movie {id: 'movie-1'})
        MATCH (g:Genre {id: 'genre-1'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-1'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-2'})
        MATCH (g:Genre {id: 'genre-1'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-2'})
        MATCH (g:Genre {id: 'genre-4'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-2'})
        MATCH (g:Genre {id: 'genre-5'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-3'})
        MATCH (g:Genre {id: 'genre-2'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-3'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-3'})
        MATCH (g:Genre {id: 'genre-6'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-4'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-4'})
        MATCH (g:Genre {id: 'genre-8'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-5'})
        MATCH (g:Genre {id: 'genre-4'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-5'})
        MATCH (g:Genre {id: 'genre-8'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-6'})
        MATCH (g:Genre {id: 'genre-1'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-6'})
        MATCH (g:Genre {id: 'genre-2'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-6'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-7'})
        MATCH (g:Genre {id: 'genre-4'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-7'})
        MATCH (g:Genre {id: 'genre-2'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-8'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-8'})
        MATCH (g:Genre {id: 'genre-8'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-9'})
        MATCH (g:Genre {id: 'genre-1'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-9'})
        MATCH (g:Genre {id: 'genre-5'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-10'})
        MATCH (g:Genre {id: 'genre-4'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-10'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-11'})
        MATCH (g:Genre {id: 'genre-1'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-11'})
        MATCH (g:Genre {id: 'genre-2'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-12'})
        MATCH (g:Genre {id: 'genre-7'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-12'})
        MATCH (g:Genre {id: 'genre-5'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-13'})
        MATCH (g:Genre {id: 'genre-4'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-14'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-14'})
        MATCH (g:Genre {id: 'genre-6'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-15'})
        MATCH (g:Genre {id: 'genre-4'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-16'})
        MATCH (g:Genre {id: 'genre-6'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-16'})
        MATCH (g:Genre {id: 'genre-4'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-17'})
        MATCH (g:Genre {id: 'genre-6'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-17'})
        MATCH (g:Genre {id: 'genre-3'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-18'})
        MATCH (g:Genre {id: 'genre-2'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-18'})
        MATCH (g:Genre {id: 'genre-5'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-19'})
        MATCH (g:Genre {id: 'genre-2'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-19'})
        MATCH (g:Genre {id: 'genre-5'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-19'})
        MATCH (g:Genre {id: 'genre-1'})
        MERGE (m)-[:HAS_GENRE]->(g)


        MATCH (m:Movie {id: 'movie-20'})
        MATCH (g:Genre {id: 'genre-2'})
        MERGE (m)-[:HAS_GENRE]->(g)

        MATCH (m:Movie {id: 'movie-20'})
        MATCH (g:Genre {id: 'genre-7'})
        MERGE (m)-[:HAS_GENRE]->(g)


        // ============================================================
        // USER WATCH HISTORY
        // ============================================================

        MATCH (u:User {id: 'user-1'})
        MATCH (m:Movie {id: 'movie-1'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-1'})
        MATCH (m:Movie {id: 'movie-2'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-1'})
        MATCH (m:Movie {id: 'movie-3'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-1'})
        MATCH (m:Movie {id: 'movie-11'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-2'})
        MATCH (m:Movie {id: 'movie-1'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-2'})
        MATCH (m:Movie {id: 'movie-4'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-2'})
        MATCH (m:Movie {id: 'movie-8'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-2'})
        MATCH (m:Movie {id: 'movie-14'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-3'})
        MATCH (m:Movie {id: 'movie-3'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-3'})
        MATCH (m:Movie {id: 'movie-6'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-3'})
        MATCH (m:Movie {id: 'movie-19'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-3'})
        MATCH (m:Movie {id: 'movie-20'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-4'})
        MATCH (m:Movie {id: 'movie-9'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-4'})
        MATCH (m:Movie {id: 'movie-10'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-4'})
        MATCH (m:Movie {id: 'movie-12'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-4'})
        MATCH (m:Movie {id: 'movie-18'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-5'})
        MATCH (m:Movie {id: 'movie-13'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-5'})
        MATCH (m:Movie {id: 'movie-15'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-5'})
        MATCH (m:Movie {id: 'movie-16'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-5'})
        MATCH (m:Movie {id: 'movie-17'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-6'})
        MATCH (m:Movie {id: 'movie-5'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-6'})
        MATCH (m:Movie {id: 'movie-6'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-6'})
        MATCH (m:Movie {id: 'movie-7'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-6'})
        MATCH (m:Movie {id: 'movie-2'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-7'})
        MATCH (m:Movie {id: 'movie-11'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-7'})
        MATCH (m:Movie {id: 'movie-12'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-7'})
        MATCH (m:Movie {id: 'movie-19'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-7'})
        MATCH (m:Movie {id: 'movie-20'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-8'})
        MATCH (m:Movie {id: 'movie-3'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-8'})
        MATCH (m:Movie {id: 'movie-14'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-8'})
        MATCH (m:Movie {id: 'movie-16'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-8'})
        MATCH (m:Movie {id: 'movie-17'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-9'})
        MATCH (m:Movie {id: 'movie-4'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-9'})
        MATCH (m:Movie {id: 'movie-5'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-9'})
        MATCH (m:Movie {id: 'movie-8'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-9'})
        MATCH (m:Movie {id: 'movie-13'})
        MERGE (u)-[:WATCHED]->(m)


        MATCH (u:User {id: 'user-10'})
        MATCH (m:Movie {id: 'movie-9'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-10'})
        MATCH (m:Movie {id: 'movie-18'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-10'})
        MATCH (m:Movie {id: 'movie-19'})
        MERGE (u)-[:WATCHED]->(m)

        MATCH (u:User {id: 'user-10'})
        MATCH (m:Movie {id: 'movie-20'})
        MERGE (u)-[:WATCHED]->(m)
        """;

        public static readonly IReadOnlyList<string> SeedStatements =
            Regex.Split(
                    SeedScript,
                    @"\r?\n\s*\r?\n")
                .Where(statement => statement.Contains("MERGE"))
                .Select(statement => statement.Trim())
                .ToList();
    }
}
