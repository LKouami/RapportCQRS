//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace LBMS.Reporting.Helpers
//{
//    public class CustomReportResolver : Telerik.Reporting.Services.Engine.IReportResolver
//    {
//        public CustomReportResolver()
//        {

//        }
//        public Telerik.Reporting.ReportSource Resolve(string reportId)
//        {
//            var cmdText = "SELECT Definition FROM Reports WHERE ID = @ReportId";

//            var reportXml = "";
//            using (var conn = new System.Data.SqlClient.SqlConnection(@"server=(local)\sqlexpress;database=REPORTS;integrated security=true;"))
//            {
//                var command = new System.Data.SqlClient.SqlCommand(cmdText, conn);
//                command.Parameters.Add("@ReportId", System.Data.SqlDbType.Int);
//                command.Parameters["@ReportId"].Value = reportId;

//                try
//                {
//                    conn.Open();
//                    reportXml = (string)command.ExecuteScalar();
//                }
//                catch (System.Exception ex)
//                {
//                    System.Diagnostics.Trace.WriteLine(ex.Message);
//                }
//            }

//            if (string.IsNullOrEmpty(reportXml))
//            {
//                throw new System.Exception("Unable to load a report with the specified ID: " + reportId);
//            }

//            return new Telerik.Reporting.XmlReportSource { Xml = reportXml };
//        }
//    }
//}
