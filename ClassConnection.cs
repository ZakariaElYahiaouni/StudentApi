


public class ClassConnection
{

    SqlConnection connection;
    SqlCommand command;
    SqlDataReader reader;


    public List<ToDoDTO> GetAllToDo(string str)
    {
        string connStr = str;
        List<ToDoDTO> result = new List<ToDoDTO>();
        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM toDoList", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ToDoDTO toDo = new ToDoDTO();
                toDo.Id = Convert.ToInt32(reader["Id"]);
                toDo.Title = reader["title"].ToString();
                toDo.Description = reader["descriptionDuty"].ToString();
                toDo.Done = reader["done"].ToString();
                result.Add(toDo);
            }
        }
        return result;
    }
    ToDoDTO result;
    public ToDoDTO GetToDoById(string str, int idRow)
    {
        string connStr = str;

        using (connection = new SqlConnection(connStr))
        {
            connection.Open();
            command = new SqlCommand("SELECT * FROM toDoList WHERE Id = " + idRow, connection);
            reader = command.ExecuteReader();
            result = new ToDoDTO();
            if (reader.HasRows)
            {
                reader.Read();

                result.Id = idRow;
                result.Title = reader["title"].ToString();
                result.Description = reader["descriptionDuty"].ToString();
                result.Done = reader["done"].ToString();

            }
        }
        return result;
    }

    public List<ToDoDTO> EditRow(string str, ToDoDTO updated)
    {
        string connStr = str;
        List<ToDoDTO> result = new List<ToDoDTO>();

        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();
            string query = "UPDATE toDoList SET title= @Title, descriptionDuty = @Description, done = @Done WHERE Id = @Id";
            SqlCommand commandEdit = new SqlCommand(query, connection);
            commandEdit.Parameters.AddWithValue("@Title", updated.Title);
            commandEdit.Parameters.AddWithValue("@Description", updated.Description);
            commandEdit.Parameters.AddWithValue("@Done", updated.Done);
            commandEdit.Parameters.AddWithValue("@Id", updated.Id);
            int rowsAffected = commandEdit.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM toDoList", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ToDoDTO toDo = new ToDoDTO();
                            toDo.Id = Convert.ToInt32(reader["Id"]);
                            toDo.Title = reader["title"].ToString();
                            toDo.Description = reader["descriptionDuty"].ToString();
                            toDo.Done = reader["done"].ToString();
                            result.Add(toDo);
                        }
                    }
                }
            }
        }
        return result;
    }


    public List<ToDoDTO> NewRow(string str, ToDoCreateDTO newToDo)
    {
        string connStr = str;
        List<ToDoDTO> result = new List<ToDoDTO>();

        using (connection = new SqlConnection(connStr))
        {

            /*
             INSERT INTO table_name (column1, column2, column3, ...)
                VALUES (value1, value2, value3, ...);
             */
            connection.Open();
            string query = "INSERT INTO toDoList (title, descriptionDuty, done) VALUES ('" + newToDo.Title + "', '" + newToDo.Description + "', 'n')";
            SqlCommand commandNew = new SqlCommand(query, connection);
            SqlDataReader rNew = commandNew.ExecuteReader();
            rNew.Close();
            SqlCommand command = new SqlCommand("SELECT * FROM toDoList", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ToDoDTO toDo = new ToDoDTO();
                toDo.Id = Convert.ToInt32(reader["Id"]);
                toDo.Title = reader["title"].ToString();
                toDo.Description = reader["descriptionDuty"].ToString();
                toDo.Done = reader["done"].ToString();
                result.Add(toDo);
            }

            reader.Close();
        }

        return result;
    }
    public List<ToDoDTO> DeleteRow(string str, int idRow)
    {
        string connStr = str;
        List<ToDoDTO> result = new List<ToDoDTO>();

        using (SqlConnection connection = new SqlConnection(connStr))
        {
            connection.Open();


            string adjustQuery = "DBCC CHECKIDENT ('toDoList', RESEED," + (idRow - 1) + ")";
            SqlCommand commandAdjustIncrement = new SqlCommand(adjustQuery, connection);
            SqlDataReader readerAdjustReader = commandAdjustIncrement.ExecuteReader();

            readerAdjustReader.Close();
            string query = "DELETE FROM toDoList WHERE Id = " + idRow;
            SqlCommand commandDelete = new SqlCommand(query, connection);
            SqlDataReader rDelete = commandDelete.ExecuteReader();

            rDelete.Close();
            SqlCommand command = new SqlCommand("SELECT * FROM toDoList", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ToDoDTO toDo = new ToDoDTO();
                toDo.Id = Convert.ToInt32(reader["Id"]);
                toDo.Title = reader["title"].ToString();
                toDo.Description = reader["descriptionDuty"].ToString();
                toDo.Done = reader["done"].ToString();
                result.Add(toDo);
            }

            reader.Close();
        }

        return result;
    }
}
