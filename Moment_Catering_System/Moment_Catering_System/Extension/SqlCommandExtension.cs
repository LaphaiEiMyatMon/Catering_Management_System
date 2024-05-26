using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.WebPages;
using Moment_Catering_System.Framework.Configuration;

public static class SqlCommandExtension
{
    public static void ApplySettings(this SqlCommand cm)
    {
        if (!FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.Is<int>())
        {
            throw new Exception();
        }

        cm.CommandTimeout = FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.To<int>();

    }

    public static void ApplySettings(this OleDbCommand cm)
    {
        if (!FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.Is<int>())
        {
            throw new Exception();
        }

        cm.CommandTimeout = FrameworkSettings.Default.SqlConnectionSettings.SqlCommandTimeoutSeconds.Value.To<int>();
    }
}
