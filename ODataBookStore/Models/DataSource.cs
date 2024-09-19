using System.Collections.Generic; // Ensure this is imported

namespace ODataBookStore.Models
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }

        public static IList<Book> GetBooks()
        {
            if (listBooks != null)
            {
                return listBooks;
            }

            listBooks = new List<Book>();

            Book book = new Book
            {
                Id = 1,
                ISBN = "978-0-321-87758-1",
                Image = "https://i.pinimg.com/236x/bd/29/34/bd293499ee09b8fa4182f2ae24d83133.jpg",
                Title = "Essential C# 5.0",
                Author = "Mark Michaelis",
                Price = 59.99m,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D2, Thu Duc District"
                },
                Press = new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 2,
                ISBN = "978-0-596-52068-7",
                Image = "https://i.pinimg.com/236x/eb/90/33/eb903389ef7772f5312da745f5bc862d.jpg",
                Title = "Programming ASP.NET Core",
                Author = "Dino Esposito",
                Price = 45.99m,
                Location = new Address
                {
                    City = "New York",
                    Street = "5th Avenue"
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "Microsoft Press",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 3,
                ISBN = "978-0-13-235088-4",
                Image = "https://i.pinimg.com/236x/95/37/59/95375916ce1a570bccd1d20454a05f1b.jpg",
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Price = 49.99m,
                Location = new Address
                {
                    City = "Chicago",
                    Street = "North Michigan Ave"
                },
                Press = new Press
                {
                    Id = 3,
                    Name = "Prentice Hall",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            // Adding 10 more books
            listBooks.Add(new Book
            {
                Id = 4,
                ISBN = "978-1-118-69969-5",
                Image = "https://i.pinimg.com/236x/e3/48/83/e348831994111b27cd102cbcbbe5230d.jpg",
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                Price = 39.99m,
                Location = new Address
                {
                    City = "Boston",
                    Street = "Cambridge St"
                },
                Press = new Press
                {
                    Id = 4,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 5,
                ISBN = "978-1-491-94998-5",
                Image = "https://i.pinimg.com/236x/08/5c/25/085c2521dada2d536f00e48824112e2a.jpg",
                Title = "Designing Data-Intensive Applications",
                Author = "Martin Kleppmann",
                Price = 54.99m,
                Location = new Address
                {
                    City = "Berlin",
                    Street = "Unter den Linden"
                },
                Press = new Press
                {
                    Id = 5,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 6,
                ISBN = "978-0-470-04263-2",
                Image = "https://i.pinimg.com/236x/06/ef/10/06ef102a59086b41874a7830d3a1c538.jpg",
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen",
                Price = 74.99m,
                Location = new Address
                {
                    City = "Cambridge",
                    Street = "Massachusetts Ave"
                },
                Press = new Press
                {
                    Id = 6,
                    Name = "MIT Press",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 7,
                ISBN = "978-1-59327-950-9",
                Image = "https://i.pinimg.com/236x/6a/da/7e/6ada7efe59a7a13ca070da2fd16563b7.jpg",
                Title = "Eloquent JavaScript",
                Author = "Marijn Haverbeke",
                Price = 29.99m,
                Location = new Address
                {
                    City = "San Francisco",
                    Street = "Market St"
                },
                Press = new Press
                {
                    Id = 7,
                    Name = "No Starch Press",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 8,
                ISBN = "978-1-59327-424-5",
                Image = "https://i.pinimg.com/236x/ca/14/e7/ca14e7a7e21a75fd69b1f9d70ce94a94.jpg",
                Title = "Automate the Boring Stuff with Python",
                Author = "Al Sweigart",
                Price = 24.99m,
                Location = new Address
                {
                    City = "Los Angeles",
                    Street = "Hollywood Blvd"
                },
                Press = new Press
                {
                    Id = 8,
                    Name = "No Starch Press",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 9,
                ISBN = "978-1-59327-283-8",
                Image = "https://i.pinimg.com/236x/b1/15/72/b115729c7959227edebb3ae873af07b1.jpg",
                Title = "Python Crash Course",
                Author = "Eric Matthes",
                Price = 34.99m,
                Location = new Address
                {
                    City = "Seattle",
                    Street = "Pine St"
                },
                Press = new Press
                {
                    Id = 9,
                    Name = "No Starch Press",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 10,
                ISBN = "978-0-13-595705-9",
                Image = "https://i.pinimg.com/236x/d2/0b/29/d20b291bd20bf99262d4dbdc41ded105.jpg",
                Title = "Artificial Intelligence: A Guide for Thinking Humans",
                Author = "Melanie Mitchell",
                Price = 29.99m,
                Location = new Address
                {
                    City = "London",
                    Street = "Baker Street"
                },
                Press = new Press
                {
                    Id = 10,
                    Name = "Penguin Press",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 11,
                ISBN = "978-1-59327-599-0",
                Title = "JavaScript: The Good Parts",
                Image = "https://i.pinimg.com/236x/0e/a3/c3/0ea3c37532b3009f61cc327db9c90efa.jpg",
                Author = "Douglas Crockford",
                Price = 19.99m,
                Location = new Address
                {
                    City = "Paris",
                    Street = "Champs-Élysées"
                },
                Press = new Press
                {
                    Id = 11,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            });

            listBooks.Add(new Book
            {
                Id = 12,
                ISBN = "978-0-262-03384-8",
                Title = "Deep Learning",
                Image = "https://i.pinimg.com/236x/cc/b0/6a/ccb06a76cc56b397c57a7e001f7d6614.jpg",
                Author = "Ian Goodfellow",
                Price = 89.99m,
                Location = new Address
                {
                    City = "Tokyo",
                    Street = "Shibuya"
                },
                Press = new Press
                {
                    Id = 12,
                    Name = "MIT Press",
                    Category = Category.Book
                }
            });

            return listBooks;
        }
    }
}
