﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows;
using _1125.Model;
using System.Data;
using System.Data.Common;

namespace _1125.DB
{
    public class UserDB
    {
        DBConnection connection;

        private UserDB(DBConnection db)
        {
            this.connection = db;
        }


        public bool Insert(User User)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                MySqlCommand cmd = connection.CreateCommand("insert into `user` Values (0,2, @login, @password );select LAST_INSERT_ID();");



                cmd.Parameters.Add(new MySqlParameter("login", User.Login));
               
                cmd.Parameters.Add(new MySqlParameter("password", User.Password));


                try
                {

                    int id = (int)(ulong)cmd.ExecuteScalar();
                    if (id > 0)
                    {
                       
                        User.Id = id;
                        result = true;
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не добавлен");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return result;
        }

        internal User Auth(string l, string p)
        {
            User user = new ();
            if (connection == null)
                return user;

            if (connection.OpenConnection())
            {
                var command = connection.CreateCommand("select user.`id`, `login`, `Password`, r.`name` from `user` join role r on r.Id = user.roleid where login = @login and Password = @password ");
                command.Parameters.Add(new MySqlParameter("login", l));
                command.Parameters.Add(new MySqlParameter("password", p));
                try
                {
                    MySqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string login = string.Empty;
                        if (!dr.IsDBNull(1))
                            login = dr.GetString("login");
                        string password = null;
                        if (!dr.IsDBNull(2))
                            password = dr.GetString("password");

                        user = new User
                        {
                            Id = id,
                            Login = login,                       
                            Password = password,
                             Role = dr.GetString("name")
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return user;
        }

        internal bool Update(User edit)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                var mc = connection.CreateCommand($"update `user` set `login`=@Login, `password`=@Password where `ID` = {edit.Id}");
                mc.Parameters.Add(new MySqlParameter("login", edit.Login));           
                mc.Parameters.Add(new MySqlParameter("password", edit.Password));
                try
                {
                    mc.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return result;
        }

        internal bool Remove(User remove)
        {
            bool result = false;
            if (connection == null)
                return result;

            if (connection.OpenConnection())
            {
                var mc = connection.CreateCommand($"delete from `user` where `id` = {remove.Id}");
                try
                {
                    mc.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            connection.CloseConnection();
            return result;
        }

        static UserDB db;
        public static UserDB GetDb()
        {
            if (db == null)
                db = new UserDB(DBConnection.GetDbConnection());
            return db;
        }

        internal object Auth(object login, object password)
        {
            throw new NotImplementedException();
        }
    }
}