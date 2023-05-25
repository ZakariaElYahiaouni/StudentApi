


    public class ClassConnection
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

    
        public ToDoDTO GetAllToDo(string str)
        {
            string connStr = str;
            ToDoDTO result = null;
            using (connection = new SqlConnection(connStr))
            {
                connection.Open();
                command = new SqlCommand("SELECT * FROM toDoList", connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    result = new ToDoDTO(); 
                    result.Title = reader["title"].ToString();
                    result.Description = reader["descriptionDuty"].ToString();
                    result.Done = reader["done"].ToString();

                }
            }
            return result;
        }
        public ToDoDTO GetToDo(string str, int idRow)
        {
            string connStr = str;
            ToDoDTO result = null;
            using (connection = new SqlConnection(connStr))
            {
                connection.Open();
                command = new SqlCommand("SELECT * FROM toDoList WHERE Id = " + idRow, connection);
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    result = new ToDoDTO();
                    result.Id = idRow;
                    result.Title = reader["title"].ToString();
                    result.Description = reader["descriptionDuty"].ToString();
                    result.Done = reader["done"].ToString();

                }
            }
            return result;
        }


        public void EditRow(string str, int idRow, string txt_title, string txt_descriptionDuty, string done)
        {

            string connStr = str;

            using (connection = new SqlConnection(connStr))
            {
                connection.Open();
                string query = "UPDATE toDoList SET title = '" + txt_title + "', descriptionDuty = '" + txt_descriptionDuty + "', done ='" + done + "' WHERE Id = " + idRow + "";
                SqlCommand commandEdit = new SqlCommand(query, connection);
                SqlDataReader readerEdit = commandEdit.ExecuteReader();
            }

        }
        public void NewRow(string str,string txt_title, string txt_descriptionDuty)
        {
            string connStr = str;


            using (connection = new SqlConnection(connStr))
            {

                /*
                 INSERT INTO table_name (column1, column2, column3, ...)
                    VALUES (value1, value2, value3, ...);
                 */
                connection.Open();
                string query = "INSERT INTO toDoList (title, descriptionDuty, done) VALUES ('" + txt_title + "', '" + txt_descriptionDuty + "', 'n')";
                SqlCommand commandNew = new SqlCommand(query, connection);
                SqlDataReader rNew = commandNew.ExecuteReader();
            }


        }
        public void DeleteRow(string str, int idRow)
        {
            string connStr = str;
            using (connection = new SqlConnection(connStr))
            {
                connection.Open();
                string adjustQuery = "DBCC CHECKIDENT ('toDoList', RESEED," + (idRow - 1) + ")";

                SqlCommand commandAdjustIncrement = new SqlCommand(adjustQuery, connection);
                SqlDataReader readerAdjustReader = commandAdjustIncrement.ExecuteReader();
            }
            using (connection = new SqlConnection(connStr))
            {
                //DELETE FROM table_name WHERE condition;
                connection.Open();

                string query = "DELETE FROM toDoList WHERE Id = " + idRow + "";

                SqlCommand commandDelete = new SqlCommand(query, connection);
                SqlDataReader rDelete = commandDelete.ExecuteReader();




            }

            
        } 

    }
