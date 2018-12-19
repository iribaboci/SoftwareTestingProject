﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFrameworkLogin.Siniflar;

namespace MetroFrameworkLogin.Siniflar
{
    public class TestFunctions
    {
        ConnectionClass con = new ConnectionClass();

        public TestFunctions()
        {

        }
        public bool girisYapiliyor(string username, string password)
        {
            using (SqlCommand cmd = new SqlCommand("sp_Login", con.mySqlConnection()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                if (dt.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
                con.sqlConnectionClose();
                throw new InvalidOperationException();
            }
        }
        public bool AdetSayi(string adet)
        {
            if (IsDigit(adet))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new InvalidOperationException();
        }
        public bool AdetBos(string adet)
        {
            if(adet.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new InvalidOperationException();
        }
        public bool adetSifirIleMiBasliyor(string adet)
        {
            if(adet.StartsWith(0.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new InvalidOperationException();
        }

        //public bool 


        public bool IsDigit(string value)
        {
            int sayac = 0;
            foreach (char i in value)
            {
                if (char.IsDigit(i))
                {
                    sayac++;
                }
            }
            if (sayac == value.Length)
            {
                return true;
            }
            return false;
        }
        public bool IsLetter(string value)
        {
            int sayac = 0;
            foreach (char i in value)
            {
                if (char.IsLetter(i))
                {
                    sayac++;
                }
            }
            if (sayac == value.Length)
            {
                return true;
            }
            return false;
        }
        public bool IsPunctuation(string value)
        {
            int sayac = 0;
            foreach (char i in value)
            {
                if (char.IsPunctuation(i))
                {
                    sayac++;
                }
            }
            if (sayac == value.Length)
            {
                return true;
            }
            return false;
        }
        public bool IsWhitespace(string value)
        {
            int sayac = 0;
            foreach (char i in value)
            {
                if (char.IsWhiteSpace(i))
                {
                    sayac++;
                }
            }
            if (sayac == value.Length)
            {
                return true;
            }
            return false;
        }
        
        public bool SQLInjection(string value)
        {
            int sayac = 0;
            foreach (char i in value)
            {
                if (i.Equals("'"))
                {
                    sayac++;
                }
            }
            if (sayac >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
