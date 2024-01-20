using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace EmployeeManagement
{
    internal class Program
    {

        static void Main(string[] args)
        {

            ////Console.WriteLine(getCurrentData());
            ////string moneyInput = Console.ReadLine();
            ////for (int i = 0; i < moneyInput.Length; i++)
            ////{
            ////    int digit = (int)moneyInput[i];
            ////    if ((digit < 48 && digit != 43) || digit > 57)
            ////    {
            ////        Console.WriteLine(digit);
            ////    }
            ////}
            ////string input = "";
            ////input = Console.ReadLine();
            ////Console.WriteLine(input);
            ////input = Console.ReadLine();
            ////Console.WriteLine(input);   
            ////Encryption encrypt = new Encryption();
            ////string pokemon = "pokemon";
            ////Console.WriteLine(encrypt.encryptDecrypt(pokemon));
            ////Encryption encrypt = new Encryption();
            ////Console.WriteLine(Encryption.Encrypt(pokemon));
            ////string encryptedString = Encryption.Encrypt(pokemon);
            ////Console.WriteLine(Encryption.Decrypt(encryptedString).PadLeft(10));
            //Console.WriteLine("Press any key to continue!!!");
            //Console.ReadKey();
            //Console.WriteLine(getCurrentDate());
            ////File.WriteAllText(@"\testData.txt", pokemon);
            ////File.ReadAllLines("testData.txt");
            ////string docPath = Environment.GetFolderPath(Environment.SpecialFolder.)
            ////var path = Path.Combine(Directory.GetCurrentDirectory(), "testData.txt");
            ////Console.WriteLine(path);
            ////File.WriteAllText(path, "pokevsdfsdfsfme");


            //String str = "{\"Id\":\"123\",\"DateOfRegistration\":\"2012-10-21T00:00:00+05:30\",\"Status\":0}";

            ////string jsonString = JsonSerializer.Serialize(testList, new JsonSerializerOptions() { WriteIndented = true});
            //string jsonString = str.ToString();
            //using (StreamWriter outputFile = new StreamWriter("dataReady.json"))
            //{
            //    outputFile.WriteLine(jsonString);
            //}

            ////path = Path.Combine(Directory.GetCurrentDirectory(), "data.json");

            ////string jsonText = File.ReadAllText(path);
            ////Console.WriteLine(jsonText);

            //var path = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            //string jsonData = File.ReadAllText(path);
            //JsonDocument doc = JsonDocument.Parse(jsonData);
            //JsonElement root = doc.RootElement;

            ////Console.WriteLine(root.ToString());
            ////Console.WriteLine(Encryption.Decrypt(root.GetProperty("username").ToString()));
            ////var information = root[0];
            ////Console.WriteLine(information.ToString());
            ////Console.WriteLine(information.GetProperty("username").ToString());
            //Console.WriteLine(root.GetProperty("information")[0].GetProperty("Address").ToString());
            //Console.WriteLine(root.GetProperty("information").GetArrayLength());

            //string pokemon = "pokemon";
            //string anime = "anime";
            //using var ms = new MemoryStream();
            //using var writer = new Utf8JsonWriter(ms);
            //writer.WriteStartObject();
            //writer.WriteString("username", pokemon);
            //writer.WriteString("password", anime);

            //writer.WriteStartArray("information");
            //for (int i = 0; i< 10; i++)
            //{
            //    writer.WriteStartObject();
            //    writer.WritePropertyName("ID");
            //    writer.WriteStringValue(i.ToString());
            //    writer.WritePropertyName("Name");
            //    writer.WriteStringValue(i.ToString());
            //    writer.WriteStartArray("list");
            //    for (int j = 0; j < 2; j++)
            //    {
            //        writer.WriteStartObject();
            //        writer.WritePropertyName("line1");
            //        writer.WriteStringValue(j.ToString());
            //        writer.WritePropertyName("line2");
            //        writer.WriteStringValue(j.ToString());
            //        writer.WriteEndObject();
            //    }
            //    writer.WriteEndArray();
            //    writer.WriteEndObject();
            //}
            //writer.WriteEndArray();

            //writer.WriteEndObject();
            //writer.Flush();

            //jsonString = Encoding.UTF8.GetString(ms.ToArray());
            //path = Path.Combine(Directory.GetCurrentDirectory(), "dataReady.json");
            //File.WriteAllText(path, jsonString);


            //string result = File.ReadAllText(path);
            //Console.WriteLine(result);




            //string kasumi = "kasumi";
            //string password = "yatokami11";
            //string bd = "1998-07-01";
            //string data = "2023-07-01";
            //int chelsea = 78;
            //Encryption encrypt = new Encryption();
            //Console.WriteLine(encrypt.Encrypt(kasumi));
            //Console.WriteLine(encrypt.Encrypt(password));
            //Console.WriteLine(encrypt.Encrypt(chelsea.ToString()));
            //Console.WriteLine(encrypt.Encrypt(bd));
            //Console.WriteLine(encrypt.Encrypt(data));

            MainApplication mainApp = new MainApplication();
            mainApp.RunApp();


            //int select = 0;
            //do
            //{
            //    Console.WriteLine("Enter number");
            //    WelcomeMenu();
            //    string data = Console.ReadLine();
            //    select = int.Parse(data);
            //    switch (select)
            //    {
            //        case 0:
            //            break;
            //        case 1:
            //            {
            //                int m_select = 0;
            //                do
            //                {
            //                    MainMenu();
            //                    string m_data = Console.ReadLine();
            //                    m_select = int.Parse(m_data);
            //                    if (m_select != 0)
            //                        Console.WriteLine("asdasd: " + m_select);
            //                } while (m_select != 0);
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //    //Console.WriteLine(select);
            //} while (select != 0);

            //int select = 0;
            //Console.WriteLine(select);
            //changeSelect(select);
            //Console.WriteLine(select);

            //void changeSelect(int inputNub)
            //{
            //    inputNub = 5;
            //    select = 5;
            //}

        }

        

    }
}