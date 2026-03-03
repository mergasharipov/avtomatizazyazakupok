using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AppliancesProcurementApp
{
 public static class DbConfig
{
    // Адрес базы данных
    public static string ConnectionString = @"Data Source=109.233.236.26;Initial Catalog=AppliancesStoreDB;User ID=stud;Password=123456789;";
    
    // Данные о том, кто сейчас за компьютером
    public static int CurrentUserId;
    public static string CurrentUserName;
    public static string CurrentUserRole;
}
}