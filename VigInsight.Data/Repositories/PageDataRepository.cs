using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;

namespace VigInsight.Data.Repositories
{
    public class PageDataRepository : IPageDataService
    {
        private readonly string _connectionString;

        public PageDataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public object GetPageData(int pageId)
        {
            return pageId switch
            {
                3 => GetPage3Data(),
                5 => GetPage5Data(),
                7 => GetPage7Data(),
                10 => GetPage10Data(),
                11 => GetPage11Data(),
                14 => GetPage14Data(),
                15 => GetPage15Data(),
                18 => GetPage18Data(),
                20 => GetPage20Data(),
                21 => GetPage21Data(),
                26 => GetPage26Data(),
                29 => GetPage29Data(),
                32 => GetPage32Data(),
                34 => GetPage34Data(),
                44 => GetPage44Data(),
                53 => GetPage53Data(),
                _ => null
            };
        }

      
        public Page3Model GetPage3Data()
        {

            Page3Model page3Model = new Page3Model();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage3 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            page3Model.DataId = Convert.ToInt32(reader["DataId"]);

                            page3Model.FlowSlow1 = FormatToDecimalString(reader["FlowSlow1"], 3, 1);
                            page3Model.FlowFast = FormatToDecimalString(reader["FlowFast"], 3, 1);
                            page3Model.FlowSlow2 = FormatToDecimalString(reader["FlowSlow2"], 3, 1);
                            page3Model.FlowSafety = FormatToDecimalString(reader["FlowSafety"], 3, 1);
                            page3Model.FlowLocking = FormatToDecimalString(reader["FlowLocking"], 3, 1);

                            page3Model.PressureSlow1 = FormatToDecimalString(reader["PressureSlow1"], 3, 0);
                            page3Model.PressureFast = FormatToDecimalString(reader["PressureFast"], 3, 0);
                            page3Model.PressureSlow2 = FormatToDecimalString(reader["PressureSlow2"], 3, 0);
                            page3Model.PressureSafety = FormatToDecimalString(reader["PressureSafety"], 3, 0);
                            page3Model.PressureLocking = FormatToDecimalString(reader["PressureLocking"], 3, 0);

                            page3Model.PositionSlow1 = FormatToDecimalString(reader["PositionSlow1"], 5, 1);
                            page3Model.PositionFast = FormatToDecimalString(reader["PositionFast"], 5, 1);
                            page3Model.PositionSlow2 = FormatToDecimalString(reader["PositionSlow2"], 5, 1);
                            page3Model.PositionSafety = FormatToDecimalString(reader["PositionSafety"], 5, 1);
                            page3Model.PositionLocking = FormatToDecimalString(reader["PositionLocking"], 5, 1);

                            page3Model.SpeedSlow1 = FormatToDecimalString(reader["SpeedSlow1"], 3, 0);
                            page3Model.SpeedFast = FormatToDecimalString(reader["SpeedFast"], 3, 0);
                            page3Model.SpeedSlow2 = FormatToDecimalString(reader["SpeedSlow2"], 3, 0);
                            page3Model.SpeedSafety = FormatToDecimalString(reader["SpeedSafety"], 3, 0);

                            page3Model.ActStageTimeSlow1 = FormatToDecimalString(reader["ActStageTimeSlow1"], 4, 2);
                            page3Model.ActStageTimeFast = FormatToDecimalString(reader["ActStageTimeFast"], 4, 2);
                            page3Model.ActStageTimeSlow2 = FormatToDecimalString(reader["ActStageTimeSlow2"], 4, 2);
                            page3Model.ActStageTimeSafety = FormatToDecimalString(reader["ActStageTimeSafety"], 4, 2);
                            page3Model.ActStageTimeLocking = FormatToDecimalString(reader["ActStageTimeLocking"], 4, 2);


                            page3Model.MoldCloseTimeSet = FormatToDecimalString(reader["MoldCloseTimeSet"], 4, 2);
                            page3Model.MoldSafetyTimeSet = FormatToDecimalString(reader["MoldSafetyTimeSet"], 4, 2);
                            page3Model.LockingTimeSet = FormatToDecimalString(reader["LockingTimeSet"], 4, 2);

                            page3Model.SetModeFlow = FormatToDecimalString(reader["SetModeFlow"], 3, 1);
                            page3Model.SetModePressure = FormatToDecimalString(reader["SetModePressure"], 3, 0);


                            page3Model.ActualForce = FormatToDecimalString(reader["ActualForce"], 3, 0);
                            page3Model.ClampPosition = FormatToDecimalString(reader["ClampPosition"], 5, 1);

                            page3Model.MoldCloseTimeActual = FormatToDecimalString(reader["MoldCloseTimeActual"], 4, 2);
                            page3Model.MoldSafetyTimeActual = FormatToDecimalString(reader["MoldSafetyTimeActual"], 4, 2);
                            page3Model.LockingTimeActual = FormatToDecimalString(reader["LockingTimeActual"], 4, 2);

                            page3Model.MoldCloseTimeLast = FormatToDecimalString(reader["MoldCloseTimeLast"], 4, 2);
                            page3Model.MoldSafetyTimeLast = FormatToDecimalString(reader["MoldSafetyTimeLast"], 4, 2);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading Page 3 data: " + ex.Message);
            }

            return page3Model;
        }
        public Page5Model GetPage5Data()
        {

            Page5Model page5Model = new Page5Model();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "select top 1 * from tblPage5 order by DataId desc"; // Modify if you filter by active or top 1
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            page5Model.FlowDecomp = Convert.ToString(FormatToDecimalString(reader["FlowDecomp"], 3, 1));
                            page5Model.PressureDecomp = Convert.ToString(FormatToDecimalString(reader["PressureDecomp"], 3, 0));
                            page5Model.TimeDecomp = Convert.ToString(FormatToDecimalString(reader["TimeDecomp"], 4, 2));

                            page5Model.ActStageTimeDecomp = Convert.ToString(FormatToDecimalString(reader["ActStageTimeDecomp"], 4, 2));

                            page5Model.FlowSlow1 = Convert.ToString(FormatToDecimalString(reader["FlowSlow1"], 3, 1));
                            page5Model.PressureSlow1 = Convert.ToString(FormatToDecimalString(reader["PressureSlow1"], 3, 0));
                            page5Model.PositionSlow1 = Convert.ToString(FormatToDecimalString(reader["PositionSlow1"], 5, 1));

                            page5Model.SpeedSlow1 = Convert.ToString(FormatToDecimalString(reader["SpeedSlow1"], 3, 0));
                            page5Model.ActStageTimeSlow1 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeSlow1"], 4, 2));

                            page5Model.FlowFast = Convert.ToString(FormatToDecimalString(reader["FlowFast"], 3, 1));
                            page5Model.PressureFast = Convert.ToString(FormatToDecimalString(reader["PressureFast"], 3, 0));
                            page5Model.PositionFast = Convert.ToString(FormatToDecimalString(reader["PositionFast"], 5, 1));
                            page5Model.SpeedFast = Convert.ToString(FormatToDecimalString(reader["SpeedFast"], 3, 0));
                            page5Model.ActStageTimeFast = Convert.ToString(FormatToDecimalString(reader["ActStageTimeFast"], 4, 2));

                            page5Model.FlowSlow2 = Convert.ToString(FormatToDecimalString(reader["FlowSlow2"], 3, 1));
                            page5Model.PressureSlow2 = Convert.ToString(FormatToDecimalString(reader["PressureSlow2"], 3, 0));
                            page5Model.PositionSlow2 = Convert.ToString(FormatToDecimalString(reader["PositionSlow2"], 5, 1));
                            page5Model.TimeSlow2 = Convert.ToString(FormatToDecimalString(reader["TimeSlow2"], 4, 2));

                            page5Model.SpeedSlow2 = Convert.ToString(FormatToDecimalString(reader["SpeedSlow2"], 3, 0));
                            page5Model.ActStageTimeSlow2 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeSlow2"], 4, 2));

                            page5Model.FlowSlow3 = Convert.ToString(FormatToDecimalString(reader["FlowSlow3"], 3, 1));
                            page5Model.PressureSlow3 = Convert.ToString(FormatToDecimalString(reader["PressureSlow3"], 3, 0));
                            page5Model.PositionSlow3 = Convert.ToString(FormatToDecimalString(reader["PositionSlow3"], 5, 1));
                            page5Model.SpeedSlow3 = Convert.ToString(FormatToDecimalString(reader["SpeedSlow3"], 3, 0));
                            page5Model.ActStageTimeSlow3 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeSlow3"], 3, 1));

                            //page5Model.PositionDecomp = Convert.ToString(FormatToDecimalString(reader["PositionDecomp"], 4, 1));
                            //page5Model.TimeSlow3 = Convert.ToString(FormatToDecimalString(reader["TimeSlow3"], 3, 1));
                            //page5Model.TimeFast = Convert.ToString(FormatToDecimalString(reader["TimeFast"], 3, 1));
                            //page5Model.TimeSlow1 = Convert.ToString(FormatToDecimalString(reader["TimeSlow1"], 3, 1));
                            //page5Model.SpeedDecomp = Convert.ToString(FormatToDecimalString(reader["SpeedDecomp"], 3, 1));

                            page5Model.ClampPosition = Convert.ToString(FormatToDecimalString(reader["ClampPosition"], 5, 1));
                            page5Model.SetModeFlow = Convert.ToString(FormatToDecimalString(reader["SetModeFlow"], 3, 1));
                            page5Model.SetModePressure = Convert.ToString(FormatToDecimalString(reader["SetModePressure"], 3, 0));

                            //page5Model.IsActive = Convert.ToBoolean(reader["IsActive"]);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            return page5Model;
        }
        public Page7Model GetPage7Data()
        {
            Page7Model model = new Page7Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage7 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.NoOfRepeatsSet = Convert.ToString(FormatToDecimalString(reader["NoOfRepeatsSet"], 1, 0));

                            var EjectorSelection = Convert.ToString(reader["EjectorSelection"]);
                            model.EjectorSelection = EjectorSelection == "0" ? "Inactive" :
                                                   EjectorSelection == "1" ? "Stay Fwd" :
                                                   EjectorSelection == "2" ? "Repeated" : "";

                            model.FlowFwd1 = Convert.ToString(FormatToDecimalString(reader["FlowFwd1"], 3, 1));
                            model.PressureFwd1 = Convert.ToString(FormatToDecimalString(reader["PressureFwd1"], 3, 0));
                            model.PositionFwd1 = Convert.ToString(FormatToDecimalString(reader["PositionFwd1"], 4, 1));
                            model.TimeFwd1 = Convert.ToString(FormatToDecimalString(reader["TimeFwd1"], 4, 2));
                            model.OffDelayFwd1 = Convert.ToString(FormatToDecimalString(reader["OffDelayFwd1"], 4, 2));
                            model.FlowFwd2 = Convert.ToString(FormatToDecimalString(reader["FlowFwd2"], 3, 1));
                            model.PressureFwd2 = Convert.ToString(FormatToDecimalString(reader["PressureFwd2"], 3, 0));
                            model.PositionFwd2 = Convert.ToString(FormatToDecimalString(reader["PositionFwd2"], 4, 1));
                            model.TimeFwd2 = Convert.ToString(FormatToDecimalString(reader["TimeFwd2"], 4, 2));
                            model.OffDelayFwd2 = Convert.ToString(FormatToDecimalString(reader["OffDelayFwd2"], 4, 2));
                            model.FlowRet2 = Convert.ToString(FormatToDecimalString(reader["FlowRet2"], 3, 1));
                            model.PressureRet2 = Convert.ToString(FormatToDecimalString(reader["PressureRet2"], 3, 0));
                            model.PositionRet2 = Convert.ToString(FormatToDecimalString(reader["PositionRet2"], 4, 1));
                            model.TimeRet2 = Convert.ToString(FormatToDecimalString(reader["TimeRet2"], 4, 2));
                            model.OffDelayRet2 = Convert.ToString(FormatToDecimalString(reader["OffDelayRet2"], 4, 2));
                            model.FlowRet1 = Convert.ToString(FormatToDecimalString(reader["FlowRet1"], 3, 1));
                            model.PressureRet1 = Convert.ToString(FormatToDecimalString(reader["PressureRet1"], 3, 0));
                            model.PositionRet1 = Convert.ToString(FormatToDecimalString(reader["PositionRet1"], 4, 1));
                            model.TimeRet1 = Convert.ToString(FormatToDecimalString(reader["TimeRet1"], 4, 2));
                            model.OffDelayRet1 = Convert.ToString(FormatToDecimalString(reader["OffDelayRet1"], 4, 2));
                            model.FlowBack = Convert.ToString(FormatToDecimalString(reader["FlowBack"], 3, 1));
                            model.PressureBack = Convert.ToString(FormatToDecimalString(reader["PressureBack"], 3, 0));
                            model.PositionBack = Convert.ToString(FormatToDecimalString(reader["PositionBack"], 4, 1));
                            model.TimeBack = Convert.ToString(FormatToDecimalString(reader["TimeBack"], 4, 2));
                            model.OffDelayBack = Convert.ToString(FormatToDecimalString(reader["OffDelayBack"], 4, 2));
                            model.FlowFront = Convert.ToString(FormatToDecimalString(reader["FlowFront"], 3, 1));
                            model.PressureFront = Convert.ToString(FormatToDecimalString(reader["PressureFront"], 3, 0));
                            model.PositionFront = Convert.ToString(FormatToDecimalString(reader["PositionFront"], 4, 1));
                            model.TimeFront = Convert.ToString(FormatToDecimalString(reader["TimeFront"], 4, 2));
                            model.OffDelayFront = Convert.ToString(FormatToDecimalString(reader["OffDelayFront"], 4, 2));

                            model.EjectorStartPosition = Convert.ToString(FormatToDecimalString(reader["EjectorStartPosition"], 5, 1));
                            model.EjectorStartDelay = Convert.ToString(FormatToDecimalString(reader["EjectorStartDelay"], 4, 2));

                            var EjectorRetractSolenoids = Convert.ToString(reader["EjectorRetractSolenoids"]);
                            model.EjectorRetractSolenoids = EjectorRetractSolenoids == "0" ? "Disable" : "Enabled";

                            var EjectorRetractLSW10 = Convert.ToString(reader["EjectorRetractLSW10"]);
                            model.EjectorRetractLSW10 = EjectorRetractLSW10 == "0" ? "Disable" : "Enabled";

                            model.Executed = Convert.ToString(FormatToDecimalString(reader["Executed"], 1, 0));
                            model.PresentStage = Convert.ToString(FormatToDecimalString(reader["PresentStage"], 2, 0));
                            model.EjectorTime = Convert.ToString(FormatToDecimalString(reader["EjectorTime"], 4, 2));

                            model.SpeedFwd1 = Convert.ToString(FormatToDecimalString(reader["SpeedFwd1"], 3, 0));
                            model.SpeedFwd2 = Convert.ToString(FormatToDecimalString(reader["SpeedFwd2"], 3, 0));
                            model.SpeedRet2 = Convert.ToString(FormatToDecimalString(reader["SpeedRet2"], 3, 0));
                            model.SpeedRet1 = Convert.ToString(FormatToDecimalString(reader["SpeedRet1"], 3, 0));
                            model.SpeedBack = Convert.ToString(FormatToDecimalString(reader["SpeedBack"], 3, 0));
                            model.SpeedFront = Convert.ToString(FormatToDecimalString(reader["SpeedFront"], 3, 0));

                            model.HydEjectPos = Convert.ToString(FormatToDecimalString(reader["HydEjectPos"], 5, 1));

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception
                throw;
            }

            return model;
        }
        public Page10Model GetPage10Data()
        {
            Page10Model model = new Page10Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage10 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //model.DataId = Convert.ToInt32(reader["DataId"]);
                            model.PresentStage = Convert.ToString(FormatToDecimalString(reader["PresentStage"], 1, 0));

                            model.StageTime = Convert.ToString(FormatToDecimalString(reader["StageTime"], 4, 2));

                            var CoreSelection = Convert.ToString(reader["CoreSelection"]);
                            model.CoreSelection = CoreSelection == "0" ? "Disable" : "Enabled";

                            model.CoreSequence = Convert.ToString(FormatToDecimalString(reader["CoreSequence"], 2, 0));

                            model.ONDelayCoreIn = Convert.ToString(FormatToDecimalString(reader["ONDelayCoreIn"], 3, 2));
                            model.ONDelayCoreOut = Convert.ToString(FormatToDecimalString(reader["ONDelayCoreOut"], 3, 2));

                            model.FlowCoreIn = Convert.ToString(FormatToDecimalString(reader["FlowCoreIn"], 3, 1));
                            model.FlowCoreOut = Convert.ToString(FormatToDecimalString(reader["FlowCoreOut"], 3, 1));

                            model.PressureCoreIn = Convert.ToString(FormatToDecimalString(reader["PressureCoreIn"], 3, 0));
                            model.PressureCoreOut = Convert.ToString(FormatToDecimalString(reader["PressureCoreOut"], 3, 0));

                            model.PositionCoreIn = Convert.ToString(FormatToDecimalString(reader["PositionCoreIn"], 5, 1));
                            model.PositionCoreOut = Convert.ToString(FormatToDecimalString(reader["PositionCoreOut"], 5, 1));

                            model.TimeCoreIn = Convert.ToString(FormatToDecimalString(reader["TimeCoreIn"], 4, 2));
                            model.TimeCoreOut = Convert.ToString(FormatToDecimalString(reader["TimeCoreOut"], 4, 2));

                            var OperationBasedOn = Convert.ToString(reader["OperationBasedOn"]);
                            model.OperationBasedOn = OperationBasedOn == "0" ? "LSW" : "Timers";

                            var SolDuringInjection = Convert.ToString(reader["SolDuringInjection"]);
                            model.SolDuringInjection = SolDuringInjection == "0" ? "Off" : "On";

                            var InSolHold = Convert.ToString(reader["InSolHold"]);
                            model.InSolHold = InSolHold == "0" ? "Disable" : "Enabled";

                            var OutSolHold = Convert.ToString(reader["OutSolHold"]);
                            model.OutSolHold = OutSolHold == "0" ? "Disable" : "Enabled";

                            model.InDigitalOutput = Convert.ToString(FormatToDecimalString(reader["InDigitalOutput"], 2, 0));
                            model.OutDigitalOutput = Convert.ToString(FormatToDecimalString(reader["OutDigitalOutput"], 2, 0));

                            //model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            //model.IsActive = Convert.ToBoolean(reader["IsActive"]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetPage10Data: " + ex.Message);
            }

            return model;
        }
        public Page11Model GetPage11Data()
        {
            
            Page11Model model = new Page11Model();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT TOP 1 * FROM tblPage11 WHERE IsActive = 1 ORDER BY DataId DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.DataId = Convert.ToInt32(reader["DataId"]);
                        model.PresentStage = Convert.ToString(reader["PresentStage"]);
                        model.StageTime = Convert.ToString(reader["StageTime"]);
                        model.CoreSelection = Convert.ToString(reader["CoreSelection"]);
                        model.CoreSequence = Convert.ToString(reader["CoreSequence"]);
                        model.ONDelayCoreIn = Convert.ToString(reader["ONDelayCoreIn"]);
                        model.ONDelayCoreOut = Convert.ToString(reader["ONDelayCoreOut"]);
                        model.OperationBasedOn = Convert.ToString(reader["OperationBasedOn"]);
                        model.SolDuringInjection = Convert.ToString(reader["SolDuringInjection"]);
                        model.InSolHold = Convert.ToString(reader["InSolHold"]);
                        model.OutSolHold = Convert.ToString(reader["OutSolHold"]);
                        model.FlowCoreIn = Convert.ToString(reader["FlowCoreIn"]);
                        model.FlowCoreOut = Convert.ToString(reader["FlowCoreOut"]);
                        model.PressureCoreIn = Convert.ToString(reader["PressureCoreIn"]);
                        model.PressureCoreOut = Convert.ToString(reader["PressureCoreOut"]);
                        model.PositionCoreIn = Convert.ToString(reader["PositionCoreIn"]);
                        model.PositionCoreOut = Convert.ToString(reader["PositionCoreOut"]);
                        model.TimeCoreIn = Convert.ToString(reader["TimeCoreIn"]);
                        model.TimeCoreOut = Convert.ToString(reader["TimeCoreOut"]);
                        model.InDigitalOutput = Convert.ToString(reader["InDigitalOutput"]);
                        model.OutDigitalOutput = Convert.ToString(reader["OutDigitalOutput"]);
                        model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                        model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    }
                }
            }
            return model;
        }
        public Page14Model GetPage14Data()
        {
            
            Page14Model page14Model = new Page14Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage14 ORDER BY DataId DESC"; // Add WHERE IsActive = 1 if needed
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            page14Model.DataId = Convert.ToInt32(reader["DataId"]);

                            // AE-1
                            page14Model.AE1Selection = Convert.ToString(reader["AE1Selection"]);
                            page14Model.AE1StartPosition = Convert.ToString(reader["AE1StartPosition"]);
                            page14Model.AE1OnDelay = Convert.ToString(reader["AE1OnDelay"]);
                            page14Model.AE1SetStrokes = Convert.ToString(reader["AE1SetStrokes"]);
                            page14Model.AE1OnTime = Convert.ToString(reader["AE1OnTime"]);
                            page14Model.AE1OffTime = Convert.ToString(reader["AE1OffTime"]);
                            page14Model.AE1DigitalOutput = Convert.ToString(reader["AE1DigitalOutput"]);
                            page14Model.AE1Operation = Convert.ToString(reader["AE1Operation"]);
                            page14Model.AE1ActStageTime = Convert.ToString(reader["AE1ActStageTime"]);
                            page14Model.AE1StrokesExecuted = Convert.ToString(reader["AE1StrokesExecuted"]);
                            page14Model.AE1StrokesRemaining = Convert.ToString(reader["AE1StrokesRemaining"]);

                            // AE-2
                            page14Model.AE2Selection = Convert.ToString(reader["AE2Selection"]);
                            page14Model.AE2StartPosition = Convert.ToString(reader["AE2StartPosition"]);
                            page14Model.AE2OnDelay = Convert.ToString(reader["AE2OnDelay"]);
                            page14Model.AE2SetStrokes = Convert.ToString(reader["AE2SetStrokes"]);
                            page14Model.AE2OnTime = Convert.ToString(reader["AE2OnTime"]);
                            page14Model.AE2OffTime = Convert.ToString(reader["AE2OffTime"]);
                            page14Model.AE2DigitalOutput = Convert.ToString(reader["AE2DigitalOutput"]);
                            page14Model.AE2Operation = Convert.ToString(reader["AE2Operation"]);
                            page14Model.AE2ActStageTime = Convert.ToString(reader["AE2ActStageTime"]);
                            page14Model.AE2StrokesExecuted = Convert.ToString(reader["AE2StrokesExecuted"]);
                            page14Model.AE2StrokesRemaining = Convert.ToString(reader["AE2StrokesRemaining"]);

                            page14Model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            page14Model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Page14 data", ex);
            }

            return page14Model;
        }
        public Page15Model GetPage15Data()
        {
            Page15Model model = new Page15Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage15 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //model.DataId = Convert.ToInt32(reader["DataId"]);

                            var Mode = Convert.ToString(reader["Mode"]);
                            model.Mode = Mode == "0" ? "Time" : "Position";

                            model.TotalInjTimeSet = Convert.ToString(FormatToDecimalString(reader["TotalInjTimeSet"], 5, 2));
                            model.Elapsed = Convert.ToString(FormatToDecimalString(reader["Elapsed"], 5, 2));
                            model.Remaining = Convert.ToString(FormatToDecimalString(reader["Remaining"], 5, 2));

                            model.FlowStage5 = Convert.ToString(FormatToDecimalString(reader["FlowStage5"], 3, 1));
                            model.FlowStage4 = Convert.ToString(FormatToDecimalString(reader["FlowStage4"], 3, 1));
                            model.FlowStage3 = Convert.ToString(FormatToDecimalString(reader["FlowStage3"], 3, 1));
                            model.FlowStage2 = Convert.ToString(FormatToDecimalString(reader["FlowStage2"], 3, 1));
                            model.FlowStage1 = Convert.ToString(FormatToDecimalString(reader["FlowStage1"], 3, 1));
                            model.FlowIntrugen = Convert.ToString(FormatToDecimalString(reader["FlowIntrugen"], 3, 1));
                            model.FlowPreInject = Convert.ToString(FormatToDecimalString(reader["FlowPreInject"], 3, 1));

                            model.PressureStage5 = Convert.ToString(FormatToDecimalString(reader["PressureStage5"], 3, 0));
                            model.PressureStage4 = Convert.ToString(FormatToDecimalString(reader["PressureStage4"], 3, 0));
                            model.PressureStage3 = Convert.ToString(FormatToDecimalString(reader["PressureStage3"], 3, 0));
                            model.PressureStage2 = Convert.ToString(FormatToDecimalString(reader["PressureStage2"], 3, 0));
                            model.PressureStage1 = Convert.ToString(FormatToDecimalString(reader["PressureStage1"], 3, 0));
                            model.PressureIntrugen = Convert.ToString(FormatToDecimalString(reader["PressureIntrugen"], 3, 0));
                            model.PressurePreInject = Convert.ToString(FormatToDecimalString(reader["PressurePreInject"], 3, 0));

                            model.PositionStage5 = Convert.ToString(FormatToDecimalString(reader["PositionStage5"], 4, 1));
                            model.PositionStage4 = Convert.ToString(FormatToDecimalString(reader["PositionStage4"], 4, 1));
                            model.PositionStage3 = Convert.ToString(FormatToDecimalString(reader["PositionStage3"], 4, 1));
                            model.PositionStage2 = Convert.ToString(FormatToDecimalString(reader["PositionStage2"], 4, 1));
                            model.PositionStage1 = Convert.ToString(FormatToDecimalString(reader["PositionStage1"], 4, 1));
                            model.PositionIntrugen = Convert.ToString(FormatToDecimalString(reader["PositionIntrugen"], 4, 1));
                            model.PositionPreInject = Convert.ToString(FormatToDecimalString(reader["PositionPreInject"], 4, 1));

                            model.TimeStage5 = Convert.ToString(FormatToDecimalString(reader["TimeStage5"], 4, 2));
                            model.TimeStage4 = Convert.ToString(FormatToDecimalString(reader["TimeStage4"], 4, 2));
                            model.TimeStage3 = Convert.ToString(FormatToDecimalString(reader["TimeStage3"], 4, 2));
                            model.TimeStage2 = Convert.ToString(FormatToDecimalString(reader["TimeStage2"], 4, 2));
                            model.TimeStage1 = Convert.ToString(FormatToDecimalString(reader["TimeStage1"], 4, 2));
                            model.TimeIntrugen = Convert.ToString(FormatToDecimalString(reader["TimeIntrugen"], 4, 2));
                            model.TimePreInject = Convert.ToString(FormatToDecimalString(reader["TimePreInject"], 3, 2));

                            model.PumpStage5 = Convert.ToString(FormatToDecimalString(reader["PumpStage5"], 4, 0));
                            model.PumpStage4 = Convert.ToString(FormatToDecimalString(reader["PumpStage4"], 4, 0));
                            model.PumpStage3 = Convert.ToString(FormatToDecimalString(reader["PumpStage3"], 4, 0));
                            model.PumpStage2 = Convert.ToString(FormatToDecimalString(reader["PumpStage2"], 4, 0));
                            model.PumpStage1 = Convert.ToString(FormatToDecimalString(reader["PumpStage1"], 4, 0));
                            model.PumpIntrugen = Convert.ToString(FormatToDecimalString(reader["PumpIntrugen"], 4, 0));
                            model.PumpPreInject = Convert.ToString(FormatToDecimalString(reader["PumpPreInject"], 4, 0));

                            model.SpeedStage5 = Convert.ToString(FormatToDecimalString(reader["SpeedStage5"], 3, 0));
                            model.SpeedStage4 = Convert.ToString(FormatToDecimalString(reader["SpeedStage4"], 3, 0));
                            model.SpeedStage3 = Convert.ToString(FormatToDecimalString(reader["SpeedStage3"], 3, 0));
                            model.SpeedStage2 = Convert.ToString(FormatToDecimalString(reader["SpeedStage2"], 3, 0));
                            model.SpeedStage1 = Convert.ToString(FormatToDecimalString(reader["SpeedStage1"], 3, 0));
                            model.SpeedIntrugen = Convert.ToString(FormatToDecimalString(reader["SpeedIntrugen"], 3, 0));
                            model.SpeedPreInject = Convert.ToString(FormatToDecimalString(reader["SpeedPreInject"], 3, 0));

                            model.ActStageTimeStage5 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeStage5"], 4, 2));
                            model.ActStageTimeStage4 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeStage4"], 4, 2));
                            model.ActStageTimeStage3 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeStage3"], 4, 2));
                            model.ActStageTimeStage2 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeStage2"], 4, 2));
                            model.ActStageTimeStage1 = Convert.ToString(FormatToDecimalString(reader["ActStageTimeStage1"], 4, 2));
                            model.ActStageTimeIntrugen = Convert.ToString(FormatToDecimalString(reader["ActStageTimeIntrugen"], 4, 2));
                            model.ActStageTimePreInject = Convert.ToString(FormatToDecimalString(reader["ActStageTimePreInject"], 4, 2));

                            model.ScrewPosition = Convert.ToString(FormatToDecimalString(reader["ScrewPosition"], 4, 1));
                            model.SwitchoverPosition = Convert.ToString(FormatToDecimalString(reader["SwitchoverPosition"], 4, 1));
                            model.InjectionBoostStage = Convert.ToString(FormatToDecimalString(reader["InjectionBoostStage"], 1, 0));
                            model.Solenoid = Convert.ToString(FormatToDecimalString(reader["Solenoid"], 2, 0));

                            var InjectionSetTime = Convert.ToString(reader["InjectionSetTime"]);
                            model.InjectionSetTime = Mode == "0" ? "Disable" : "Enabled";

                            //model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            //model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetPage15Data: " + ex.Message);
            }

            return model;
        }
        public Page18Model GetPage18Data()
        {
            
            Page18Model model = new Page18Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage18 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //model.DataId = Convert.ToInt32(reader["DataId"]);

                            var Model = Convert.ToString(reader["Model"]);
                            model.Model = Model == "0" ? "Time" : "Position";



                            model.CoolingTimeSet = Convert.ToString(FormatToDecimalString(Convert.ToString(reader["CoolingTimeSet"]), 5, 2));
                            model.Remaining = Convert.ToString(FormatToDecimalString(Convert.ToString(reader["Remaining"]), 5, 2));

                            var SelectionIntrugen = Convert.ToString(reader["SelectionIntrugen"]);
                            model.SelectionIntrugen = SelectionIntrugen == "0" ? "Disable" : "Enabled";

                            var SelectionPreSuckback = Convert.ToString(reader["SelectionPreSuckback"]);
                            model.SelectionPreSuckback = SelectionPreSuckback == "0" ? "Disable" : "Enabled";

                            //model.SelectionRefill1 = Convert.ToString(FormatToDecimalString(["SelectionRefill1"]);
                            //model.SelectionRefill2 = Convert.ToString(FormatToDecimalString(["SelectionRefill2"]);
                            //model.SelectionRefill3 = Convert.ToString(FormatToDecimalString(["SelectionRefill3"]);

                            var SelectionPostSuckback = Convert.ToString(reader["SelectionPostSuckback"]);
                            model.SelectionPostSuckback = SelectionPostSuckback == "0" ? "Disable" : "Enabled";

                            model.FlowIntrugen = FormatToDecimalString(Convert.ToString(reader["FlowIntrugen"]), 3, 1);
                            model.FlowPreSuckback = FormatToDecimalString(Convert.ToString(reader["FlowPreSuckback"]), 3, 1);
                            model.FlowRefill1 = FormatToDecimalString(Convert.ToString(reader["FlowRefill1"]), 3, 1);
                            model.FlowRefill2 = FormatToDecimalString(Convert.ToString(reader["FlowRefill2"]), 3, 1);
                            model.FlowRefill3 = FormatToDecimalString(Convert.ToString(reader["FlowRefill3"]), 3, 1);
                            model.FlowPostSuckback = FormatToDecimalString(Convert.ToString(reader["FlowPostSuckback"]), 3, 1);

                            model.SysPreIntrugen = FormatToDecimalString(Convert.ToString(reader["SysPreIntrugen"]), 3, 0);
                            model.SysPrePreSuckback = FormatToDecimalString(Convert.ToString(reader["SysPrePreSuckback"]), 3, 0);
                            model.SysPreRefill1 = FormatToDecimalString(Convert.ToString(reader["SysPreRefill1"]), 3, 0);
                            model.SysPreRefill2 = FormatToDecimalString(Convert.ToString(reader["SysPreRefill2"]), 3, 0);
                            model.SysPreRefill3 = FormatToDecimalString(Convert.ToString(reader["SysPreRefill3"]), 3, 0);
                            model.SysPrePostSuckback = FormatToDecimalString(Convert.ToString(reader["SysPrePostSuckback"]), 3, 0);

                            model.BackPreIntrugen = FormatToDecimalString(Convert.ToString(reader["BackPreIntrugen"]), 3, 0);
                            model.BackPrePreSuckback = FormatToDecimalString(Convert.ToString(reader["BackPrePreSuckback"]), 3, 0);
                            model.BackPreRefill1 = FormatToDecimalString(Convert.ToString(reader["BackPreRefill1"]), 3, 0);
                            model.BackPreRefill2 = FormatToDecimalString(Convert.ToString(reader["BackPreRefill2"]), 3, 0);
                            model.BackPreRefill3 = FormatToDecimalString(Convert.ToString(reader["BackPreRefill3"]), 3, 0);
                            model.BackPrePostSuckback = FormatToDecimalString(Convert.ToString(reader["BackPrePostSuckback"]), 3, 0);

                            model.PositionIntrugen = FormatToDecimalString(Convert.ToString(reader["PositionIntrugen"]), 4, 1);
                            model.PositionPreSuckback = FormatToDecimalString(Convert.ToString(reader["PositionPreSuckback"]), 4, 1);
                            model.PositionRefill1 = FormatToDecimalString(Convert.ToString(reader["PositionRefill1"]), 4, 1);
                            model.PositionRefill2 = FormatToDecimalString(Convert.ToString(reader["PositionRefill2"]), 4, 1);
                            model.PositionRefill3 = FormatToDecimalString(Convert.ToString(reader["PositionRefill3"]), 4, 1);
                            model.PositionPostSuckback = FormatToDecimalString(Convert.ToString(reader["PositionPostSuckback"]), 4, 1);

                            model.TimeIntrugen = FormatToDecimalString(Convert.ToString(reader["TimeIntrugen"]), 4, 2);
                            model.TimePreSuckback = FormatToDecimalString(Convert.ToString(reader["TimePreSuckback"]), 4, 2);
                            model.TimeRefill1 = FormatToDecimalString(Convert.ToString(reader["TimeRefill1"]), 4, 2);
                            model.TimeRefill2 = FormatToDecimalString(Convert.ToString(reader["TimeRefill2"]), 4, 2);
                            model.TimeRefill3 = FormatToDecimalString(Convert.ToString(reader["TimeRefill3"]), 4, 2);
                            model.TimePostSuckback = FormatToDecimalString(Convert.ToString(reader["TimePostSuckback"]), 4, 2);

                            model.ScrewRPMIntrugen = FormatToDecimalString(Convert.ToString(reader["ScrewRPMIntrugen"]), 3, 0);
                            model.ScrewRPMPreSuckback = FormatToDecimalString(Convert.ToString(reader["ScrewRPMPreSuckback"]), 3, 0);
                            model.ScrewRPMRefill1 = FormatToDecimalString(Convert.ToString(reader["ScrewRPMRefill1"]), 3, 0);
                            model.ScrewRPMRefill2 = FormatToDecimalString(Convert.ToString(reader["ScrewRPMRefill2"]), 3, 0);
                            model.ScrewRPMRefill3 = FormatToDecimalString(Convert.ToString(reader["ScrewRPMRefill3"]), 3, 0);
                            model.ScrewRPMPostSuckback = FormatToDecimalString(Convert.ToString(reader["ScrewRPMPostSuckback"]), 3, 0);

                            model.SpeedIntrugen = FormatToDecimalString(Convert.ToString(reader["SpeedIntrugen"]), 3, 0);
                            model.SpeedPreSuckback = FormatToDecimalString(Convert.ToString(reader["SpeedPreSuckback"]), 3, 0);
                            model.SpeedRefill1 = FormatToDecimalString(Convert.ToString(reader["SpeedRefill1"]), 3, 0);
                            model.SpeedRefill2 = FormatToDecimalString(Convert.ToString(reader["SpeedRefill2"]), 3, 0);
                            model.SpeedRefill3 = FormatToDecimalString(Convert.ToString(reader["SpeedRefill3"]), 3, 0);
                            model.SpeedPostSuckback = FormatToDecimalString(Convert.ToString(reader["SpeedPostSuckback"]), 3, 0);

                            model.ActStageTimeIntrugen = FormatToDecimalString(Convert.ToString(reader["ActStageTimeIntrugen"]), 4, 2);
                            model.ActStageTimePreSuckback = FormatToDecimalString(Convert.ToString(reader["ActStageTimePreSuckback"]), 4, 2);
                            model.ActStageTimeRefill1 = FormatToDecimalString(Convert.ToString(reader["ActStageTimeRefill1"]), 4, 2);
                            model.ActStageTimeRefill2 = FormatToDecimalString(Convert.ToString(reader["ActStageTimeRefill2"]), 4, 2);
                            model.ActStageTimeRefill3 = FormatToDecimalString(Convert.ToString(reader["ActStageTimeRefill3"]), 4, 2);
                            model.ActStageTimePostSuckback = FormatToDecimalString(Convert.ToString(reader["ActStageTimePostSuckback"]), 4, 2);

                            model.ScrewPosition = FormatToDecimalString(Convert.ToString(reader["ScrewPosition"]), 4, 1);

                            var RefillingBoostSelection = Convert.ToString(reader["RefillingBoostSelection"]);
                            model.RefillingBoostSelection = RefillingBoostSelection == "0" ? "Disable" : "Enabled";

                            model.Solenoid = FormatToDecimalString(Convert.ToString(reader["Solenoid"]), 2, 0);

                            //model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            //model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }
        public Page20Model GetPage20Data()
        {
            
            Page20Model page20Model = new Page20Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage20 WHERE IsActive = 1 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            page20Model.FlowSlowFwd = Convert.ToString(reader["FlowSlowFwd"]);
                            page20Model.FlowFastFwd = Convert.ToString(reader["FlowFastFwd"]);
                            page20Model.FlowFastRet = Convert.ToString(reader["FlowFastRet"]);
                            page20Model.FlowSlowRet = Convert.ToString(reader["FlowSlowRet"]);

                            page20Model.PressureSlowFwd = Convert.ToString(reader["PressureSlowFwd"]);
                            page20Model.PressureFastFwd = Convert.ToString(reader["PressureFastFwd"]);
                            page20Model.PressureFastRet = Convert.ToString(reader["PressureFastRet"]);
                            page20Model.PressureSlowRet = Convert.ToString(reader["PressureSlowRet"]);

                            page20Model.PositionSlowFwd = Convert.ToString(reader["PositionSlowFwd"]);
                            page20Model.PositionFastFwd = Convert.ToString(reader["PositionFastFwd"]);
                            page20Model.PositionFastRet = Convert.ToString(reader["PositionFastRet"]);
                            page20Model.PositionSlowRet = Convert.ToString(reader["PositionSlowRet"]);

                            page20Model.TimeSlowFwd = Convert.ToString(reader["TimeSlowFwd"]);
                            page20Model.TimeFastFwd = Convert.ToString(reader["TimeFastFwd"]);
                            page20Model.TimeFastRet = Convert.ToString(reader["TimeFastRet"]);
                            page20Model.TimeSlowRet = Convert.ToString(reader["TimeSlowRet"]);

                            page20Model.SpeedSlowFwd = Convert.ToString(reader["SpeedSlowFwd"]);
                            page20Model.SpeedFastFwd = Convert.ToString(reader["SpeedFastFwd"]);
                            page20Model.SpeedFastRet = Convert.ToString(reader["SpeedFastRet"]);
                            page20Model.SpeedSlowRet = Convert.ToString(reader["SpeedSlowRet"]);

                            page20Model.PresentOperation = Convert.ToString(reader["PresentOperation"]);
                            page20Model.CarriagePosition = Convert.ToString(reader["CarriagePosition"]);
                            page20Model.CarriageMode = Convert.ToString(reader["CarriageMode"]);
                            page20Model.CarriageMove = Convert.ToString(reader["CarriageMove"]);
                            page20Model.ForwardDuringInjection = Convert.ToString(reader["ForwardDuringInjection"]);
                            page20Model.ForwardDuringSuckback = Convert.ToString(reader["ForwardDuringSuckback"]);
                            page20Model.ForwardDuringRefill = Convert.ToString(reader["ForwardDuringRefill"]);
                            page20Model.CarriageForwardStartDelay = Convert.ToString(reader["CarriageForwardStartDelay"]);
                            page20Model.CarriageRetractStartDelay = Convert.ToString(reader["CarriageRetractStartDelay"]);

                            page20Model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            page20Model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error if needed
                throw;
            }

            return page20Model;
        }
        public Page21Model GetPage21Data()
        {
            
            Page21Model page21Model = new Page21Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage21 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            page21Model.SetTempZone1 = FormatToDecimalString(Convert.ToString(reader["SetTempZone1"]), 3, 0);
                            page21Model.LowAlarmZone1 = FormatToDecimalString(Convert.ToString(reader["LowAlarmZone1"]), 3, 0);
                            page21Model.HighAlarmZone1 = FormatToDecimalString(Convert.ToString(reader["HighAlarmZone1"]), 3, 0);
                            page21Model.DutyZone1 = FormatToDecimalString(Convert.ToString(reader["DutyZone1"]), 2, 0);
                            page21Model.OvershootZone1 = FormatToDecimalString(Convert.ToString(reader["OvershootZone1"]), 2, 0);
                            //page21Model.StatusZone1 = Convert.ToString(reader["StatusZone1"]);
                            //page21Model.ActualTempZone1 = Convert.ToString(reader["ActualTempZone1"]);

                            page21Model.SetTempZone2 = FormatToDecimalString(Convert.ToString(reader["SetTempZone2"]), 3, 0);
                            page21Model.LowAlarmZone2 = FormatToDecimalString(Convert.ToString(reader["LowAlarmZone2"]), 3, 0);
                            page21Model.HighAlarmZone2 = FormatToDecimalString(Convert.ToString(reader["HighAlarmZone2"]), 3, 0);
                            page21Model.DutyZone2 = FormatToDecimalString(Convert.ToString(reader["DutyZone2"]), 2, 0);
                            page21Model.OvershootZone2 = FormatToDecimalString(Convert.ToString(reader["OvershootZone2"]), 2, 0);
                            //page21Model.StatusZone2 = Convert.ToString(reader["StatusZone2"]);
                            //page21Model.ActualTempZone2 = Convert.ToString(reader["ActualTempZone2"]);

                            page21Model.SetTempZone3 = FormatToDecimalString(Convert.ToString(reader["SetTempZone3"]), 3, 0);
                            page21Model.LowAlarmZone3 = FormatToDecimalString(Convert.ToString(reader["LowAlarmZone3"]), 3, 0);
                            page21Model.HighAlarmZone3 = FormatToDecimalString(Convert.ToString(reader["HighAlarmZone3"]), 3, 0);
                            page21Model.DutyZone3 = FormatToDecimalString(Convert.ToString(reader["DutyZone3"]), 2, 0);
                            page21Model.OvershootZone3 = FormatToDecimalString(Convert.ToString(reader["OvershootZone3"]), 2, 0);
                            //page21Model.StatusZone3 = Convert.ToString(reader["StatusZone3"]);
                            //page21Model.ActualTempZone3 = Convert.ToString(reader["ActualTempZone3"]);

                            page21Model.SetTempZone4 = FormatToDecimalString(Convert.ToString(reader["SetTempZone4"]), 3, 0);
                            page21Model.LowAlarmZone4 = FormatToDecimalString(Convert.ToString(reader["LowAlarmZone4"]), 3, 0);
                            page21Model.HighAlarmZone4 = FormatToDecimalString(Convert.ToString(reader["HighAlarmZone4"]), 3, 0);
                            page21Model.DutyZone4 = FormatToDecimalString(Convert.ToString(reader["DutyZone4"]), 2, 0);
                            page21Model.OvershootZone4 = FormatToDecimalString(Convert.ToString(reader["OvershootZone4"]), 2, 0);
                            //page21Model.StatusZone4 = Convert.ToString(reader["StatusZone4"]);
                            //page21Model.ActualTempZone4 = Convert.ToString(reader["ActualTempZone4"]);

                            page21Model.SetTempZone5 = FormatToDecimalString(Convert.ToString(reader["SetTempZone5"]), 3, 0);
                            page21Model.LowAlarmZone5 = FormatToDecimalString(Convert.ToString(reader["LowAlarmZone5"]), 3, 0);
                            page21Model.HighAlarmZone5 = FormatToDecimalString(Convert.ToString(reader["HighAlarmZone5"]), 3, 0);
                            page21Model.DutyZone5 = FormatToDecimalString(Convert.ToString(reader["DutyZone5"]), 2, 0);
                            page21Model.OvershootZone5 = FormatToDecimalString(Convert.ToString(reader["OvershootZone5"]), 2, 0);
                            //page21Model.StatusZone5 = Convert.ToString(reader["StatusZone5"]);
                            //page21Model.ActualTempZone5 = Convert.ToString(reader["ActualTempZone5"]);

                            //page21Model.SetTempHydOil = Convert.ToString(reader["SetTempHydOil"]);
                            //page21Model.LowAlarmHydOil = Convert.ToString(reader["LowAlarmHydOil"]);
                            page21Model.HighAlarmHydOil = FormatToDecimalString(Convert.ToString(reader["HighAlarmHydOil"]), 3, 0);
                            page21Model.DutyHydOil = FormatToDecimalString(Convert.ToString(reader["DutyHydOil"]), 2, 0);
                            //page21Model.OvershootHydOil = Convert.ToString(reader["OvershootHydOil"]);
                            //page21Model.StatusHydOil = Convert.ToString(reader["StatusHydOil"]);
                            //page21Model.ActualTempHydOil = Convert.ToString(reader["ActualTempHydOil"]);

                            //page21Model.SetTempNozzle = Convert.ToString(reader["SetTempNozzle"]);
                            //page21Model.LowAlarmNozzle = Convert.ToString(reader["LowAlarmNozzle"]);
                            //page21Model.HighAlarmNozzle = Convert.ToString(reader["HighAlarmNozzle"]);
                            page21Model.DutyNozzle = FormatToDecimalString(Convert.ToString(reader["DutyNozzle"]), 2, 0);
                            //page21Model.OvershootNozzle = Convert.ToString(reader["OvershootNozzle"]);
                            //page21Model.StatusNozzle = Convert.ToString(reader["StatusNozzle"]);
                            //page21Model.ActualTempNozzle = Convert.ToString(reader["ActualTempNozzle"]);

                            //page21Model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            //page21Model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return page21Model;
        }
        public Page26Model GetPage26Data()
        {
            
            Page26Model model = new Page26Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage26 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.AutoDieLockingSelection = Convert.ToString(reader["AutoDieLockingSelection"]);
                            model.AdjustBy = Convert.ToString(reader["AdjustBy"]);
                            model.AdjustTime = Convert.ToString(reader["AdjustTime"]);
                            model.StandStillTime = Convert.ToString(reader["StandStillTime"]);
                            model.FlowMovement = Convert.ToString(reader["FlowMovement"]);
                            model.FlowCounting = Convert.ToString(reader["FlowCounting"]);
                            model.PressureMovement = Convert.ToString(reader["PressureMovement"]);
                            model.PressureCounting = Convert.ToString(reader["PressureCounting"]);
                            model.NumberOfTrials = Convert.ToString(reader["NumberOfTrials"]);
                            model.RequiredLockingPressure = Convert.ToString(reader["RequiredLockingPressure"]);
                            model.ExecutedTrials = Convert.ToString(reader["ExecutedTrials"]);
                            model.RequiredPulseCount = Convert.ToString(reader["RequiredPulseCount"]);
                            model.DirectionOfRotation = Convert.ToString(reader["DirectionOfRotation"]);
                            model.ActualPulseCount = Convert.ToString(reader["ActualPulseCount"]);
                            model.MachineLockingFactor = Convert.ToString(reader["MachineLockingFactor"]);
                            model.PresentTrialCount = Convert.ToString(reader["PresentTrialCount"]);
                            model.ActualClampPressure = Convert.ToString(reader["ActualClampPressure"]);
                            model.ActualClampPosition = Convert.ToString(reader["ActualClampPosition"]);
                            model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }
        public Page29Model GetPage29Data()
        {
            
            Page29Model model = new Page29Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage29 WHERE IsActive = 1 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //model.DataId = Convert.ToInt32(reader["DataId"]);


                            //page21Model.SetTempZone1 = FormatToDecimalString(Convert.ToString(reader["SetTempZone1"]), 3, 0);

                            model.MoldCloseSet = FormatToDecimalString(Convert.ToString(reader["MoldCloseSet"]), 4, 2);
                            model.MoldCloseActual = FormatToDecimalString(Convert.ToString(reader["MoldCloseActual"]), 4, 2);
                            model.MoldSafetySet = FormatToDecimalString(Convert.ToString(reader["MoldSafetySet"]), 4, 2);
                            model.MoldSafetyActual = FormatToDecimalString(Convert.ToString(reader["MoldSafetyActual"]), 4, 2);
                            model.MoldLockingSet = FormatToDecimalString(Convert.ToString(reader["MoldLockingSet"]), 4, 2);
                            model.MoldLockingActual = FormatToDecimalString(Convert.ToString(reader["MoldLockingActual"]), 4, 2);
                            model.PreInjectSet = FormatToDecimalString(Convert.ToString(reader["PreInjectSet"]), 4, 2);
                            model.PreInjectActual = FormatToDecimalString(Convert.ToString(reader["PreInjectActual"]), 4, 2);
                            model.IntrugenSet = FormatToDecimalString(Convert.ToString(reader["IntrugenSet"]), 4, 2);
                            model.IntrugenActual = FormatToDecimalString(Convert.ToString(reader["IntrugenActual"]), 4, 2);
                            model.TotInjectSet = FormatToDecimalString(Convert.ToString(reader["TotInjectSet"]), 4, 2);
                            model.TotInjectActual = FormatToDecimalString(Convert.ToString(reader["TotInjectActual"]), 4, 2);
                            model.Inject1Set = FormatToDecimalString(Convert.ToString(reader["Inject1Set"]), 4, 2);
                            model.Inject1Actual = FormatToDecimalString(Convert.ToString(reader["Inject1Actual"]), 4, 2);
                            model.Inject2Set = FormatToDecimalString(Convert.ToString(reader["Inject2Set"]), 4, 2);
                            model.Inject2Actual = FormatToDecimalString(Convert.ToString(reader["Inject2Actual"]), 4, 2);
                            model.Inject3Set = FormatToDecimalString(Convert.ToString(reader["Inject3Set"]), 4, 2);
                            model.Inject3Actual = FormatToDecimalString(Convert.ToString(reader["Inject3Actual"]), 4, 2);
                            model.Inject4Set = FormatToDecimalString(Convert.ToString(reader["Inject4Set"]), 4, 2);
                            model.Inject4Actual = FormatToDecimalString(Convert.ToString(reader["Inject4Actual"]), 4, 2);
                            model.Inject5Set = FormatToDecimalString(Convert.ToString(reader["Inject5Set"]), 4, 2);
                            model.Inject5Actual = FormatToDecimalString(Convert.ToString(reader["Inject5Actual"]), 4, 2);
                            model.MoldOpenHoldSet = FormatToDecimalString(Convert.ToString(reader["MoldOpenHoldSet"]), 4, 2);
                            model.MoldOpenHoldActual = FormatToDecimalString(Convert.ToString(reader["MoldOpenHoldActual"]), 4, 2);
                            model.Hold1Set = FormatToDecimalString(Convert.ToString(reader["Hold1Set"]), 4, 2);
                            model.Hold1Actual = FormatToDecimalString(Convert.ToString(reader["Hold1Actual"]), 4, 2);
                            model.Hold2Set = FormatToDecimalString(Convert.ToString(reader["Hold2Set"]), 4, 2);
                            model.Hold2Actual = FormatToDecimalString(Convert.ToString(reader["Hold2Actual"]), 4, 2);
                            model.Hold3Set = FormatToDecimalString(Convert.ToString(reader["Hold3Set"]), 4, 2);
                            model.Hold3Actual = FormatToDecimalString(Convert.ToString(reader["Hold3Actual"]), 4, 2);
                            model.Hold4Set = FormatToDecimalString(Convert.ToString(reader["Hold4Set"]), 4, 2);
                            model.Hold4Actual = FormatToDecimalString(Convert.ToString(reader["Hold4Actual"]), 4, 2);
                            model.CoolingSet = FormatToDecimalString(Convert.ToString(reader["CoolingSet"]), 4, 2);
                            model.CoolingActual = FormatToDecimalString(Convert.ToString(reader["CoolingActual"]), 4, 2);
                            model.Refill1Set = FormatToDecimalString(Convert.ToString(reader["Refill1Set"]), 4, 2);
                            model.Refill1Actual = FormatToDecimalString(Convert.ToString(reader["Refill1Actual"]), 4, 2);
                            model.Refill2Set = FormatToDecimalString(Convert.ToString(reader["Refill2Set"]), 4, 2);
                            model.Refill2Actual = FormatToDecimalString(Convert.ToString(reader["Refill2Actual"]), 4, 2);
                            model.Refill3Set = FormatToDecimalString(Convert.ToString(reader["Refill3Set"]), 4, 2);
                            model.Refill3Actual = FormatToDecimalString(Convert.ToString(reader["Refill3Actual"]), 4, 2);
                            model.PreSuckbackSet = FormatToDecimalString(Convert.ToString(reader["PreSuckbackSet"]), 4, 2);
                            model.PreSuckbackActual = FormatToDecimalString(Convert.ToString(reader["PreSuckbackActual"]), 4, 2);
                            model.PostSuckbackSet = FormatToDecimalString(Convert.ToString(reader["PostSuckbackSet"]), 4, 2);
                            model.PostSuckbackActual = FormatToDecimalString(Convert.ToString(reader["PostSuckbackActual"]), 4, 2);
                            model.InitDecompSet = FormatToDecimalString(Convert.ToString(reader["InitDecompSet"]), 4, 2);
                            model.InitDecompActual = FormatToDecimalString(Convert.ToString(reader["InitDecompActual"]), 4, 2);
                            model.UnitFwd1Set = FormatToDecimalString(Convert.ToString(reader["UnitFwd1Set"]), 4, 2);
                            model.UnitFwd1Actual = FormatToDecimalString(Convert.ToString(reader["UnitFwd1Actual"]), 4, 2);
                            model.UnitRet1Set = FormatToDecimalString(Convert.ToString(reader["UnitRet1Set"]), 4, 2);
                            model.UnitRet1Actual = FormatToDecimalString(Convert.ToString(reader["UnitRet1Actual"]), 4, 2);
                            model.UnitRet2Set = FormatToDecimalString(Convert.ToString(reader["UnitRet2Set"]), 4, 2);
                            model.UnitRet2Actual = FormatToDecimalString(Convert.ToString(reader["UnitRet2Actual"]), 4, 2);
                            model.FinDecomSet = FormatToDecimalString(Convert.ToString(reader["FinDecomSet"]), 4, 2);
                            model.FinDecomActual = FormatToDecimalString(Convert.ToString(reader["FinDecomActual"]), 4, 2);
                            model.TotCycleSet = FormatToDecimalString(Convert.ToString(reader["TotCycleSet"]), 5, 2);
                            model.TotCycleActual = FormatToDecimalString(Convert.ToString(reader["TotCycleActual"]), 5, 2);

                            //model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            //model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return model;
        }
        public Page32Model GetPage32Data()
        {
            Page32Model model = new Page32Model();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT TOP 1 * FROM tblPage32 ORDER BY DataId DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        model.DataId = Convert.ToInt32(reader["DataId"]);
                        model.MotorStatus = reader["MotorStatus"].ToString();
                        model.SwitchedOnBy = reader["SwitchedOnBy"].ToString();
                        model.StarterType = reader["StarterType"].ToString();
                        model.StarDeltaDelaySec = reader["StarDeltaDelaySec"].ToString();
                        model.StarDeltaDelayMin = reader["StarDeltaDelayMin"].ToString();
                        model.OnDelaySec = reader["OnDelaySec"].ToString();
                        model.OnDelayMin = reader["OnDelayMin"].ToString();
                        model.HandOperation = reader["HandOperation"].ToString();
                        model.PowerSaving = reader["PowerSaving"].ToString();
                        model.SwitchOnMotorTime = reader["SwitchOnMotorTime"].ToString();
                        model.StarterOutputK1 = reader["StarterOutputK1"].ToString();
                        model.StarterOutputK2 = reader["StarterOutputK2"].ToString();
                        model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                        model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    }
                }
            }

            return model;
        }
        public Page34Model GetPage34Data()
        {
            
            Page34Model model = new Page34Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage34 WHERE IsActive = 1 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.DataId = Convert.ToInt32(reader["DataId"]);
                            model.LubricationFlag = Convert.ToString(reader["LubricationFlag"]);
                            model.LubricationSelection = Convert.ToString(reader["LubricationSelection"]);
                            model.LubricationMode = Convert.ToString(reader["LubricationMode"]);

                            model.LubIntervalTimeSet = Convert.ToString(reader["LubIntervalTimeSet"]);
                            model.LubIntervalTimeRem = Convert.ToString(reader["LubIntervalTimeRem"]);

                            model.LubIntervalShotsSet = Convert.ToString(reader["LubIntervalShotsSet"]);
                            model.LubIntervalShotsRem = Convert.ToString(reader["LubIntervalShotsRem"]);

                            model.LubOnTimeSet = Convert.ToString(reader["LubOnTimeSet"]);
                            model.LubOnTimeRem = Convert.ToString(reader["LubOnTimeRem"]);

                            model.LubRepeatCycleSet = Convert.ToString(reader["LubRepeatCycleSet"]);
                            model.LubRepeatCycleRem = Convert.ToString(reader["LubRepeatCycleRem"]);

                            model.LubFeedbackTimeoutSet = Convert.ToString(reader["LubFeedbackTimeoutSet"]);
                            model.LubFeedbackTimeoutRem = Convert.ToString(reader["LubFeedbackTimeoutRem"]);

                            model.LubMinOffTimeSet = Convert.ToString(reader["LubMinOffTimeSet"]);
                            model.LubMinOffTimeRem = Convert.ToString(reader["LubMinOffTimeRem"]);

                            model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle/log exception as per your application's logging strategy
                throw;
            }

            return model;
        }
        public Page44Model GetPage44Data()
        {
            
            Page44Model model = new Page44Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage44 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.DataId = Convert.ToInt32(reader["DataId"]);
                            model.ClampCount = reader["ClampCount"].ToString();
                            model.ClampZero = reader["ClampZero"].ToString();
                            model.ClampSpan = reader["ClampSpan"].ToString();
                            model.ClampMM = reader["ClampMM"].ToString();

                            model.ScrewCount = reader["ScrewCount"].ToString();
                            model.ScrewZero = reader["ScrewZero"].ToString();
                            model.ScrewSpan = reader["ScrewSpan"].ToString();
                            model.ScrewMM = reader["ScrewMM"].ToString();

                            model.EjectorCount = reader["EjectorCount"].ToString();
                            model.EjectorZero = reader["EjectorZero"].ToString();
                            model.EjectorSpan = reader["EjectorSpan"].ToString();
                            model.EjectorMM = reader["EjectorMM"].ToString();

                            model.CarriageCount = reader["CarriageCount"].ToString();
                            model.CarriageZero = reader["CarriageZero"].ToString();
                            model.CarriageSpan = reader["CarriageSpan"].ToString();
                            model.CarriageMM = reader["CarriageMM"].ToString();

                            model.SystemZero = reader["SystemZero"].ToString();
                            model.SystemSpan = reader["SystemSpan"].ToString();
                            model.SystemBar = reader["SystemBar"].ToString();

                            model.Zone1Count = reader["Zone1Count"].ToString();
                            model.Zone1Zero = reader["Zone1Zero"].ToString();
                            model.Zone1Span = reader["Zone1Span"].ToString();
                            model.Zone1Deg = reader["Zone1Deg"].ToString();

                            model.Zone2Count = reader["Zone2Count"].ToString();
                            model.Zone2Zero = reader["Zone2Zero"].ToString();
                            model.Zone2Span = reader["Zone2Span"].ToString();
                            model.Zone2Deg = reader["Zone2Deg"].ToString();

                            model.Zone3Count = reader["Zone3Count"].ToString();
                            model.Zone3Zero = reader["Zone3Zero"].ToString();
                            model.Zone3Span = reader["Zone3Span"].ToString();
                            model.Zone3Deg = reader["Zone3Deg"].ToString();

                            model.Zone4Count = reader["Zone4Count"].ToString();
                            model.Zone4Zero = reader["Zone4Zero"].ToString();
                            model.Zone4Span = reader["Zone4Span"].ToString();
                            model.Zone4Deg = reader["Zone4Deg"].ToString();

                            model.Zone5Count = reader["Zone5Count"].ToString();
                            model.Zone5Zero = reader["Zone5Zero"].ToString();
                            model.Zone5Span = reader["Zone5Span"].ToString();
                            model.Zone5Deg = reader["Zone5Deg"].ToString();

                            model.HydOilCount = reader["HydOilCount"].ToString();
                            model.HydOilZero = reader["HydOilZero"].ToString();
                            model.HydOilSpan = reader["HydOilSpan"].ToString();
                            model.HydOilDeg = reader["HydOilDeg"].ToString();

                            model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading Page44 data", ex);
            }

            return model;
        }
        public Page53Model GetPage53Data()
        {
            
            Page53Model model = new Page53Model();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT TOP 1 * FROM tblPage53 WHERE IsActive = 1 ORDER BY DataId DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model.ClampSpeed = reader["ClampSpeed"].ToString();
                            model.ClampPressure = reader["ClampPressure"].ToString();
                            model.SafetySpeed = reader["SafetySpeed"].ToString();
                            model.SafetyPressure = reader["SafetyPressure"].ToString();
                            model.LockingSpeed = reader["LockingSpeed"].ToString();
                            model.LockingPressure = reader["LockingPressure"].ToString();
                            model.ClampTonnageSpeed = reader["ClampTonnageSpeed"].ToString();
                            model.ClampTonnagePressure = reader["ClampTonnagePressure"].ToString();
                            model.CarriageSpeed = reader["CarriageSpeed"].ToString();
                            model.CarriagePressure = reader["CarriagePressure"].ToString();
                            model.PreInjectionSpeed = reader["PreInjectionSpeed"].ToString();
                            model.PreInjectionPressure = reader["PreInjectionPressure"].ToString();
                            model.IntrugenSpeed = reader["IntrugenSpeed"].ToString();
                            model.IntrugenPressure = reader["IntrugenPressure"].ToString();
                            model.InjectionSpeed = reader["InjectionSpeed"].ToString();
                            model.InjectionPressure = reader["InjectionPressure"].ToString();
                            model.RefillSpeed = reader["RefillSpeed"].ToString();
                            model.RefillPressure = reader["RefillPressure"].ToString();
                            model.SuckbackSpeed = reader["SuckbackSpeed"].ToString();
                            model.SuckbackPressure = reader["SuckbackPressure"].ToString();
                            model.DecompressionSpeed = reader["DecompressionSpeed"].ToString();
                            model.DecompressionPressure = reader["DecompressionPressure"].ToString();
                            model.EjectorSpeed = reader["EjectorSpeed"].ToString();
                            model.EjectorPressure = reader["EjectorPressure"].ToString();
                            model.CoresSpeed = reader["CoresSpeed"].ToString();
                            model.CoresPressure = reader["CoresPressure"].ToString();
                            model.MoldHeightSpeed = reader["MoldHeightSpeed"].ToString();
                            model.MoldHeightPressure = reader["MoldHeightPressure"].ToString();
                            model.SetClampOpenSpeed = reader["SetClampOpenSpeed"].ToString();
                            model.ModeClampOpenPressure = reader["ModeClampOpenPressure"].ToString();
                            model.SetClampCloseSpeed = reader["SetClampCloseSpeed"].ToString();
                            model.ModeClampClosePressure = reader["ModeClampClosePressure"].ToString();
                            model.DataId = Convert.ToInt32(reader["DataId"]);
                            model.CreatedOn = Convert.ToDateTime(reader["CreatedOn"]);
                            model.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }

        private  string FormatToDecimalString(object value, int digitCount, int decimalPoint)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                value = 0;

            string raw = value.ToString().Trim();

            if (!int.TryParse(raw, out int number))
                value = 0; // fallback for invalid numbers

            string padded = string.Empty;

            if (digitCount == 1)
                padded = number.ToString("D1");
            if (digitCount == 2)
                padded = number.ToString("D2");
            if (digitCount == 3)
                padded = number.ToString("D3");
            else if (digitCount == 4)
                padded = number.ToString("D4");
            else if (digitCount == 5)
                padded = number.ToString("D5");

            if (decimalPoint == 0)
                return padded;
            else
                return padded.Insert(padded.Length - decimalPoint, ".");



            //if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            //    return "";

            //string raw = value.ToString().Trim();

            //if (!int.TryParse(raw, out int number))
            //    return "";

            //string padded = number.ToString("D" + digitCount);

            //return decimalPoint == 0 ? padded : padded.Insert(padded.Length - decimalPoint, ".");
        }

    }
}
