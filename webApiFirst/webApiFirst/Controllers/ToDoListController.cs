using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web;
using System.Configuration;
using webApiFirst.App_Start;
using System.Web.Mvc;
using System.Text;
using System.Net.Http.Headers;
using webApiFirst.Models;
using System.Web.Helpers;


namespace webApiFirst.Controllers
{
    public class ToDoListController : ApiController
    {
        //CRUD create read upadte delete
        //打某隻 post api 可以新增一個 todo 事件。
        public IHttpActionResult POST(string name)
        {
            
            MySqlConnection conn = DBconfig.register();
            conn.Open();
            List<MsgModels> response = new List<MsgModels>();
            string insertSql = "INSERT INTO list (name) VALUES ('" + @name + "')";
          
            MsgModels msg = new MsgModels();
            try
                {
                MySqlCommand cmd = new MySqlCommand(insertSql, conn);
                cmd.Parameters.AddWithValue(@name, name);
                cmd.ExecuteNonQuery();
                msg.success = true;
                msg.todoName = name;
                response.Add(msg);

            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                conn.Close();
            }
            return Ok(msg.success);
            
        }

        //打某隻 get api 可以取得所有的 todo 事件
        public IHttpActionResult GET()
        {
            MsgModels msg = new MsgModels();
           
            List<TodoModel> list = new List<TodoModel>();
            MySqlConnection conn = DBconfig.register();
            conn.Open();
            
            string selectSql = "SELECT * FROM list WHERE deleted_at IS NULL ";
            try
            {
                MySqlCommand cmd = new MySqlCommand(selectSql, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TodoModel todo = new TodoModel();
                    todo.id = reader["id"].ToString();
                    todo.name = reader["name"].ToString();
                    todo.deleted_at = reader["deleted_at"].ToString();  
                    list.Add(todo);
                }                
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                conn.Close();
            }
            return Ok(list);

        }

        
        // 打某隻 delete api 可以移除某個 todo 事件。
        //update delTime
        public IHttpActionResult DELETE(string listNo)
        {
          
            string sysTime = DateTime.Now.ToString("yyyy/MM/dd");

            MsgModels msg = new MsgModels();
            MySqlConnection conn = DBconfig.register();
            conn.Open();

            string updateSql = "UPDATE list SET deleted_at = '" + sysTime + "' WHERE id = '" + @listNo + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(updateSql, conn);
                cmd.Parameters.AddWithValue(@listNo, listNo);
                cmd.ExecuteNonQuery();
                msg.success = true;
                msg.todoName = listNo;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                conn.Close();
            }
            return Ok(msg.todoName);
        }

        
        public IHttpActionResult PUT(string listNo, string newListName)
        {

            MsgModels msg = new MsgModels();
            MySqlConnection conn = DBconfig.register();
            conn.Open();
            string updateSql = "UPDATE list SET name = '" + @newListName + "' WHERE id = '" + @listNo + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(updateSql, conn);
                cmd.Parameters.AddWithValue(@newListName, newListName);
                cmd.Parameters.AddWithValue(@listNo, listNo);
                cmd.ExecuteNonQuery();
                msg.todoName = newListName;
                msg.success = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return Ok(msg.todoName);
            //return Json<MsgModels>(msg);

        }
        
    }
}
