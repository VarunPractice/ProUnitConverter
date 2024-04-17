using Microsoft.Data.SqlClient;
using ProUnitConverter.Models;
using System.Configuration;
using System.Data;

public class UnitDAL
{
    private readonly string _connectionString;

    public UnitDAL()
    {
        _connectionString = Environment.GetEnvironmentVariable("PUCConnectionString"); ;

    }

    public List<UnitModel> GetAllUnits()
    {
        var units = new List<UnitModel>();
        using (var connection = new SqlConnection(_connectionString))
        {
            var cmd = new SqlCommand("sp_GetAllUnits", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var unit = new UnitModel
                        {
                            UnitID = reader.GetInt32(reader.GetOrdinal("UnitId")),
                            Name = reader.GetString(reader.GetOrdinal("UnitName"))
                        };
                        units.Add(unit);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            var subunit = new SubunitModel
                            {
                                SubunitId = reader.GetInt32(reader.GetOrdinal("SubunitId")),
                                Name = reader.GetString(reader.GetOrdinal("SubunitName")),
                                UnitId = reader.GetInt32(reader.GetOrdinal("UnitId"))
                            };
                            var parentUnit = units.Find(u => u.UnitID == subunit.UnitId);
                            if (parentUnit != null)
                            {
                                parentUnit.Subunits.Add(subunit);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sharedResources.GlobalExceptionHandling.ExceptionHandler.Instance.RegisterGlobalExceptionHandler(ex);
            }
        }
        return units;
    }
}
