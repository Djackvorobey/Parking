using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Windows.Input;

namespace API
{
    public class DataBase
    {

        public int GetOccupiedPlaces()
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                    string query = "SELECT COUNT(*) FROM Tickets";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        int rowCount = (int)command.ExecuteScalar();
                        return rowCount;
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Сталася помилка: GetOccupiedPlaces - " + ex.Message);
                return -1;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        
        public void UpdatePrice(double price)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                // Запит до бази даних
                string query = "UPDATE Price SET Price = @pr_new WHERE Id = 1";

                // Створення об'єкта команди для виконання запиту
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Передача значень параметрів в запит
                    command.Parameters.AddWithValue("@pr_new", price);


                    // Відкриття з'єднання з базою даних
                    connection.Open();
                    // Виконання запиту
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: SetTicketTax - " + ex.Message);
            }
            finally
            {
                // Закриття з'єднання з базою даних якщо воно відкрите
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public double GetPrice()
        {
            double price =0;
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                // Запит до бази даних
                string query = "SELECT *FROM Price WHERE Id = 1";

                // Створення об'єкта команди для виконання запиту
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Відкриття з'єднання з базою даних
                    connection.Open();
                    // Виконання запиту
                    reader = command.ExecuteReader();
                }
                if (reader.Read())
                {
                    price = reader.GetDouble(1);
                }

                return price;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: SetTicketTax - " + ex.Message);
                return price;
            }
            finally
            {
                // Закриття з'єднання з базою даних якщо воно відкрите
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                
            }
        }

        public void SetIsPaid(Ticket ticket)
        {
            // З'єднання з базою даних
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                // Запит до бази даних
                string query = "UPDATE Tickets SET isPaid = @Is WHERE NumberOfTicket = @nr";

                // Створення об'єкта команди для виконання запиту
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Передача значень параметрів в запит
                    command.Parameters.AddWithValue("@Is", ticket.isPaid);
                    command.Parameters.AddWithValue("@nr", ticket.numberofticket);


                    // Відкриття з'єднання з базою даних
                    connection.Open();
                    // Виконання запиту
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: SetTicketTax - " + ex.Message);
            }
            finally
            {
                // Закриття з'єднання з базою даних якщо воно відкрите
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void SetTicketTax(Ticket ticket)
        {
            // З'єднання з базою даних
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                // Запит до бази даних
                string query = "UPDATE Tickets SET Tax = @Tax WHERE NumberOfTicket = @nr";

                // Створення об'єкта команди для виконання запиту
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Передача значень параметрів в запит
                    command.Parameters.AddWithValue("@Tax", ticket.tax);
                    command.Parameters.AddWithValue("@nr", ticket.numberofticket);


                    // Відкриття з'єднання з базою даних
                    connection.Open();
                    // Виконання запиту
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: SetTicketTax - " + ex.Message);
            }
            finally
            {
                // Закриття з'єднання з базою даних якщо воно відкрите
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    
        public void SendTicketToDB(Ticket ticket)
        {
            // З'єднання з базою даних
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                // Запит до бази даних
                string query = "INSERT INTO Tickets (Date, Tax, NumberOfTicket, NrRejestracyjny, isPaid, line, place, floor, color) VALUES (@Date, @Tax, @NumberOfTicket, @NrRejestracyjny, @isPaid, @line, @place, @floor, @color)";

                // Створення об'єкта команди для виконання запиту
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Передача значень параметрів в запит
                    command.Parameters.AddWithValue("@Date", ticket.datetimeinput);
                    command.Parameters.AddWithValue("@Tax", ticket.tax);
                    command.Parameters.AddWithValue("@NumberOfTicket", ticket.numberofticket);
                    command.Parameters.AddWithValue("@NrRejestracyjny", ticket.nr_rej);
                    command.Parameters.AddWithValue("@isPaid", ticket.isPaid.ToString());
                    command.Parameters.AddWithValue("@line", ticket.line);
                    command.Parameters.AddWithValue("@place", ticket.place);
                    command.Parameters.AddWithValue("@floor", ticket.floor);
                    command.Parameters.AddWithValue("@color", ticket.color);

                    // Відкриття з'єднання з базою даних
                    connection.Open();
                    // Виконання запиту
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: SendTicketToDB - " + ex.Message);
            }
            finally
            {
                // Закриття з'єднання з базою даних якщо воно відкрите
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        } 

        public List<Ticket> GetAllTicketFromDB()
        {
            List<Ticket> ticket_list = new List<Ticket>();
            
            SqlDataReader reader;

            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                string query = "SELECT * FROM Tickets";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    connection.Open();
                    reader = command.ExecuteReader();
                    // Отримуємо значення стовпців рядка та зберігаємо їх в змінну
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket();
                        // Отримуємо значення стовпців рядка та зберігаємо їх в змінну
                        ticket.datetimeinput = reader.GetDateTime(0); // отримати значення першого стовпця
                        ticket.tax = reader.GetDouble(1); // отримати значення другого стовпця
                        ticket.numberofticket = reader.GetInt32(2);
                        ticket.nr_rej = reader.GetString(3);
                        ticket.isPaid = reader.GetBoolean(4);
                        ticket.line = reader.GetInt32(5);
                        ticket.place = reader.GetInt32(6);
                        ticket.floor = reader.GetInt32(7);
                        ticket.color = reader.GetString(8);

                        ticket_list.Add(ticket);
                    }

                    return ticket_list;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: GetTicketFromDB - " + ex.Message);
                return ticket_list;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public Ticket GetTicketFromDB_tk_nr(int ticket_number)
        {
            Ticket ticket = new Ticket();
            SqlDataReader reader;

            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                string query = "SELECT * FROM Tickets WHERE NumberOfTicket = @nr";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nr", ticket_number);
                    connection.Open();
                    reader = command.ExecuteReader();
                    // Отримуємо значення стовпців рядка та зберігаємо їх в змінну
                    if (reader.Read())
                    {
                        // Отримуємо значення стовпців рядка та зберігаємо їх в змінну
                        ticket.datetimeinput = reader.GetDateTime(0); // отримати значення першого стовпця
                        ticket.tax = reader.GetDouble(1); // отримати значення другого стовпця
                        ticket.numberofticket = reader.GetInt32(2);
                        ticket.nr_rej = reader.GetString(3);
                        ticket.isPaid = reader.GetBoolean(4);
                        ticket.line = reader.GetInt32(5);
                        ticket.place = reader.GetInt32(6);
                        ticket.floor = reader.GetInt32(7);
                        ticket.color = reader.GetString(8);

                    }

                    return ticket;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: GetTicketFromDB_tk_nr - " + ex.Message);
                return ticket;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        } 


        public Ticket GetTicketFromDB_nr_reg(string nr_registration)
        {
            Ticket ticket = new Ticket();
            SqlDataReader reader;

            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                string query = "SELECT * FROM Tickets WHERE NrRejestracyjny = @nr";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nr", nr_registration);
                    connection.Open();
                    reader = command.ExecuteReader();
                    // Отримуємо значення стовпців рядка та зберігаємо їх в змінну
                    if (reader.Read())
                    {
                        

                        // Отримуємо значення стовпців рядка та зберігаємо їх в змінну
                        ticket.datetimeinput = reader.GetDateTime(0); // отримати значення першого стовпця
                        ticket.tax = reader.GetDouble(1); // отримати значення другого стовпця
                        ticket.numberofticket = reader.GetInt32(2);
                        ticket.nr_rej = reader.GetString(3);
                        ticket.isPaid = reader.GetBoolean(4);
                        ticket.line = reader.GetInt32(5);
                        ticket.place = reader.GetInt32(6);
                        ticket.floor = reader.GetInt32(7);
                        ticket.color = reader.GetString(8);
                    }

                    return ticket;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: GetTicketFromDB_nr_reg - " + ex.Message);
                return ticket;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }  

        public List<int> GetAllNrTicket()
        {
            SqlDataReader reader;

            List<int> nrs_tieckets = new List<int>();

            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                
                string query = "SELECT NumberOfTicket FROM Tickets";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    connection.Open();
                    reader = command.ExecuteReader();
                    
                   while (reader.Read())
                    {
                      nrs_tieckets.Add(reader.GetInt32(0));
                    }

                    return nrs_tieckets;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: GetAllNrTicket - " + ex.Message);
                return nrs_tieckets;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public List<Point> GetAllBlockPlaces()
        {
            SqlDataReader reader;

            Point place = new Point();
            List<Point> all_block_place = new List<Point>();

            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {

                string query = "SELECT line, place FROM Tickets";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        place.X=reader.GetInt32(0);
                        place.Y = reader.GetInt32(1);
                        all_block_place.Add(place);
                    }

                    return all_block_place;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: GetAllNrTicket - " + ex.Message);
                return all_block_place;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void DeleteTicketFromDB(string registration_number)
        {
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Parking_DB;Integrated Security=True");
            try
            {
                string query = "DELETE FROM Tickets WHERE NrRejestracyjny = @nt;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nt", registration_number);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: DeleteTicketFromDB - " + ex.Message);
                
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
