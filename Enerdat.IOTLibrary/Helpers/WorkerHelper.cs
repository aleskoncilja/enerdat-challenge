using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Enerdat.IOTLibrary.Helpers
{
    /// <summary>
    /// Worker helper.
    /// </summary>
    public static class WorkerHelper
    {
        /// <summary>
        /// Generate sequential worker parameters <seealso cref="Workers.IWorker.Parameters"/>.
        /// </summary>
        /// <returns></returns>
        public static List<Dictionary<string, dynamic>> GenerateSequentialWorkerParameters()
        {
            var workerParameters = new List<Dictionary<string, dynamic>>();

            var wParametersStep1 = new Dictionary<string, dynamic>();
            // Get password from database.
            dynamic process1 = new ExpandoObject();
            process1.Server = @"myServerName\myInstanceName";
            process1.Database = "myDataBase";
            process1.UserName = "myUsername";
            process1.Password = "myPassword";
            wParametersStep1.Add("PasswordFromDBProcess", process1);
            workerParameters.Add(wParametersStep1);

            var wParametersStep2 = new Dictionary<string, dynamic>();
            // Get data from IOT.
            dynamic process2 = new ExpandoObject();
            process2.Url = "https://www.enerdat.com/sl/GetTemperature";
            process2.UserName = "myUsername";
            process2.Password = "myPassword";
            wParametersStep2.Add("DataFromIOTProcess", process2);
            workerParameters.Add(wParametersStep2);

            var wParametersStep3 = new Dictionary<string, dynamic>();
            // Send data to RabbitMQ.
            dynamic process3 = new ExpandoObject();
            process3.UserName = "admin";
            process3.Password = "admin";
            process3.VirtualHost = "vh1";
            process3.HostName = "rabbitmq.local:15672";
            wParametersStep3.Add("SendToRabitMQProcess", process3);
            workerParameters.Add(wParametersStep3);

            return workerParameters;
        }

        /// <summary>
        /// Generate parallel worker parameters <seealso cref="Workers.IWorker.Parameters"/>.
        /// </summary>
        /// <returns></returns>
        public static List<Dictionary<string, dynamic>> GenerateParallelWorkerParameters()
        {
            var workerParameters = GenerateSequentialWorkerParameters();

            // Get data from API.
            dynamic process4 = new ExpandoObject();
            process4.Url = "https://www.enerdat.com/sl/GetCounterValue";
            process4.UserName = "myUsername";
            process4.Password = "myPassword";
            process4.DeviceId = Guid.NewGuid().ToString();
            workerParameters[1].Add("DataFromAPIProcess", process4);

            return workerParameters;
        }
    }
}
