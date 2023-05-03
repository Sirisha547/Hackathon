namespace Hackathon
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        
    }
    class Management
    {
        List<Note> notes;
        int count = 1;
        public Management()
        {
            notes = new List<Note>()
            {
                
                new Note {Id = 1,Title = "Meeting", Description ="Meeting with Client", Date = new DateTime(2022,2,10) },
                new Note {Id = 2, Title = "PayBills", Description ="Pay Electricity Bills", Date = new DateTime(2022,2,12) }
            };
        }
        public void CreateNote(Note note)
        {
            count++;
            notes.Add(note);
        }
        public int GenerateNoteId(string title)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9999);
            return randomNumber;
        }
        public Note ViewNote(int id)
        {
            foreach (Note note in notes)
            {
                if (note.Id == id)
                    return note;
            }
            return null;
        }
        public List<Note> ViewAllNotes()
        {
            return notes;
            //Console.WriteLine($"Total Notes\t{notes.Count}");
        }
        public bool UpdateNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    Console.WriteLine("Enter updated Details");

                    Console.WriteLine("Enter updated Id");
                    n.Id = Convert.ToInt32(Console.ReadLine());


                    return true;

                }


            }
            return false;
        }
        public bool DeleteNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    notes.Remove(n);
                    return true;
                }
            }
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Management m = new Management();
            while (true)
            {
                Console.WriteLine("Welcome to Take Note App ");
                Console.WriteLine("1. CreateNote");
                Console.WriteLine("2. ViewNote by id");
                Console.WriteLine("3. ViewAllNotes");
                Console.WriteLine("4. UpdateNote by id");
                Console.WriteLine("5. DeleteNote by id");

                int ch = 0;
                try
                {
                    Console.WriteLine("enter ur choice");
                    ch = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {

                    Console.WriteLine("Enter only Numbers");
                }
                switch (ch)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Note Title");
                            string title = Convert.ToString(Console.ReadLine());

                            Console.WriteLine("Enter Description");
                            string description = Convert.ToString(Console.ReadLine());


                            DateTime date = DateTime.Now;
                            m.CreateNote(new Note()
                            {
                                Title = title,
                                Description = description,
                                Date = date

                            });
                            break;

                        }
                    case 2:
                        {
                            Console.WriteLine("Get Note by ID");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Note? n = m.ViewNote(id);
                            if (n == null)
                            {
                                Console.WriteLine("Note with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($"{n.Id} {n.Title} {n.Description} {n.Date}");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Id\t Title\t\t\t Description\t\t\t Date");
                            foreach (var n in m.ViewAllNotes())
                            {
                                Console.WriteLine($"{n.Id}\t {n.Title}\t {n.Description}\t {n.Date}");
                            }
                            
                            //Console.WriteLine($"Total Notes\t {m.count}");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Note id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (m.UpdateNote(id))
                            {
                                Console.WriteLine("Note Detail Updated Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Note with specified id does not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter note id");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (m.DeleteNote(id))
                            {
                                Console.WriteLine("CNote Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Note with specified id does not exist");
                            }
                            break;
                        }

                }

            }

        }

    }
}
