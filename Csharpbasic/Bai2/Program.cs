using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhập ngày sinh của bạn :");
            string input = Console.ReadLine();

            DateTime birthday;
            if (DateTime.TryParseExact(input, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out birthday))
            {
                DateTime today = DateTime.Today;

                if (today.Month == birthday.Month && today.Day == birthday.Day)
                {
                    Console.WriteLine("Chúc mừng sinh nhật!");
                }
                else
                {
                    DateTime nextBirthday = new DateTime(today.Year, birthday.Month, birthday.Day);
                    if (nextBirthday < today)
                    {
                        nextBirthday = nextBirthday.AddYears(1);
                    }

                    int daysUntilBirthday = (nextBirthday - today).Days;
                    Console.WriteLine("Còn {0} ngày nữa là tới sinh nhật của bạn.", daysUntilBirthday);
                }
            }
            else
            {
                Console.WriteLine("Ngày sinh không hợp lệ.");
            }
        }
    }
}
