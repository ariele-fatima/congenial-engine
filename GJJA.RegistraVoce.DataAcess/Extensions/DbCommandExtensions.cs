using System.Data.Common;

namespace GJJA.RegistraVoce.DataAcess.Extensions
{
    public static class DbCommandExtensions
    {
        public static void SetParameter<TParameterType>(this DbCommand command, string parameterName, TParameterType parameterValue)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);

        }

    }
}