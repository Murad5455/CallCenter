using System;
using System.Globalization;
using CallCenterAPI.Model;

namespace CallFileProcessor
{
    public interface ICallRecordConverter
    {
        bool IsValidRecord(string[] values);
        CallRecord ConvertToCallRecord(string[] values);
    }

    public class CallRecordConverter : ICallRecordConverter
    {
        public bool IsValidRecord(string[] values)
        {
            return values.Length >= 22;
        }

        public CallRecord ConvertToCallRecord(string[] values)
        {
            if (values.Length < 22)
            {
                throw new ArgumentException("Veriler eksik veya hatalı formatlı.");
            }

            CallRecord callRecord = new CallRecord
            {
                CallId = values[0].Trim(),
                Duration = values[1].Trim(),
                CallStart = DateTime.ParseExact(values[2], "HH:mm:ss", CultureInfo.InvariantCulture),
                TimeAnswered = DateTime.ParseExact(values[3], "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture),
                TimeEnd = DateTime.ParseExact(values[4], "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture),
                TimeStart = DateTime.ParseExact(values[5], "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture),
                Status = values[6].Trim(),
                FromNo = values[7].Trim(),
                ToNo = values[8].Trim(),
                FromDn = values[9].Trim(),
                ToDn = values[10].Trim(),
                DialNo = values[11].Trim(),
                FinalNumber = values[12].Trim(),
                ReasonChanged = values[13].Trim(),
                FinalDn = values[14].Trim(),
                CallAnswered = values[15].Trim(),
                Internal = values[16].Trim(),
                External = values[17].Trim(),
                CallDuration = values[18].Trim(),
                SecondInternal = values[19].Trim(),
                CallEnd = values[20].Trim(),
                ReasonTerminated = values[21].Trim(),
            };

            return callRecord;
        }

    }
}


