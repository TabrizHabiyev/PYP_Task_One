namespace PYP_Task_One.Aplication.RequestMessage
{
    public class Messages
    {
        static public Dictionary<string, string> SendRaportMessage
        {
            get
            {
             var message = new Dictionary<string, string>()
            {
             {"NoData", "No data found in the range you specified"},
             {"GenarateExcelError","Error occurred while generating excel file"},
             {"EmailSendingError","An error occurred while sending the report by mail"},
             {"RaportSucceded","The report has been sent to your e-mail address"},
            };
                return message;
            }
        }
    }
}
