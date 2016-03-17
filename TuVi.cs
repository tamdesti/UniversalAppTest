using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKTemplate
{
    public class TuVi
    {
        private int day, month, year, hour, minute, second, gender;
        private String name;
        private double LOCAL_TIMEZONE = 7.0; //Lay chuan theo GMT + 7 Viet Nam (HaNoi)
        private String[] CAN = { "Giáp", "Ất", "Bính", "Đinh", "Mậu", "Kỷ", "Canh", "Tân", "Nhâm", "Qúy" };
        private String[] CHI = { "Tí", "Sửu", "Dần", "Mão", "Thìn", "Tỵ", "Ngọ", "Mùi", "Thân", "Dậu", "Tuất", "Hợi" };
        private String[] yinYiang = { "Wood", "Metal", "Land", "Sun", "Moon", "Fire", "Water" };
        private String[] yinYiangVN = { "Mộc", "Kim", "Thổ", "Thái Dương", "Thái Âm", "Hỏa", "Thủy" };
        private String[] daySolarA = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private String[] daySolarVietNamA = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
        private String[] monthSolarA = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        private String[] monthSolarVietNamA = { "Tháng Một", "Tháng Hai", "Tháng Ba", "Tháng Tư", "Tháng Năm", "Tháng Sáu", "Tháng Bảy", "Tháng Tám", "Tháng Chín", "Tháng Mười"
                                                 , "Tháng Mười Một", "Tháng Mười Hai" };
        private String[] lunarTime = {"Lập Xuân", "Vũ Thủy", "Kinh Trập", "Xuân Phân", "Thanh Minh", "Cốc Vũ", "Lập Hạ", "Tiển Mãn", "Mang Chủng", "Hạ Chí",
					        "Tiểu Thử", "Đại Thử", "Lập Thu", "Xử Thử", "Bạch Lộ", "Thu Phân", "Hàn Lộ", "Sương Giáng", "Lập Đông", "Tiểu Tuyết",
					        "Đại Tuyết", "Đông Chí", "Tiểu Hàn", "Đại Hàn"};
        private String[] zodiac12 = {"Dương Cưu", "Kim Ngưu", "Song Tử", "Cự Giải", "Sư Tử", "Xử Nữ", "Thiên Bình", "Hổ Cáp", "Nhân Mã", 
                                        "Nam Dương", "Bảo Bình", "Song Ngư"};
        private String[] plant20 = {"Cây Táo", "Cây Phi Lao", "Cây Xà Cừ", "Cây Bách", "Cây Dương", "Cây Tùng", "Cây Thông", "Cây Liễu", "Cây Xoan", "Cây Sồi",
        "Cây Trúc Đào", "Cây Thanh Hương Trà", "Cây Chanh", "Cây Óc Chó", "Cây Hạt Dẻ", "Cây Tần Bì", "Cây Sao Đen", "Cây Sung", "Cây Ô Liu", "Cây Chò"};
        private String[] color20 = {"Đỏ", "Cam", "Vàng", "Hồng", "Xanh Ngọc", "Xanh Lá Cây", "Nâu", "Xanh Nước Biển", "Vàng Chanh", "Đen",
        "Tím", "Xanh Lính Thủy", "Bạc", "Trắng", "Xanh Da Trời", "Mạ Vàng", "Kem", "Xám", "Nâu Sẫm", "Ô Liu"};
        private String[] animal12 = { "Ngỗng", "Rái Cá", "Báo", "Cá Hồi", "Hải Ly", "Hươu", "Chim Gõ Kiến", "Diều Hâu", "Gấu", "Quạ", "Rắn", "Nai" };
        private String[] zodiacStarA = {"Thanh Long", "Minh Đường", "Thiên Hình", "Chu Tước", "Kim Quỹ", "Kim Đường", "Bạch Hổ", "Ngọc Đường", "Thiên Lao", 
                                          "Nguyên Vũ", "Tư Mệnh", "Câu Trần"};
        private String[] gbDays = { "Kiến", "Trừ", "Mãn", "Bình", "Định", "Chấp", "Phá", "Nguy", "Thành", "Thu", "Khai", "Bế" };
        private String[] star = {"Giác", "Cang", "Đê", "Phòng", "Tâm", "Vĩ", "Cơ",
				        "Đẩu", "Ngưu", "Nữ", "Hư", "Nguy", "Thất", "Bích",
				        "Khuê", "Lâu", "Vị", "Mão", "Tất", "Chủy", "Sâm",
				        "Tỉnh", "Quỷ", "Liễu", "Tinh", "Trương", "Dực", "Chẩn"};
        private String[] yearOf60 = {"Giáp Tí", "Ất Sửu", "Bính Dần", "Đinh Mão", "Mậu Thìn", "Kỷ Tị", "Canh Ngọ", "Tân Mùi", "Nhâm Thân", "Quý Dậu",
					        "Giáp Tuất", "Ất Hợi", "Bính Tí", "Đinh Sửu", "Mậu Dần", "Kỷ Mãi", "Canh Thìn", "Tân Tỵ", "Nhâm Ngọ", "Quý Mùi",
					        "Giáp Thân", "Ất Dậu", "Bính Tuất", "Đinh Hợi", "Mậu Tí", "Kỷ Sửu", "Canh Dần", "Tân Mão", "Nhâm Thìn", "Quý Tỵ",
					        "Giáp Ngọ", "Ất Mùi", "Bính Thân", "Đinh Dậu", "Mậu Tuất", "Kỷ Hợi", "Canh Tí", "Tân Sửu", "Nhâm Dần", "Quý Mão",
					        "Giáp Thìn", "Ất Tỵ", "Bính Ngọ", "Đinh Mùi", "Mậu Thân", "Kỷ Dậu", "Canh Tuất", "Tân Hợi", "Nhâm Tí", "Quý Sửu",
					        "Giáp Dần", "Ất Mão", "Bính Thìn", "Đinh Tỵ", "Mậu Ngọ", "Kỷ Mùi", "Canh Thân", "Tân Dậu", "Nhâm Tuất", "Quý Hợi"};
        private Hashtable yearCache = new Hashtable();

        public TuVi(String name, int day, int month, int year, int hour, int minute)
        {
            this.name = name;
            this.day = day;
            this.month = month;
            this.year = year;
            this.hour = hour;
            this.minute = minute;
            this.second = -1;
            this.gender = -1;
            if (!isLegalDate(day, month, year) || !isLegalTime(hour, minute))
            {
                //MessageBox.Show("Ngày và Giờ nhập không hợp lệ");
            }
        }

        public TuVi(String name, int day, int month, int year, int nSecond)
        {
            this.name = name;
            this.day = day;
            this.month = month;
            this.year = year;
            this.hour = nSecond / 3600;
            this.minute = (nSecond % 3600) / 60;
            this.second = (nSecond % 3600) % 60;
            this.gender = -1;
            if (!isLegalDate(day, month, year) || (nSecond < 0 || nSecond >= 86400))
            {
                //MessageBox.Show("Ngày và Giờ nhập không hợp lệ");
            }
        }

        public TuVi(String name, int day, int month, int year, int hour, int minute, int second)
        {
            this.name = name;
            this.day = day;
            this.month = month;
            this.year = year;
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            this.gender = -1;
            if (!isLegalDate(day, month, year) || !isLegalTime(hour, minute, second))
            {
                //MessageBox.Show("Ngày và Giờ nhập không hợp lệ");
            }
        }

        public TuVi(String name, int day, int month, int year)
        {
            this.name = name;
            this.day = day;
            this.month = month;
            this.year = year;
            this.hour = -1;
            this.minute = -1;
            this.second = -1;
            this.gender = -1;
            if (!isLegalDate(day, month, year))
            {
                //MessageBox.Show("Ngày nhập không hợp lệ");
            }
        }

        public TuVi(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.name = "";
            this.hour = -1;
            this.minute = -1;
            this.second = -1;
            this.gender = -1;
            if (!isLegalDate(day, month, year))
            {
                //MessageBox.Show("Ngày nhập không hợp lệ");
            }
        }

        public TuVi()
        {
            DateTime dt = DateTime.Now;
            this.name = "";
            this.gender = -1;
            this.day = dt.Day;
            this.month = dt.Month;
            this.year = dt.Year;
            this.hour = dt.Hour;
            this.minute = dt.Minute;
            this.second = dt.Second;
        }

        public String getGender()
        {
            String gD = "";
            if (this.gender == 0)
                gD = "Nam";
            else if (this.gender == 1)
                gD = "Nữ";
            return gD;
        }

        public void setGender(int gender)
        {
            if (isGender(gender))
                this.gender = gender;
            else
            {
                //MessageBox.Show("Nhập Giới tính không đúng, chỉ chấp nhận 0 hoặc 1.\n0 : Nam ; 1 : Nữ");
            }
        }

        public int getDay()
        {
            return day;
        }

        public int getDayLunar()
        {
            int[] am;
            am = Solar2Lunar(this.day, this.month, this.year);
            return am[0];
        }

        public int getMonth()
        {
            return month;
        }

        public int getMonthLunar()
        {
            int[] am;
            am = Solar2Lunar(this.day, this.month, this.year);
            return am[1];
        }

        public int getYear()
        {
            return year;
        }

        public int getYearLunar()
        {
            int[] am;
            am = Solar2Lunar(this.day, this.month, this.year);
            return am[2];
        }

        public void setDate(int day, int month, int year)
        {
            if (!isLegalDate(day, month, year))
            {
                //MessageBox.Show("Ngày không hợp lệ");
            }
            else
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
        }

        public void set(int day, int month, int year, int hour)
        {
            if (!isLegalDate(day, month, year) || (hour < 0 || hour > 23))
            {
                //MessageBox.Show("Ngày hoặc Giờ nhập không hợp lệ");
            }
            else
            {
                this.day = day;
                this.month = month;
                this.year = year;
                this.hour = hour;
            }
        }

        public void set(int day, int month, int year, int hour, int minute)
        {
            if (!isLegalDate(day, month, year) || (!isLegalTime(hour, minute)))
            {
                //MessageBox.Show("Ngày hoặc Giờ nhập không hợp lệ");
            }

            else
            {
                this.day = day;
                this.month = month;
                this.year = year;
                this.hour = hour;
                this.minute = minute;
            }
        }

        public void set(int day, int month, int year, int hour, int minute, int second)
        {
            if (!isLegalDate(day, month, year) || (!isLegalTime(hour, minute, second)))
            {
                //MessageBox.Show("Ngày hoặc Giờ nhập không hợp lệ");
            }

            else
            {
                this.day = day;
                this.month = month;
                this.year = year;
                this.hour = hour;
                this.minute = minute;
                this.second = second;
            }
        }
        

        public void setName(String name)
        {
            this.name = name;
        }

        public int getHour()
        {
            return hour;
        }

        public int getMinute()
        {
            return minute;
        }

        public int getSecond()
        {
            return second;
        }

        public void setTime(int hour, int minute)
        {
            if (!isLegalTime(hour, minute))
            {
                //MessageBox.Show("Nhập Giờ không hợp lệ");
            }

            else
            {
                this.hour = hour;
                this.minute = minute;
            }
        }

        public void setTime(int hour, int minute, int second)
        {
            if (!isLegalTime(hour, minute, second))
            {
                //MessageBox.Show("Nhập Giờ không hợp lệ");
            }
            else
            {
                this.hour = hour;
                this.minute = minute;
                this.second = second;
            }
        }

        public bool isLegalDate(int day, int month, int year)
        {
            String dayS = day.ToString(),
                    monthS = month.ToString(),
                    yearS = year.ToString();
            if (!(day >= 1 && day <= 31 && month >= 1 && month <= 12 && year >= 1)) return false;
            return day <= getDaysOfMonth(month, year);
        }

        public bool isLegalTime(int hour, int minute)
        {
            return (hour >= 0 && hour <= 23) && (minute >= 0 && minute <= 59);
        }

        public bool isLegalTime(int hour, int minute, int second)
        {
            return (hour >= 0 && hour <= 23) && (minute >= 0 && minute <= 59) && (second >= 0 && second <= 59);
        }

        public bool isGender(int numGen)
        {
            return numGen >= 0 && numGen <= 1;
        }

        public bool isBeginMonth()
        {
            return this.day == 1;
        }

        public bool isBeginMonthLunar()
        {
            return getDayLunar() == 1;
        }

        public bool isEndMonth()
        {
            return ((this.day == 30 && (this.month == 4 || this.month == 6 || this.month == 9 || this.month == 11))
                    || (this.day == 31 && (this.month == 1 || this.month == 3
                    || this.month == 5 || this.month == 7 || this.month == 8 || this.month == 10 || this.month == 12))
                    || (isLeapYear() ? this.day == 29 && this.month == 2 : this.day == 28 && this.month == 2));
        }

        public bool isLeapYear()
        {
            return (this.year % 4 == 0 && this.year % 100 != 0) || this.year % 400 == 0;
        }

        public bool isLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        public bool isEndOfYear()
        {
            return (this.day == 31 && this.month == 12);
        }

        public bool isBeginOfYear()
        {
            return (this.day == 1 && this.month == 1);
        }

        public bool isBeginOfYearLunar()
        {
            return (getDayLunar() == 1 && getMonthLunar() == 1);
        }

        public int getAge()
        {
            TuVi tv = new TuVi();
            return tv.getYear() - this.year;
        }

        public int getAgeOfLunar()
        {
            TuVi hs = new TuVi();
            int[] am;
            am = Solar2Lunar(hs.day, hs.month, hs.year);
            return am[2] - getYearLunar();
        }

        public String getAgeLunar()
        {
            String ageLunar = this.yearLunar();
            return ageLunar.Substring(ageLunar.LastIndexOf(" ")).Trim();
        }

        public bool equal(TuVi hs)
        {
            return this.day == hs.getDay() && this.month == hs.getMonth() && this.year == hs.getYear();
        }

        public bool equalLunar(TuVi hs)
        {
            int[] am;
            am = Solar2Lunar(hs.day, hs.month, hs.year);
            return getDayLunar() == am[0] && getMonthLunar() == am[1] && getYearLunar() == am[2];
        }

        public bool lessThan(TuVi hs)
        {
            bool check;
            if (this.year < hs.year)
                check = true;
            else
            {
                if (this.year == hs.year)
                {
                    if (this.month < hs.month)
                        check = true;
                    else
                    {
                        if (this.month == hs.month)
                        {
                            if (this.day < hs.day)
                                check = true;
                            else
                                check = false;
                        }
                        else
                            check = false;
                    }
                }
                else
                    check = false;
            }
            return check;
        }

        public bool lessThanLunar(TuVi hs)
        {
            int[] am;
            am = Solar2Lunar(hs.day, hs.month, hs.year);
            bool check;
            if (getYearLunar() < am[2])
                check = true;
            else
            {
                if (getYearLunar() == am[2])
                {
                    if (getMonthLunar() < am[1])
                        check = true;
                    else
                    {
                        if (getMonthLunar() == am[1])
                        {
                            if (getDayLunar() < am[0])
                                check = true;
                            else
                                check = false;
                        }
                        else
                            check = false;
                    }
                }
                else
                    check = false;
            }
            return check;
        }

        public bool moreThan(TuVi hs)
        {
            bool check;
            if (this.year > hs.year)
                check = true;
            else
            {
                if (this.year == hs.year)
                {
                    if (this.month > hs.month)
                        check = true;
                    else
                    {
                        if (this.month == hs.month)
                        {
                            if (this.day > hs.day)
                                check = true;
                            else
                                check = false;
                        }
                        else
                            check = false;
                    }
                }
                else
                    check = false;
            }
            return check;
        }

        public bool moreThanLunar(TuVi hs)
        {
            int[] am;
            am = Solar2Lunar(hs.day, hs.month, hs.year);
            bool check;
            if (getYearLunar() > am[2])
                check = true;
            else
            {
                if (getYearLunar() == am[2])
                {
                    if (getMonthLunar() > am[1])
                        check = true;
                    else
                    {
                        if (getMonthLunar() == am[1])
                        {
                            if (getDayLunar() > am[0])
                                check = true;
                            else
                                check = false;
                        }
                        else
                            check = false;
                    }
                }
                else
                    check = false;
            }
            return check;
        }

        public int getDaysOfMonth(int m, int y)
        {
            int numberDays = 0;
            switch (m)
            {
                case 2:
                    if (isLeapYear(y))
                        numberDays = 29;
                    else
                        numberDays = 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    numberDays = 30;
                    break;
                default:
                    numberDays = 31;
                    break;
            }
            return numberDays;
        }

        public void increaseOneDay()
        {
            if (isEndMonth())
            {
                if (isEndOfYear())
                {
                    this.month = 1;
                    this.year++;
                }
                else
                    this.month++;
                this.day = 1;
            }
            else
                this.day++;
        }

        public void increaseOneMonth()
        {
            if (this.month == 12 && isEndMonth())
            {
                this.year++;
                this.month = 1;
                if (isLegalDate(this.day, this.month, this.year))
                    this.day = getDaysOfMonth(this.month - 1, this.year);
                else
                    this.day = getDaysOfMonth(this.month, this.year);
            }
            else if (this.month == 12 && !isEndMonth())
            {
                this.year++;
                this.month = 1;
            }
            else if (!(this.month == 12) && isEndMonth())
            {
                this.month++;
                if (isLegalDate(this.day, this.month, this.year))
                    this.day = getDaysOfMonth(this.month - 1, this.year);
                else
                    this.day = getDaysOfMonth(this.month, this.year);
            }
            else if (!(this.month == 12) && !isEndMonth())
            {
                this.month++;
            }
        }

        public void increaseOneYear()
        {
            if (isEndMonth() && this.month == 2)
            {
                if (isLeapYear())
                    this.day = 28;
                this.year++;
            }
            else
                this.year++;
        }

        public void decreaseOneDay()
        {
            if (isBeginMonth())
            {
                if (isBeginOfYear())
                {
                    this.month = 12;
                    this.year--;
                }
                else
                    this.month--;
                this.day = getDaysOfMonth(this.month, this.year);
            }
            else
                this.day--;
        }

        public void decreaseOneMonth()
        {
            if (this.month == 1 && isEndMonth())
            {
                this.year--;
                this.month = 12;
                this.day = getDaysOfMonth(this.month, this.year);
            }
            else if (this.month == 1 && !isEndMonth())
            {
                this.year--;
                this.month = 12;
            }
            else if (!(this.month == 1) && isEndMonth())
            {
                this.month--;
                if (isLegalDate(this.day, this.month, this.year))
                    this.day = getDaysOfMonth(this.month + 1, this.year);
                else
                    this.day = getDaysOfMonth(this.month, this.year);
            }
            else if (!(this.month == 1) && !isEndMonth())
            {
                this.month--;
            }
        }

        public void decreaseOneYear()
        {
            if (isEndMonth() && this.month == 2)
            {
                if (isLeapYear())
                    this.day = 28;
                this.year--;
            }
            else
                this.year--;
        }

        public void add(String field, int amount)
        {
            if (field.Equals("day", StringComparison.OrdinalIgnoreCase) || field.Equals("d", StringComparison.OrdinalIgnoreCase))
            {
                if (amount < 0)
                {
                    for (int i = 1; i <= Math.Abs(amount); i++)
                        decreaseOneDay();
                }
                else
                {
                    for (int i = 1; i <= amount; i++)
                        increaseOneDay();
                }
            }
            if (field.Equals("month", StringComparison.OrdinalIgnoreCase) || field.Equals("m", StringComparison.OrdinalIgnoreCase))
            {
                if (amount < 0)
                {
                    for (int i = 1; i <= Math.Abs(amount); i++)
                        decreaseOneMonth();
                }
                else
                {
                    for (int i = 1; i <= amount; i++)
                        increaseOneMonth();
                }
            }
            if (field.Equals("year", StringComparison.OrdinalIgnoreCase) || field.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                if (amount < 0)
                {
                    for (int i = 1; i <= Math.Abs(amount); i++)
                        decreaseOneYear();
                }
                else
                {
                    for (int i = 1; i <= amount; i++)
                        increaseOneYear();
                }
            }
        }

        public int getDayBetweenDate(TuVi hs)
        {
            int count = 0;
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            if (lessThan(hs))
            {
                while (!equal(hs))
                {
                    increaseOneDay();
                    count++;
                }
            }
            else
            {
                if (moreThan(hs))
                {
                    while (!equal(hs))
                    {
                        decreaseOneDay();
                        count++;
                    }
                }
            }
            this.day = tmp.day;
            this.month = tmp.month;
            this.year = tmp.year;
            return count;
        }

        public int getDayBetweenGD(TuVi hs)
        {
            int count = 0;
            TuVi curTmp, tmp = new TuVi(this.day, this.month, this.year);

            if (lessThan(hs))
            {
                while (!equal(hs))
                {
                    increaseOneDay();
                    if (!isFirstLunarPeriod())
                        count++;
                }
            }
            else
            {
                if (moreThan(hs))
                {
                    while (!equal(hs))
                    {
                        curTmp = new TuVi(this.day, this.month, this.year);
                        decreaseOneDay();
                        if (!curTmp.isFirstLunarPeriod())
                            count++;
                    }
                }
            }
            this.day = tmp.day;
            this.month = tmp.month;
            this.year = tmp.year;
            return count;
        }

        public int getDayBetweenStar(TuVi hs)
        {
            int count = 0;
            TuVi tmp = new TuVi(this.day, this.month, this.year);
            int[] am, curTmp;
            String leap;
            if (lessThan(hs))
            {
                while (!equal(hs))
                {
                    increaseOneDay();
                    count++;
                    am = Solar2Lunar(this.day, this.month, this.year);
                    leap = am[3] == 1 ? "leap" : "";
                    if (am[0] == 1)
                    {
                        if (!leap.Equals("leap", StringComparison.OrdinalIgnoreCase))
                            count -= 2;
                    }
                }
            }
            else
            {
                if (moreThan(hs))
                {
                    while (!equal(hs))
                    {
                        curTmp = Solar2Lunar(this.day, this.month, this.year);
                        decreaseOneDay();
                        count++;
                        leap = curTmp[3] == 1 ? "leap" : "";
                        if (curTmp[0] == 1)
                        {
                            if (!leap.Equals("leap", StringComparison.OrdinalIgnoreCase))
                                count -= 2;
                        }
                    }
                }
            }
            this.day = tmp.day;
            this.month = tmp.month;
            this.year = tmp.year;
            return count;
        }

        public int getMonthBetweenDate(TuVi hs)
        {
            int numMonths;
            if (this.year <= hs.year)
                numMonths = (hs.year - this.year) * 12 + hs.month - this.month;
            else
                numMonths = (this.year - hs.year) * 12 + this.month - hs.month;
            return numMonths;
        }

        public int getYearBetweenDate(TuVi hs)
        {
            int count = 0;
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            if (this.year < hs.year)
            {
                while (this.year != hs.year)
                {
                    increaseOneYear();
                    count++;
                }
            }
            else
            {
                if (this.year > hs.year)
                {
                    while (this.year != hs.year)
                    {
                        decreaseOneYear();
                        count++;
                    }
                }
            }
            this.day = tmp.day;
            this.month = tmp.month;
            this.year = tmp.year;
            return count;
        }

        public int sumDayOfYear()
        {
            int numDay = 0;
            if (isLeapYear())
                numDay = 366;
            else
                numDay = 365;
            return numDay;
        }

        public int getDayOfYear()
        {
            int count = 0;
            TuVi tmp = new TuVi(this.day, this.month, this.year);
            while (!isEndOfYear())
            {
                count++;
                increaseOneDay();
            }
            this.day = tmp.day;
            this.month = tmp.month;
            this.year = tmp.year;
            return sumDayOfYear() - count;
        }

        public int getDayOfWeek()
        {
            int nDOW = 1; // Chu Nhat
            if (daySolar().Equals(daySolarA[1], StringComparison.OrdinalIgnoreCase))
                nDOW = 2;
            else if (daySolar().Equals(daySolarA[2], StringComparison.OrdinalIgnoreCase))
                nDOW = 3;
            else if (daySolar().Equals(daySolarA[3], StringComparison.OrdinalIgnoreCase))
                nDOW = 4;
            else if (daySolar().Equals(daySolarA[4], StringComparison.OrdinalIgnoreCase))
                nDOW = 5;
            else if (daySolar().Equals(daySolarA[5], StringComparison.OrdinalIgnoreCase))
                nDOW = 6;
            else if (daySolar().Equals(daySolarA[6], StringComparison.OrdinalIgnoreCase))
                nDOW = 7;
            return nDOW;
        }

        public int getDayOfWeekInMonth()
        {
            return (int)(Math.Ceiling((double)getDay() / 7)) + 1;
        }

        public int getDayOfMonth()
        {
            return getDay();
        }

        public int getWeekOfYear()
        {
            return (getDayOfYear() / 7) + 1;
        }

        public String orientTime()
        {
            String h = "";

            if (this.hour == -1 || this.minute == -1)
            {
                //MessageBox.Show("Nhập Giờ không hợp lệ");
            }

            int totaltime = this.hour * 60 + this.minute;

            //If month 1 and month 9
            if (getMonth() == 1 || getMonth() == 9)
            {
                //From 1h - 3h19m (h = hour ; m = minute)
                if (totaltime >= 60 && totaltime <= 199)
                    h = CHI[0]; //Ti
                //From 3h20m - 5h19m
                else if (totaltime >= 200 && totaltime <= 319)
                    h = CHI[1]; //Suu
                //From 5h20m - 7h19m
                else if (totaltime >= 320 && totaltime <= 439)
                    h = CHI[2]; //Dan
                //From 7h20m - 9h19m
                else if (totaltime >= 440 && totaltime <= 559)
                    h = CHI[3]; //Mao
                //From 9h20m - 11h19m
                else if (totaltime >= 560 && totaltime <= 679)
                    h = CHI[4]; //Thin
                //From 11h20m - 13h19m
                else if (totaltime >= 680 && totaltime <= 799)
                    h = CHI[5]; //Ty
                //From 13h20m - 15h19m
                else if (totaltime >= 800 && totaltime <= 919)
                    h = CHI[6]; //Ngo
                //From 15h20m - 17h19m
                else if (totaltime >= 920 && totaltime <= 1039)
                    h = CHI[7]; //Mui
                //From 17h20m - 19h19m
                else if (totaltime >= 1040 && totaltime <= 1159)
                    h = CHI[8]; //Than
                //From 19h20m - 21h19m
                else if (totaltime >= 1160 && totaltime <= 1279)
                    h = CHI[9]; //Dau
                //From 21h20m - 23h20m
                else if (totaltime >= 1280 && totaltime <= 1399)
                    h = CHI[10]; //Tuat
                //From 23h20m - 24h59m
                else
                    h = CHI[11]; //Hoi
            }
            //If month 2, 8, 10, and 12
            else if (getMonth() == 2 || getMonth() == 8 || getMonth() == 10 || getMonth() == 12)
            {
                //From 1h - 2h59m (h = hour ; m = minute)
                if (totaltime >= 60 && totaltime <= 179)
                    h = CHI[0]; //Ti
                //From 3h - 4h59m
                else if (totaltime >= 180 && totaltime <= 299)
                    h = CHI[1]; //Suu
                //From 5h - 6h59m
                else if (totaltime >= 300 && totaltime <= 419)
                    h = CHI[2]; //Dan
                //From 7h - 8h59m
                else if (totaltime >= 420 && totaltime <= 539)
                    h = CHI[3]; //Mao
                //From 9h - 10h59m
                else if (totaltime >= 540 && totaltime <= 659)
                    h = CHI[4]; //Thin
                //From 11h - 12h59m
                else if (totaltime >= 660 && totaltime <= 779)
                    h = CHI[5]; //Ty
                //From 13h - 14h59m
                else if (totaltime >= 780 && totaltime <= 899)
                    h = CHI[6]; //Ngo
                //From 15h - 16h59m
                else if (totaltime >= 900 && totaltime <= 1019)
                    h = CHI[7]; //Mui
                //From 17h - 18h59m
                else if (totaltime >= 1020 && totaltime <= 1139)
                    h = CHI[8]; //Than
                //From 19h - 20h59m
                else if (totaltime >= 1140 && totaltime <= 1259)
                    h = CHI[9]; //Dau
                //From 21h - 22h59m
                else if (totaltime >= 1260 && totaltime <= 1379)
                    h = CHI[10]; //Tuat
                //From 23h - 24h59m
                else
                    h = CHI[11]; //Hoi
            }
            //If month 3 and month 7
            else if (getMonth() == 3 || getMonth() == 7)
            {
                //From 1h30 - 3h29m (h = hour ; m = minute)
                if (totaltime >= 90 && totaltime <= 209)
                    h = CHI[0]; //Ti
                //From 3h30 - 5h29m
                else if (totaltime >= 210 && totaltime <= 329)
                    h = CHI[1]; //Suu
                //From 5h30 - 7h29m
                else if (totaltime >= 330 && totaltime <= 449)
                    h = CHI[2]; //Dan
                //From 7h30 - 9h29m
                else if (totaltime >= 450 && totaltime <= 569)
                    h = CHI[3]; //Mao
                //From 9h30 - 11h29m
                else if (totaltime >= 570 && totaltime <= 689)
                    h = CHI[4]; //Thin
                //From 11h30 - 13h29m
                else if (totaltime >= 690 && totaltime <= 809)
                    h = CHI[5]; //Ty
                //From 13h30 - 15h29m
                else if (totaltime >= 810 && totaltime <= 929)
                    h = CHI[6]; //Ngo
                //From 15h30 - 17h29m
                else if (totaltime >= 930 && totaltime <= 1049)
                    h = CHI[7]; //Mui
                //From 17h30 - 19h29m
                else if (totaltime >= 1050 && totaltime <= 1169)
                    h = CHI[8]; //Than
                //From 19h30 - 21h29m
                else if (totaltime >= 1170 && totaltime <= 1289)
                    h = CHI[9]; //Dau
                //From 21h30 - 23h29m
                else if (totaltime >= 1290 && totaltime <= 1409)
                    h = CHI[10]; //Tuat
                //From 23h30 - 1h29m
                else
                    h = CHI[11]; //Hoi
            }
            //If month 4 and month 6
            else if (getMonth() == 4 || getMonth() == 6)
            {
                //From 1h40 - 3h39m (h = hour ; m = minute)
                if (totaltime >= 100 && totaltime <= 219)
                    h = CHI[0]; //Ti
                //From 3h40 - 5h39m
                else if (totaltime >= 220 && totaltime <= 339)
                    h = CHI[1]; //Suu
                //From 5h40 - 7h39m
                else if (totaltime >= 340 && totaltime <= 459)
                    h = CHI[2]; //Dan
                //From 7h40 - 9h39m
                else if (totaltime >= 460 && totaltime <= 579)
                    h = CHI[3]; //Mao
                //From 9h40 - 11h39m
                else if (totaltime >= 580 && totaltime <= 699)
                    h = CHI[4]; //Thin
                //From 11h40 - 13h39m
                else if (totaltime >= 700 && totaltime <= 819)
                    h = CHI[5]; //Ty
                //From 13h40 - 15h39m
                else if (totaltime >= 820 && totaltime <= 939)
                    h = CHI[6]; //Ngo
                //From 15h40 - 17h39m
                else if (totaltime >= 940 && totaltime <= 1059)
                    h = CHI[7]; //Mui
                //From 17h40 - 19h39m
                else if (totaltime >= 1060 && totaltime <= 1179)
                    h = CHI[8]; //Than
                //From 19h40 - 21h39m
                else if (totaltime >= 1180 && totaltime <= 1299)
                    h = CHI[9]; //Dau
                //From 21h40 - 23h39m
                else if (totaltime >= 1300 && totaltime <= 1419)
                    h = CHI[10]; //Tuat
                //From 23h40 - 1h39m
                else
                    h = CHI[11]; //Hoi
            }
            //If month 5
            else if (getMonth() == 5)
            {
                //From 24h20 - 2h19m (h = hour ; m = minute)
                if (totaltime >= 20 && totaltime <= 139)
                    h = CHI[11]; //Hoi
                //From 2h20 - 4h19m 
                else if (totaltime >= 140 && totaltime <= 259)
                    h = CHI[0]; //Ti
                //From 4h20 - 6h19m
                else if (totaltime >= 260 && totaltime <= 379)
                    h = CHI[1]; //Suu
                //From 6h20 - 8h19m
                else if (totaltime >= 380 && totaltime <= 499)
                    h = CHI[2]; //Dan
                //From 8h20 - 10h19m
                else if (totaltime >= 500 && totaltime <= 619)
                    h = CHI[3]; //Mao
                //From 10h20 - 12h19m
                else if (totaltime >= 620 && totaltime <= 739)
                    h = CHI[4]; //Thin
                //From 12h20 - 14h19m
                else if (totaltime >= 740 && totaltime <= 859)
                    h = CHI[5]; //Ty
                //From 14h20 - 16h19m
                else if (totaltime >= 860 && totaltime <= 979)
                    h = CHI[6]; //Ngo
                //From 16h20 - 18h19m
                else if (totaltime >= 980 && totaltime <= 1099)
                    h = CHI[7]; //Mui
                //From 18h20 - 20h19m
                else if (totaltime >= 1100 && totaltime <= 1219)
                    h = CHI[8]; //Than
                //From 20h20 - 22h19m
                else if (totaltime >= 1220 && totaltime <= 1339)
                    h = CHI[9]; //Dau
                //From 22h20 - 24h19m
                else
                    h = CHI[10]; //Tuat
            }
            //If month 11
            else if (getMonth() == 11)
            {
                //From 24h40 - 2h59m (h = hour ; m = minute)
                if (totaltime >= 40 && totaltime <= 179)
                    h = CHI[0]; //Ti
                //From 3h - 4h59m
                else if (totaltime >= 180 && totaltime <= 299)
                    h = CHI[1]; //Suu
                //From 5h - 6h59m
                else if (totaltime >= 300 && totaltime <= 419)
                    h = CHI[2]; //Dan
                //From 7h - 8h59m
                else if (totaltime >= 420 && totaltime <= 539)
                    h = CHI[3]; //Mao
                //From 9h - 10h59m
                else if (totaltime >= 540 && totaltime <= 659)
                    h = CHI[4]; //Thin
                //From 11 - 12h59m
                else if (totaltime >= 660 && totaltime <= 779)
                    h = CHI[5]; //Ty
                //From 13h - 14h59m
                else if (totaltime >= 780 && totaltime <= 899)
                    h = CHI[6]; //Ngo
                //From 15h - 16h59m
                else if (totaltime >= 900 && totaltime <= 1019)
                    h = CHI[7]; //Mui
                //From 17h - 18h59m
                else if (totaltime >= 1020 && totaltime <= 1139)
                    h = CHI[8]; //Than
                //From 19h - 20h59m
                else if (totaltime >= 1140 && totaltime <= 1259)
                    h = CHI[9]; //Dau
                //From 21h - 22h59m
                else if (totaltime >= 1260 && totaltime <= 1379)
                    h = CHI[10]; //Tuat
                //From 23h - 24h39m
                else
                    h = CHI[11]; //Hoi
            }
            return h;
        }

        public String dayLunar()
        {
            int iCan = 3, iChi = 9;
            TuVi tmp = new TuVi(this.day, this.month, this.year);
            int numDays = getDayBetweenDate(new TuVi(1, 3, 1996));
            if (tmp.lessThan(new TuVi(1, 3, 1996)))
            {
                iCan = (iCan - numDays % 10 + 10) % 10;
                iChi = (iChi - numDays % 12 + 12) % 12;
            }
            else
            {
                if (tmp.moreThan(new TuVi(1, 3, 1996)))
                {
                    iCan = (iCan + numDays % 10) % 10;
                    iChi = (iChi + numDays % 12) % 12;
                }
            }
            return CAN[iCan] + " " + CHI[iChi];
        }

        public String yearLunar()
        {
            int iCan = 2, iChi = 0;
            int numYears = Math.Abs(1996 - this.year);

            if (this.year < 1996)
            {
                iCan = (iCan - numYears % 10 + 10) % 10;
                iChi = (iChi - numYears % 12 + 12) % 12;
            }
            else
            {
                if (this.year > 1996)
                {
                    iCan = (iCan + numYears % 10) % 10;
                    iChi = (iChi + numYears % 12) % 12;
                }
            }
            return CAN[iCan] + " " + CHI[iChi];
        }

        public String daySolar()
        {
            int idaySolar = 5;
            TuVi tmp = new TuVi(this.day, this.month, this.year);
            int numDays = getDayBetweenDate(new TuVi(1, 3, 1996));
            if (tmp.lessThan(new TuVi(1, 3, 1996)))
                idaySolar = (idaySolar - numDays % 7 + 7) % 7;
            else
            {
                if (tmp.moreThan(new TuVi(1, 3, 1996)))
                    idaySolar = (idaySolar + numDays % 7) % 7;
            }
            return daySolarA[idaySolar];
        }

        public String star28()
        {
            int iStar = 13;
            TuVi tmp = new TuVi(this.day, this.month, this.year);
            int numDays = getDayBetweenDate(new TuVi(1, 1, 1997));
            if (tmp.lessThan(new TuVi(1, 1, 1997)))
                iStar = (iStar - numDays % 28 + 28) % 28;
            else
            {
                if (tmp.moreThan(new TuVi(1, 1, 1997)))
                    iStar = (iStar + numDays % 28) % 28;
            }
            return star[iStar];
        }

        public String yinAndYiang()
        {
            String tmp = star28(), yinyiang = "";
            if (tmp.Equals("Giác", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Đẩu", StringComparison.OrdinalIgnoreCase)
                || tmp.Equals("Khuê", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Tỉnh", StringComparison.OrdinalIgnoreCase))
                yinyiang = yinYiangVN[0]; //Moc

            if (tmp.Equals("Cang", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Ngưu", StringComparison.OrdinalIgnoreCase)
                    || tmp.Equals("Lâu", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Quỷ", StringComparison.OrdinalIgnoreCase))
                yinyiang = yinYiangVN[1]; //Kim

            if (tmp.Equals("Đê", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Nữ", StringComparison.OrdinalIgnoreCase)
                    || tmp.Equals("Vi", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Liễu", StringComparison.OrdinalIgnoreCase))
                yinyiang = yinYiangVN[2]; //Tho

            if (tmp.Equals("Phòng", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Hư", StringComparison.OrdinalIgnoreCase)
                    || tmp.Equals("Mão", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Tinh", StringComparison.OrdinalIgnoreCase))
                yinyiang = yinYiangVN[3]; //Thai Duong

            if (tmp.Equals("Tâm", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Nguy", StringComparison.OrdinalIgnoreCase)
                    || tmp.Equals("Tất", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Trương", StringComparison.OrdinalIgnoreCase))
                yinyiang = yinYiangVN[4]; //Thai Am

            if (tmp.Equals("Vi", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Thất", StringComparison.OrdinalIgnoreCase)
                    || tmp.Equals("Chủy", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Lâu", StringComparison.OrdinalIgnoreCase))
                yinyiang = yinYiangVN[5]; //Hoa

            if (tmp.Equals("Cơ", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Bích", StringComparison.OrdinalIgnoreCase)
                    || tmp.Equals("Sâm", StringComparison.OrdinalIgnoreCase) || tmp.Equals("Chấn", StringComparison.OrdinalIgnoreCase))
                yinyiang = yinYiangVN[6]; //Thuy
            return yinyiang;
        }

        public String lunarPeriod()
        {
            String zd = "";
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            //Lap Xuan (From 4/2 to 18/2)
            if (((tmp.moreThan(new TuVi(4, 2, this.year))) ||
                    (tmp.equal(new TuVi(4, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(18, 2, this.year))) ||
                            (tmp.equal(new TuVi(18, 2, this.year)))))
                zd = lunarTime[0];

            //Vu Thuy (From 19/2 to 5/3)
            if (((tmp.moreThan(new TuVi(19, 2, this.year))) ||
                    (tmp.equal(new TuVi(19, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(5, 3, this.year))) ||
                            (tmp.equal(new TuVi(5, 3, this.year)))))
                zd = lunarTime[1];

            //Kinh Trap (From 6/3 to 20/3)
            if (((tmp.moreThan(new TuVi(6, 3, this.year))) ||
                    (tmp.equal(new TuVi(6, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 3, this.year))) ||
                            (tmp.equal(new TuVi(20, 3, this.year)))))
                zd = lunarTime[2];

            //Xuan Phan (From 21/3 to 4/4)
            if (((tmp.moreThan(new TuVi(21, 3, this.year))) ||
                    (tmp.equal(new TuVi(21, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(4, 4, this.year))) ||
                            (tmp.equal(new TuVi(4, 4, this.year)))))
                zd = lunarTime[3];

            //Thanh Minh (From 5/4 to 19/4)
            if (((tmp.moreThan(new TuVi(5, 4, this.year))) ||
                    (tmp.equal(new TuVi(5, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(19, 4, this.year))) ||
                            (tmp.equal(new TuVi(19, 4, this.year)))))
                zd = lunarTime[4];

            //Coc Vu (From 20/4 to 5/5)
            if (((tmp.moreThan(new TuVi(20, 4, this.year))) ||
                    (tmp.equal(new TuVi(20, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(5, 5, this.year))) ||
                            (tmp.equal(new TuVi(5, 5, this.year)))))
                zd = lunarTime[5];

            //Lap Ha (From 6/5 to 20/5)
            if (((tmp.moreThan(new TuVi(6, 5, this.year))) ||
                    (tmp.equal(new TuVi(6, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 5, this.year))) ||
                            (tmp.equal(new TuVi(20, 5, this.year)))))
                zd = lunarTime[6];

            //Tieu Man (From 21/5 to 5/6)
            if (((tmp.moreThan(new TuVi(21, 5, this.year))) ||
                    (tmp.equal(new TuVi(21, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(5, 6, this.year))) ||
                            (tmp.equal(new TuVi(5, 6, this.year)))))
                zd = lunarTime[7];

            //Mang Chung (From 6/6 to 20/6)
            if (((tmp.moreThan(new TuVi(6, 6, this.year))) ||
                    (tmp.equal(new TuVi(6, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 6, this.year))) ||
                            (tmp.equal(new TuVi(20, 6, this.year)))))
                zd = lunarTime[8];

            //Ha Chi (From 21/6 to 6/7)
            if (((tmp.moreThan(new TuVi(21, 6, this.year))) ||
                    (tmp.equal(new TuVi(21, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(6, 7, this.year))) ||
                            (tmp.equal(new TuVi(6, 7, this.year)))))
                zd = lunarTime[9];

            //Tieu Thu (From 7/7 to 22/7)
            if (((tmp.moreThan(new TuVi(7, 7, this.year))) ||
                    (tmp.equal(new TuVi(7, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 7, this.year))) ||
                            (tmp.equal(new TuVi(22, 7, this.year)))))
                zd = lunarTime[10];

            //Dai Thu (From 23/7 to 7/8)
            if (((tmp.moreThan(new TuVi(23, 7, this.year))) ||
                    (tmp.equal(new TuVi(23, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(7, 8, this.year))) ||
                            (tmp.equal(new TuVi(7, 8, this.year)))))
                zd = lunarTime[11];

            //Lap Thu (From 8/8 to 22/8)
            if (((tmp.moreThan(new TuVi(8, 8, this.year))) ||
                    (tmp.equal(new TuVi(8, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 8, this.year))) ||
                            (tmp.equal(new TuVi(22, 8, this.year)))))
                zd = lunarTime[12];

            //Xu Thu (From 23/8 to 7/9)
            if (((tmp.moreThan(new TuVi(23, 8, this.year))) ||
                    (tmp.equal(new TuVi(23, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(7, 9, this.year))) ||
                            (tmp.equal(new TuVi(7, 9, this.year)))))
                zd = lunarTime[13];

            //Bach Lo (From 8/9 to 22/9)
            if (((tmp.moreThan(new TuVi(8, 9, this.year))) ||
                    (tmp.equal(new TuVi(8, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 9, this.year))) ||
                            (tmp.equal(new TuVi(22, 9, this.year)))))
                zd = lunarTime[14];

            //Thu Phan (From 23/9 to 7/10)
            if (((tmp.moreThan(new TuVi(23, 9, this.year))) ||
                    (tmp.equal(new TuVi(23, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(7, 10, this.year))) ||
                            (tmp.equal(new TuVi(7, 10, this.year)))))
                zd = lunarTime[15];

            //Han Lo (From 8/10 to 22/10)
            if (((tmp.moreThan(new TuVi(8, 10, this.year))) ||
                    (tmp.equal(new TuVi(8, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 10, this.year))) ||
                            (tmp.equal(new TuVi(22, 10, this.year)))))
                zd = lunarTime[16];

            //Suong Giang (From 23/10 to 6/11)
            if (((tmp.moreThan(new TuVi(23, 10, this.year))) ||
                    (tmp.equal(new TuVi(23, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(6, 11, this.year))) ||
                            (tmp.equal(new TuVi(6, 11, this.year)))))
                zd = lunarTime[17];

            //Lap Dong (From 7/11 to 21/11)
            if (((tmp.moreThan(new TuVi(7, 11, this.year))) ||
                    (tmp.equal(new TuVi(7, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 11, this.year))) ||
                            (tmp.equal(new TuVi(21, 11, this.year)))))
                zd = lunarTime[18];

            //Tieu Tuyet (From 22/11 to 5/12)
            if (((tmp.moreThan(new TuVi(22, 11, this.year))) ||
                    (tmp.equal(new TuVi(22, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(5, 12, this.year))) ||
                            (tmp.equal(new TuVi(5, 12, this.year)))))
                zd = lunarTime[19];

            //Dai Tuyet (From 6/12 to 21/12)
            if (((tmp.moreThan(new TuVi(6, 12, this.year))) ||
                    (tmp.equal(new TuVi(6, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 12, this.year))) ||
                            (tmp.equal(new TuVi(21, 12, this.year)))))
                zd = lunarTime[20];

            //Dong Chi (From 22/12 to 4/1)
            if (((tmp.moreThan(new TuVi(22, 12, this.year))) ||
                    (tmp.equal(new TuVi(22, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(31, 12, this.year))) ||
                    (tmp.equal(new TuVi(31, 12, this.year)))) ||
                ((tmp.moreThan(new TuVi(1, 1, this.year))) ||
                    (tmp.equal(new TuVi(1, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(4, 1, this.year))) ||
                    (tmp.equal(new TuVi(4, 1, this.year)))))
                zd = lunarTime[21];

            //Tieu Han (From 5/1 to 19/1)
            if (((tmp.moreThan(new TuVi(5, 1, this.year))) ||
                    (tmp.equal(new TuVi(5, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(19, 1, this.year))) ||
                            (tmp.equal(new TuVi(19, 1, this.year)))))
                zd = lunarTime[22];

            //Dai Han (From 20/1 to 3/2)
            if (((tmp.moreThan(new TuVi(20, 1, this.year))) ||
                    (tmp.equal(new TuVi(20, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(3, 2, this.year))) ||
                            (tmp.equal(new TuVi(3, 2, this.year)))))
                zd = lunarTime[23];
            return zd;
        }

        public bool isFirstLunarPeriod()
        {
            bool check = false;
            if (this.day == 4 && this.month == 2) check = true;
            if (this.day == 5 && this.month == 3) check = true;
            if (this.day == 5 && this.month == 4) check = true;
            if (this.day == 6 && this.month == 5) check = true;
            if (this.day == 6 && this.month == 6) check = true;
            if (this.day == 7 && this.month == 7) check = true;
            if (this.day == 7 && this.month == 8) check = true;
            if (this.day == 8 && this.month == 9) check = true;
            if (this.day == 7 && this.month == 11) check = true;
            if (this.day == 7 && this.month == 12) check = true;
            if (this.day == 6 && this.month == 1) check = true;
            return check;
        }        

        public String forecastDate()
        {
            String sStr = "";
            int point = 0, numPoint = 0, dateOfYou;
            sStr = this.day.ToString() + this.month.ToString() + this.year.ToString();
            dateOfYou = int.Parse(sStr);
            while (dateOfYou > 0)
            {
                point += dateOfYou % 10;
                dateOfYou /= 10;
            }

            while (point > 0)
            {
                numPoint += point % 10;
                point /= 10;
            }

            point = numPoint;
            numPoint = 0;

            while (point > 0)
            {
                numPoint += point % 10;
                point /= 10;
            }

            switch (numPoint)
            {
                case 1:
                    sStr = "Bạn là người cá tính mạnh, nhiệt tình, cao thương nhưng kiêu và " +
                        "có vẻ cá nhân chủ nghĩa, hơi độc đoán, bỏ các góp ý ngoài tai. Độc đoán " +
                        "nhưng mọi lúc, mọi nơi tâm hồn đều cân bằng.";
                    break;
                case 2:
                    sStr = "Tưởng tượng là đặc tính cơ bản. Thích tập thể, là người hòa giải, biết tự lo liệu. Giàu tình cảm, chấp nhận cuộc sống hiện có " +
                        "nhưng vẫn mơ ước ghê gớm. Kiên nhẫn và hợp tác trong lao động, có năng khiếu với những vấn đề tế nhị. Có ý thức rõ ràng về nhân đạo, " +
                        "công bằng và hoài bão lớn. Thành đạt nhưng có khi cũng hỏng việc.";
                    break;
                case 3:
                    sStr = "Là người sáng tạo, đổi mới, cách tân. Luôn tìm tòi những vấn đề mới. Luôn tử tế, hiền diệu và giản dị, hòa nhập với mọi người trong " +
                        "lao động. Cá tính hơi nhút nhát. Vượt qua tất cả những khó khăn và trở ngại. Có đôi chút ghen tuôn nhưng rất lạc quan.";
                    break;
                case 4:
                    sStr = "Người luôn hoạt động, ý thức rõ ràng, mạnh mẽ về tính cách, sẵn sàng vượt lên, cố gắng để thành công. Hợp lý, có óc tổ chức, làm " +
                        "việc chính xác và có phương pháp, trung thực. Kiến trúc sư của những kế hoạch nhưng là người hay lo lắng, căng thẳng.";
                    break;
                case 5:
                    sStr = "Là biểu tượng cho sự đổi mới, hành động theo hướng siêu tự nhiên. Hay đi xa, thích hoạt động trí tuệ. Cá tính không " +
                        "ổn định, dễ bị kích động. Không thích thú khi bị ràng buộc, chỉ thích quản lý. Nhiều ham muốn, không mơ mộng và không dối trá.";
                    break;
                case 6:
                    sStr = "Vui vẻ, sống gắn bó tử tế, thẳng thắn, tinh thần mạnh mẽ. Sẵn sàng hy sinh với trách nhiệm, với xã hội. Đường tiến thân là chính trị, " +
                        "quân sự, tài chính. Dịu hiền, thủy chung với gia đình. Tuy vậy có một chút hiềm khích và bi quan.";
                    break;
                case 7:
                    sStr = "Khôn ngoan và khá hoàn hảo. Biết suy tính, dành dụm và mơ ước. Sống nội tâm, là một người nghiên cứu, nhà tư tưởng. Dễ dao động giữa rộng " +
                        "lượng cà ích kỷ, nếu cần, dễ hủy bỏ hoặc không trung thành với thắng lợi. Hay gặp may và nhạy cảm với những điều huyền bí.";
                    break;
                case 8:
                    sStr = "Nhờ sức mạnh tinh thần và thể lực. Dũng cảm phi thường, năng động và nghị lực, bạn sẽ làm sáng tỏ sự thật, loại bỏ sự dối trá. Bạn sẽ thành " +
                        "công nếu dừng lại đúng lúc. Đầy lạc quan và nhiều niềm tin trong cuộc sống.";
                    break;
                case 9:
                    sStr = "Độc lập, không sợ nguy hiểm. Sẵn sàng đấu tranh. Thông minh, làm chủ bản thân. Giàu nghị lực, năng động và khôn ngoan, nhiều kinh nghiệm sống. " +
                        "Là một người quyến rũ. Tuy nhiên bạn là người không ổn định, dễ bị kích động và ít tình cảm như người ta mong đợi.";
                    break;
            }
            return "\nBạn đã nhận được lá phiếu Tử Vi " + numPoint + " : " + sStr;
        }        

        public String zodiac()
        {
            String zd = "";
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            //Aries (From 21/3 to 20/4)
            if (((tmp.moreThan(new TuVi(21, 3, this.year))) ||
                    (tmp.equal(new TuVi(21, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 4, this.year))) ||
                            (tmp.equal(new TuVi(20, 4, this.year)))))
                zd = zodiac12[0];

            //Taurus (From 21/4 to 21/5)
            if (((tmp.moreThan(new TuVi(21, 4, this.year))) ||
                    (tmp.equal(new TuVi(21, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 5, this.year))) ||
                            (tmp.equal(new TuVi(21, 5, this.year)))))
                zd = zodiac12[1];

            //Gemini (From 22/5 to 21/6)
            if (((tmp.moreThan(new TuVi(22, 5, this.year))) ||
                    (tmp.equal(new TuVi(22, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 6, this.year))) ||
                            (tmp.equal(new TuVi(21, 6, this.year)))))
                zd = zodiac12[2];

            //Cancer (From 22/6 to 23/7)
            if (((tmp.moreThan(new TuVi(22, 6, this.year))) ||
                    (tmp.equal(new TuVi(22, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 7, this.year))) ||
                            (tmp.equal(new TuVi(23, 7, this.year)))))
                zd = zodiac12[3];

            //Leo (From 24/7 to 23/8)
            if (((tmp.moreThan(new TuVi(24, 7, this.year))) ||
                    (tmp.equal(new TuVi(24, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 8, this.year))) ||
                            (tmp.equal(new TuVi(23, 8, this.year)))))
                zd = zodiac12[4];

            //Virgo (From 24/8 to 23/9)
            if (((tmp.moreThan(new TuVi(24, 8, this.year))) ||
                    (tmp.equal(new TuVi(24, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 9, this.year))) ||
                            (tmp.equal(new TuVi(23, 9, this.year)))))
                zd = zodiac12[5];

            //Libra (From 24/9 to 23/10)
            if (((tmp.moreThan(new TuVi(24, 9, this.year))) ||
                    (tmp.equal(new TuVi(24, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 10, this.year))) ||
                            (tmp.equal(new TuVi(23, 10, this.year)))))
                zd = zodiac12[6];

            //Scorpio (From 24/10 to 22/11)
            if (((tmp.moreThan(new TuVi(24, 10, this.year))) ||
                    (tmp.equal(new TuVi(24, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 11, this.year))) ||
                            (tmp.equal(new TuVi(22, 11, this.year)))))
                zd = zodiac12[7];

            //Sagittarius (From 23/11 to 21/12)
            if (((tmp.moreThan(new TuVi(23, 11, this.year))) ||
                    (tmp.equal(new TuVi(23, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 12, this.year))) ||
                            (tmp.equal(new TuVi(21, 12, this.year)))))
                zd = zodiac12[8];

            //Capricornus (From 22/12 to 20/1)
            if (((tmp.moreThan(new TuVi(22, 12, this.year))) ||
                    (tmp.equal(new TuVi(22, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(31, 12, this.year))) ||
                    (tmp.equal(new TuVi(31, 12, this.year))))
                || ((tmp.moreThan(new TuVi(1, 1, this.year))) ||
                        (tmp.equal(new TuVi(1, 1, this.year)))) &&
                        ((tmp.lessThan(new TuVi(20, 1, this.year))) ||
                        (tmp.equal(new TuVi(20, 1, this.year)))))
                zd = zodiac12[9];

            //Aquarius (From 21/1 to 19/2)
            if (((tmp.moreThan(new TuVi(21, 1, this.year))) ||
                    (tmp.equal(new TuVi(21, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(19, 2, this.year))) ||
                            (tmp.equal(new TuVi(19, 2, this.year)))))
                zd = zodiac12[10];

            //Pisces (From 20/2 to 20/3)
            if (((tmp.moreThan(new TuVi(20, 2, this.year))) ||
                    (tmp.equal(new TuVi(20, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 3, this.year))) ||
                            (tmp.equal(new TuVi(20, 3, this.year)))))
                zd = zodiac12[11];
            return zd;
        }

        public String plant()
        {
            //Declare 2 arrays type String
            String zd = "";
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            //Apple (From 23/12 to 1/1; From 24/6 to 4/7)
            if (((tmp.moreThan(new TuVi(23, 12, this.year))) ||
                    (tmp.equal(new TuVi(23, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(31, 12, this.year))) ||
                    (tmp.equal(new TuVi(31, 12, this.year))))
                || (tmp.equal(new TuVi(1, 1, this.year))) ||
                ((tmp.moreThan(new TuVi(24, 6, this.year))) ||
                        (tmp.equal(new TuVi(24, 6, this.year)))) &&
                        ((tmp.lessThan(new TuVi(4, 7, this.year))) ||
                        (tmp.equal(new TuVi(4, 7, this.year)))))
                zd = plant20[0];

            //Casuarina (From 2/1 to 11/1; From 5/7 to 14/7)
            if (((tmp.moreThan(new TuVi(2, 1, this.year))) ||
                    (tmp.equal(new TuVi(2, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(11, 1, this.year))) ||
                    (tmp.equal(new TuVi(11, 1, this.year)))) ||
                ((tmp.moreThan(new TuVi(5, 7, this.year))) ||
                    (tmp.equal(new TuVi(5, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(14, 7, this.year))) ||
                    (tmp.equal(new TuVi(14, 7, this.year)))))
                zd = plant20[1];

            //Pearl (From 12/1 to 24/1; From 15/7 to 25/7)
            if (((tmp.moreThan(new TuVi(12, 1, this.year))) ||
                    (tmp.equal(new TuVi(12, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(24, 1, this.year))) ||
                    (tmp.equal(new TuVi(24, 1, this.year)))) ||
                ((tmp.moreThan(new TuVi(15, 7, this.year))) ||
                    (tmp.equal(new TuVi(15, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(25, 7, this.year))) ||
                    (tmp.equal(new TuVi(25, 7, this.year)))))
                zd = plant20[2];

            //Xanthocyparis Vietnamensis (From 25/1 to 3/2; From 26/7 to 4/8)
            if (((tmp.moreThan(new TuVi(25, 1, this.year))) ||
                    (tmp.equal(new TuVi(25, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(3, 2, this.year))) ||
                    (tmp.equal(new TuVi(3, 2, this.year)))) ||
                ((tmp.moreThan(new TuVi(26, 7, this.year))) ||
                    (tmp.equal(new TuVi(26, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(4, 8, this.year))) ||
                    (tmp.equal(new TuVi(4, 8, this.year)))))
                zd = plant20[3];

            //Alyssum Bertolonii (From 4/2 to 8/2 ; From 1/5 to 14/5; From 5/8 to 13/8)
            if (((tmp.moreThan(new TuVi(4, 2, this.year))) ||
                    (tmp.equal(new TuVi(4, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(8, 2, this.year))) ||
                    (tmp.equal(new TuVi(8, 2, this.year)))) ||
                ((tmp.moreThan(new TuVi(1, 5, this.year))) ||
                    (tmp.equal(new TuVi(1, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(14, 5, this.year))) ||
                    (tmp.equal(new TuVi(14, 5, this.year)))) ||
                ((tmp.moreThan(new TuVi(5, 8, this.year))) ||
                    (tmp.equal(new TuVi(5, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(13, 8, this.year))) ||
                    (tmp.equal(new TuVi(13, 8, this.year)))))
                zd = plant20[4];

            //Cryptomeria Japonica (From 9/2 to 18/2; From 14/8 to 23/8)
            if (((tmp.moreThan(new TuVi(9, 2, this.year))) ||
                    (tmp.equal(new TuVi(9, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(18, 2, this.year))) ||
                    (tmp.equal(new TuVi(18, 2, this.year)))) ||
                ((tmp.moreThan(new TuVi(14, 8, this.year))) ||
                    (tmp.equal(new TuVi(14, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 8, this.year))) ||
                    (tmp.equal(new TuVi(23, 8, this.year)))))
                zd = plant20[5];

            //Pine (From 19/2 to 28(29)/2; From 24/8 to 2/9)
            if (((tmp.moreThan(new TuVi(19, 2, this.year))) ||
                    (tmp.equal(new TuVi(19, 2, this.year)))) &&
                    (isLeapYear() ? ((tmp.lessThan(new TuVi(29, 2, this.year))) ||
                    (tmp.equal(new TuVi(29, 2, this.year)))) : ((tmp.lessThan(new TuVi(28, 2, this.year))) ||
                    (tmp.equal(new TuVi(28, 2, this.year))))) ||
                ((tmp.moreThan(new TuVi(24, 8, this.year))) ||
                    (tmp.equal(new TuVi(24, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(2, 9, this.year))) ||
                    (tmp.equal(new TuVi(2, 9, this.year)))))
                zd = plant20[6];

            //Willow (From 1/3 to 10/3; From 3/9 to 12/9)
            if (((tmp.moreThan(new TuVi(1, 3, this.year))) ||
                    (tmp.equal(new TuVi(1, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(10, 3, this.year))) ||
                    (tmp.equal(new TuVi(10, 3, this.year)))) ||
                ((tmp.moreThan(new TuVi(3, 9, this.year))) ||
                    (tmp.equal(new TuVi(3, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(12, 9, this.year))) ||
                    (tmp.equal(new TuVi(12, 9, this.year)))))
                zd = plant20[7];

            //Melia Azedarach (From 11/3 to 20/3; From 13/9 to 22/9)
            if (((tmp.moreThan(new TuVi(11, 3, this.year))) ||
                    (tmp.equal(new TuVi(11, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 3, this.year))) ||
                    (tmp.equal(new TuVi(20, 3, this.year)))) ||
                ((tmp.moreThan(new TuVi(13, 9, this.year))) ||
                    (tmp.equal(new TuVi(13, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 9, this.year))) ||
                    (tmp.equal(new TuVi(22, 9, this.year)))))
                zd = plant20[8];

            //Oak (21/3)
            if (tmp.equal(new TuVi(21, 3, this.year)))
                zd = plant20[9];

            //Oleander (From 22/3 to 31/3; From 24/9 to 3/10)
            if (((tmp.moreThan(new TuVi(22, 3, this.year))) ||
                    (tmp.equal(new TuVi(22, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(31, 3, this.year))) ||
                    (tmp.equal(new TuVi(31, 3, this.year)))) ||
                ((tmp.moreThan(new TuVi(24, 9, this.year))) ||
                    (tmp.equal(new TuVi(24, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(3, 10, this.year))) ||
                    (tmp.equal(new TuVi(3, 10, this.year)))))
                zd = plant20[10];

            //Pterocarpus (From 1/4 to 10/4; From 4/10 to 13/10)
            if (((tmp.moreThan(new TuVi(1, 4, this.year))) ||
                    (tmp.equal(new TuVi(1, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(10, 4, this.year))) ||
                    (tmp.equal(new TuVi(10, 4, this.year)))) ||
                ((tmp.moreThan(new TuVi(4, 10, this.year))) ||
                    (tmp.equal(new TuVi(4, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(13, 10, this.year))) ||
                    (tmp.equal(new TuVi(13, 10, this.year)))))
                zd = plant20[11];

            //Lemon (From 12/4 to 20/4; From 14/10 to 23/10)
            if (((tmp.moreThan(new TuVi(12, 4, this.year))) ||
                    (tmp.equal(new TuVi(12, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 4, this.year))) ||
                    (tmp.equal(new TuVi(20, 4, this.year)))) ||
                ((tmp.moreThan(new TuVi(14, 10, this.year))) ||
                    (tmp.equal(new TuVi(14, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 10, this.year))) ||
                    (tmp.equal(new TuVi(23, 10, this.year)))))
                zd = plant20[12];

            //Fragaria Vesca (From 21/4 to 30/4; From 24/10 to 11/11)
            if (((tmp.moreThan(new TuVi(21, 4, this.year))) ||
                    (tmp.equal(new TuVi(21, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(30, 4, this.year))) ||
                    (tmp.equal(new TuVi(30, 4, this.year)))) ||
                ((tmp.moreThan(new TuVi(24, 10, this.year))) ||
                    (tmp.equal(new TuVi(24, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(11, 11, this.year))) ||
                    (tmp.equal(new TuVi(11, 11, this.year)))))
                zd = plant20[13];

            //Chestnut (From 15/5 to 24/5; From 12/11 to 21/11)
            if (((tmp.moreThan(new TuVi(15, 5, this.year))) ||
                    (tmp.equal(new TuVi(15, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(24, 5, this.year))) ||
                    (tmp.equal(new TuVi(24, 5, this.year)))) ||
                ((tmp.moreThan(new TuVi(12, 11, this.year))) ||
                    (tmp.equal(new TuVi(12, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 11, this.year))) ||
                    (tmp.equal(new TuVi(21, 11, this.year)))))
                zd = plant20[14];

            //Fraxinus (From 25/5 to 3/6; From 22/11 to 1/12)
            if (((tmp.moreThan(new TuVi(25, 5, this.year))) ||
                    (tmp.equal(new TuVi(25, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(3, 6, this.year))) ||
                    (tmp.equal(new TuVi(3, 6, this.year)))) ||
                ((tmp.moreThan(new TuVi(22, 11, this.year))) ||
                    (tmp.equal(new TuVi(22, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(1, 12, this.year))) ||
                    (tmp.equal(new TuVi(1, 12, this.year)))))
                zd = plant20[15];

            //Hopea Odorata (From 5/6 to 13/6; From 2/12 to 11/12)
            if (((tmp.moreThan(new TuVi(5, 6, this.year))) ||
                    (tmp.equal(new TuVi(5, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(13, 6, this.year))) ||
                    (tmp.equal(new TuVi(13, 6, this.year)))) ||
                ((tmp.moreThan(new TuVi(2, 12, this.year))) ||
                    (tmp.equal(new TuVi(2, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(11, 12, this.year))) ||
                    (tmp.equal(new TuVi(11, 12, this.year)))))
                zd = plant20[16];

            //Ficus Racemosa (From 14/6 to 23/6; From 12/12 to 21/12)
            if (((tmp.moreThan(new TuVi(14, 6, this.year))) ||
                    (tmp.equal(new TuVi(14, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 6, this.year))) ||
                    (tmp.equal(new TuVi(23, 6, this.year)))) ||
                ((tmp.moreThan(new TuVi(12, 12, this.year))) ||
                    (tmp.equal(new TuVi(12, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 12, this.year))) ||
                    (tmp.equal(new TuVi(21, 12, this.year)))))
                zd = plant20[17];

            //Elaeagnus Multiflora (23/9)
            if (tmp.equal(new TuVi(23, 9, this.year)))
                zd = plant20[18];

            //Parashorea (22/12)
            if (tmp.equal(new TuVi(22, 12, this.year)))
                zd = plant20[19];
            return zd;
        }

        public String CanChi(int dd, int mm, int yy, int leap)
        {
            String canMonth = CAN[MOD((yy * 12 + mm + 3), 10) % 10];
            String chiMonth = CHI[MOD((mm + 1), 12) % 12];
            String nhuan = leap == 1 ? " (Leap)" : "";
            return canMonth + " " + chiMonth + nhuan;
        }

        public int[][] getLunarYear(int yy)
        {
            int[][] ret = (int[][])yearCache[yy];
            if (ret == null)
            {
                ret = LunarYear(yy);
                if (yearCache.Count > 10)
                {
                    yearCache.Clear();
                }
                yearCache.Add(yy, ret);
            }
            return ret;
        }

        public void initLeapYear(int[][] ret)
        {
            double[] sunLongitudes = new double[ret.Length];
            for (int i = 0; i < ret.Length; i++)
            {
                int[] a = ret[i];
                double jdAtMonthBegin = LocalToJD(a[0], a[1], a[2]);
                sunLongitudes[i] = SunLongitude(jdAtMonthBegin);
            }
            bool found = false;
            for (int i = 0; i < ret.Length; i++)
            {
                if (found)
                {
                    ret[i][3] = MOD(i + 10, 12);
                    continue;
                }
                double sl1 = sunLongitudes[i];
                double sl2 = sunLongitudes[i + 1];
                bool hasMajorTerm = Math.Floor(sl1 / Math.PI * 6) != Math.Floor(sl2 / Math.PI * 6);
                if (!hasMajorTerm)
                {
                    found = true;
                    ret[i][4] = 1;
                    ret[i][3] = MOD(i + 10, 12);
                }
            }
        }

        public int INT(double d)
        {
            return (int)Math.Floor(d);
        }

        public int[] LocalFromJD(double JD)
        {
            return UniversalFromJD(JD + LOCAL_TIMEZONE / 24.0);
        }

        public double LocalToJD(int D, int M, int Y)
        {
            return UniversalToJD(D, M, Y) - LOCAL_TIMEZONE / 24.0;
        }

        public int[] Lunar2Solar(int D, int M, int Y, int leap)
        {
            int yy = Y;
            if (M >= 11)
            {
                yy = Y + 1;
            }
            int[][] lunarYear = getLunarYear(yy);
            int[] lunarMonth = null;
            for (int i = 0; i < lunarYear.Length; i++)
            {
                int[] lm = lunarYear[i];
                if (lm[3] == M && lm[4] == leap)
                {
                    lunarMonth = lm;
                    break;
                }
            }
            if (lunarMonth != null)
            {
                double jd = LocalToJD(lunarMonth[0], lunarMonth[1], lunarMonth[2]);
                return LocalFromJD(jd + D - 1);
            }
            else
            {
                //MessageBox.Show("Lỗi");
                return null;
            }
        }

        public int[] LunarMonth11(int Y)
        {
            double off = LocalToJD(31, 12, Y) - 2415021.076998695;
            int k = INT(off / 29.530588853);
            double jd = NewMoon(k);
            int[] ret = LocalFromJD(jd);
            double sunLong = SunLongitude(LocalToJD(ret[0], ret[1], ret[2])); // sun longitude at local midnight
            if (sunLong > 3 * Math.PI / 2)
            {
                jd = NewMoon(k - 1);
            }
            return LocalFromJD(jd);
        }

        public int[][] LunarYear(int Y)
        {
            int[][] ret = null;
            int[] month11A = LunarMonth11(Y - 1);
            double jdMonth11A = LocalToJD(month11A[0], month11A[1], month11A[2]);
            int k = (int)Math.Floor(0.5 + (jdMonth11A - 2415021.076998695) / 29.530588853);
            int[] month11B = LunarMonth11(Y);
            double off = LocalToJD(month11B[0], month11B[1], month11B[2]) - jdMonth11A;
            bool leap = off > 365.0;
            if (!leap)
            {
                ret = new int[13][];
            }
            else
            {
                ret = new int[14][];
            }
            ret[0] = new int[] { month11A[0], month11A[1], month11A[2], 0, 0 };
            ret[ret.Length - 1] = new int[] { month11B[0], month11B[1], month11B[2], 0, 0 };
            for (int i = 1; i < ret.Length - 1; i++)
            {
                double nm = NewMoon(k + i);
                int[] a = LocalFromJD(nm);
                ret[i] = new int[] { a[0], a[1], a[2], 0, 0 };
            }
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i][3] = MOD(i + 11, 12);
            }
            if (leap)
            {
                initLeapYear(ret);
            }
            return ret;
        }

        public int MOD(int x, int y)
        {
            int z = x - (int)(y * Math.Floor(((double)x / y)));
            if (z == 0)
            {
                z = y;
            }
            return z;
        }

        public double NewMoon(int k)
        {
            double T = k / 1236.85;
            double T2 = T * T;
            double T3 = T2 * T;
            double dr = Math.PI / 180;
            double Jd1 = 2415020.75933 + 29.53058868 * k + 0.0001178 * T2 - 0.000000155 * T3;
            Jd1 = Jd1 + 0.00033 * Math.Sin((166.56 + 132.87 * T - 0.009173 * T2) * dr);
            double M = 359.2242 + 29.10535608 * k - 0.0000333 * T2 - 0.00000347 * T3;
            double Mpr = 306.0253 + 385.81691806 * k + 0.0107306 * T2 + 0.00001236 * T3;
            double F = 21.2964 + 390.67050646 * k - 0.0016528 * T2 - 0.00000239 * T3;
            double C1 = (0.1734 - 0.000393 * T) * Math.Sin(M * dr) + 0.0021 * Math.Sin(2 * dr * M);
            C1 = C1 - 0.4068 * Math.Sin(Mpr * dr) + 0.0161 * Math.Sin(dr * 2 * Mpr);
            C1 = C1 - 0.0004 * Math.Sin(dr * 3 * Mpr);
            C1 = C1 + 0.0104 * Math.Sin(dr * 2 * F) - 0.0051 * Math.Sin(dr * (M + Mpr));
            C1 = C1 - 0.0074 * Math.Sin(dr * (M - Mpr)) + 0.0004 * Math.Sin(dr * (2 * F + M));
            C1 = C1 - 0.0004 * Math.Sin(dr * (2 * F - M)) - 0.0006 * Math.Sin(dr * (2 * F + Mpr));
            C1 = C1 + 0.0010 * Math.Sin(dr * (2 * F - Mpr)) + 0.0005 * Math.Sin(dr * (2 * Mpr + M));
            double deltat;
            if (T < -11)
            {
                deltat = 0.001 + 0.000839 * T + 0.0002261 * T2 - 0.00000845 * T3 - 0.000000081 * T * T3;
            }
            else
            {
                deltat = -0.000278 + 0.000265 * T + 0.000262 * T2;
            }
            double JdNew = Jd1 + C1 - deltat;
            return JdNew;
        }

        public int[] Solar2Lunar(int D, int M, int Y)
        {
            int yy = Y;
            int[][] ly = getLunarYear(Y);

            int[] month11 = ly[ly.Length - 1];
            double jdToday = LocalToJD(D, M, Y);
            double jdMonth11 = LocalToJD(month11[0], month11[1], month11[2]);
            if (jdToday >= jdMonth11)
            {
                ly = getLunarYear(Y + 1);
                yy = Y + 1;
            }
            int i = ly.Length - 1;
            while (jdToday < LocalToJD(ly[i][0], ly[i][1], ly[i][2]))
            {
                i--;
            }
            int dd = (int)(jdToday - LocalToJD(ly[i][0], ly[i][1], ly[i][2])) + 1;
            int mm = ly[i][3];
            if (mm >= 11)
            {
                yy--;
            }
            return new int[] { dd, mm, yy, ly[i][4] };
        }

        public double SunLongitude(double jdn)
        {
            double T = (jdn - 2451545.0) / 36525;
            double T2 = T * T;
            double dr = Math.PI / 180;
            double M = 357.52910 + 35999.05030 * T - 0.0001559 * T2 - 0.00000048 * T * T2;
            double L0 = 280.46645 + 36000.76983 * T + 0.0003032 * T2;
            double DL = (1.914600 - 0.004817 * T - 0.000014 * T2) * Math.Sin(dr * M);
            DL = DL + (0.019993 - 0.000101 * T) * Math.Sin(dr * 2 * M) + 0.000290 * Math.Sin(dr * 3 * M);
            double L = L0 + DL;
            L = L * dr;
            L = L - Math.PI * 2 * (INT(L / (Math.PI * 2)));
            return L;
        }

        public int[] UniversalFromJD(double JD)
        {
            int Z, A, alpha, B, C, D, E, dd, mm, yyyy;
            double F;
            Z = INT(JD + 0.5);
            F = (JD + 0.5) - Z;
            if (Z < 2299161)
            {
                A = Z;
            }
            else
            {
                alpha = INT((Z - 1867216.25) / 36524.25);
                A = Z + 1 + alpha - INT(alpha / 4);
            }
            B = A + 1524;
            C = INT((B - 122.1) / 365.25);
            D = INT(365.25 * C);
            E = INT((B - D) / 30.6001);
            dd = INT(B - D - INT(30.6001 * E) + F);
            if (E < 14)
            {
                mm = E - 1;
            }
            else
            {
                mm = E - 13;
            }
            if (mm < 3)
            {
                yyyy = C - 4715;
            }
            else
            {
                yyyy = C - 4716;
            }
            return new int[] { dd, mm, yyyy };
        }

        public double UniversalToJD(int D, int M, int Y)
        {
            double JD;
            if (Y > 1582 || (Y == 1582 && M > 10) || (Y == 1582 && M == 10 && D > 14))
            {
                JD = 367 * Y - INT(7 * (Y + INT((M + 9) / 12)) / 4) - INT(3 * (INT((Y + (M - 9) / 7) / 100) + 1) / 4) + INT(275 * M / 9) + D + 1721028.5;
            }
            else
            {
                JD = 367 * Y - INT(7 * (Y + 5001 + INT((M - 9) / 7)) / 4) + INT(275 * M / 9) + D + 1729776.5;
            }
            return JD;
        }

        public String zodiacTime()
        {
            String dayChi = dayLunar(), saveTmp = "";
            dayChi = dayChi.Substring(dayChi.LastIndexOf(" ")).Trim();

            if (dayChi.Equals("dần", StringComparison.OrdinalIgnoreCase) || dayChi.Equals("thân", StringComparison.OrdinalIgnoreCase))
                saveTmp = "Tí (23-1), Sửu (1-3), Thìn (7-9), Tỵ (9-11), Mùi (13-15), Tuất (19-21)";
            if (dayChi.Equals("mão", StringComparison.OrdinalIgnoreCase) || dayChi.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                saveTmp = "Tí (23-1), Dần (3-5), Mão (5-7), Ngọ (11-13), Mùi (13-15), Dậu (17-19)";
            if (dayChi.Equals("thìn", StringComparison.OrdinalIgnoreCase) || dayChi.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                saveTmp = "Dần (3-5), Thìn (7-9), Tỵ (9-11), Thân (15-17), Dậu (17-19), Hợi (21-23)";
            if (dayChi.Equals("tỵ", StringComparison.OrdinalIgnoreCase) || dayChi.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                saveTmp = "Sửu (1-3), Thìn (7-9), Ngọ (11-13), Mùi (13-15), Tuất (19-21), Hợi (21-23)";
            if (dayChi.Equals("tí", StringComparison.OrdinalIgnoreCase) || dayChi.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                saveTmp = "Tí (23-1), Sửu (1-3), Mão (5-7), Ngọ (11-13), Thân (15-17), Dậu (17-19)";
            if (dayChi.Equals("sửu", StringComparison.OrdinalIgnoreCase) || dayChi.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                saveTmp = "Dần (3-5), Mão (5-7), Tỵ (9-11), Thân (15-17), Tuất (19-21), Hợi (21-23)";
            return saveTmp;
        }

        public String likeAge()
        {
            String threelike = "";
            if (getAgeLunar().Equals("tí", StringComparison.OrdinalIgnoreCase))
                threelike = "Thìn, Thân";
            else if (getAgeLunar().Equals("sửu", StringComparison.OrdinalIgnoreCase))
                threelike = "Tỵ, Dậu";
            else if (getAgeLunar().Equals("dần", StringComparison.OrdinalIgnoreCase))
                threelike = "Ngọ, Tuất";
            else if (getAgeLunar().Equals("mão", StringComparison.OrdinalIgnoreCase))
                threelike = "Mùi, Hợi";
            else if (getAgeLunar().Equals("thìn", StringComparison.OrdinalIgnoreCase))
                threelike = "Tí, Thân";
            else if (getAgeLunar().Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                threelike = "Sửu, Dậu";
            else if (getAgeLunar().Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                threelike = "Dần, Tuất";
            else if (getAgeLunar().Equals("mùi", StringComparison.OrdinalIgnoreCase))
                threelike = "Mão, Hợi";
            else if (getAgeLunar().Equals("thân", StringComparison.OrdinalIgnoreCase))
                threelike = "Thìn, Tí";
            else if (getAgeLunar().Equals("dậu", StringComparison.OrdinalIgnoreCase))
                threelike = "Sửu, Tỵ";
            else if (getAgeLunar().Equals("tuất", StringComparison.OrdinalIgnoreCase))
                threelike = "Dần, Ngọ";
            else if (getAgeLunar().Equals("hợi", StringComparison.OrdinalIgnoreCase))
                threelike = "Mão, Mùi";
            return threelike;
        }

        public String dislikeAge()
        {
            String threedislike = "";
            if (getAgeLunar().Equals("tí", StringComparison.OrdinalIgnoreCase))
                threedislike = "Mão, Ngọ, Dậu";
            else if (getAgeLunar().Equals("sửu", StringComparison.OrdinalIgnoreCase))
                threedislike = "Thìn, Mùi, Tuất";
            else if (getAgeLunar().Equals("dần", StringComparison.OrdinalIgnoreCase))
                threedislike = "Tỵ, Thân, Hợi";
            else if (getAgeLunar().Equals("mão", StringComparison.OrdinalIgnoreCase))
                threedislike = "Tí, Ngọ, Dậu";
            else if (getAgeLunar().Equals("thìn", StringComparison.OrdinalIgnoreCase))
                threedislike = "Sửu, Mùi, Tuất";
            else if (getAgeLunar().Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                threedislike = "Dần, Thân, Hợi";
            else if (getAgeLunar().Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                threedislike = "Tí, Mão, Dậu";
            else if (getAgeLunar().Equals("mùi", StringComparison.OrdinalIgnoreCase))
                threedislike = "Sửu, Thìn, Tuất";
            else if (getAgeLunar().Equals("thân", StringComparison.OrdinalIgnoreCase))
                threedislike = "Dần, Tỵ, Hợi";
            else if (getAgeLunar().Equals("dậu", StringComparison.OrdinalIgnoreCase))
                threedislike = "Sửu, Tỵ";
            else if (getAgeLunar().Equals("tuất", StringComparison.OrdinalIgnoreCase))
                threedislike = "Tí, Mão, Ngọ";
            else if (getAgeLunar().Equals("hợi", StringComparison.OrdinalIgnoreCase))
                threedislike = "Dần, Thân, Tỵ";
            return threedislike;
        }

        public String firstTimeDay()
        {
            String[] firstTime = { "Giáp", "Bính", "Mậu", "Canh", "Nhâm" };
            int ifirstTime = 3;
            TuVi tmp = new TuVi(this.day, this.month, this.year);
            int numDays = getDayBetweenDate(new TuVi(1, 3, 1996));
            if (tmp.lessThan(new TuVi(1, 3, 1996)))
                ifirstTime = (ifirstTime - numDays % 5 + 5) % 5;
            else
            {
                if (tmp.moreThan(new TuVi(1, 3, 1996)))
                    ifirstTime = (ifirstTime + numDays % 5) % 5;
            }
            return firstTime[ifirstTime] + " Tý";
        }

        public String goodBadDays()
        {
            int iGBDays = 7;
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            int numDays = getDayBetweenGD(new TuVi(1, 3, 1996));
            if (tmp.lessThan(new TuVi(1, 3, 1996)))
                iGBDays = (iGBDays - numDays % 12 + 12) % 12;
            else
            {
                if (tmp.moreThan(new TuVi(1, 3, 1996)))
                    iGBDays = (iGBDays + numDays % 12) % 12;
            }
            return gbDays[iGBDays];
        }

        public String zodiacStar()
        {
            int iZodiacStar = 9;
            TuVi tmp = new TuVi(this.day, this.month, this.year);


            int numDays = getDayBetweenStar(new TuVi(1, 3, 1996));

            if (tmp.lessThan(new TuVi(1, 3, 1996)))
                iZodiacStar = (iZodiacStar - numDays % 12 + 12) % 12;
            else
            {
                if (tmp.moreThan(new TuVi(1, 3, 1996)))
                    iZodiacStar = (iZodiacStar + numDays % 12) % 12;
            }
            return zodiacStarA[iZodiacStar];
        }

        public String monthSolar()
        {
            String tmpStr = "";
            switch (this.month)
            {
                case 1:
                    tmpStr = monthSolarA[0];
                    break;
                case 2:
                    tmpStr = monthSolarA[1];
                    break;
                case 3:
                    tmpStr = monthSolarA[2];
                    break;
                case 4:
                    tmpStr = monthSolarA[3];
                    break;
                case 5:
                    tmpStr = monthSolarA[4];
                    break;
                case 6:
                    tmpStr = monthSolarA[5];
                    break;
                case 7:
                    tmpStr = monthSolarA[6];
                    break;
                case 8:
                    tmpStr = monthSolarA[7];
                    break;
                case 9:
                    tmpStr = monthSolarA[8];
                    break;
                case 10:
                    tmpStr = monthSolarA[9];
                    break;
                case 11:
                    tmpStr = monthSolarA[10];
                    break;
                case 12:
                    tmpStr = monthSolarA[11];
                    break;
            }
            return tmpStr;
        }

        public String goodStar()
        {
            int[] am;
            String tmpStr = "", dayStr = dayLunar();
            dayStr = dayStr.Substring(dayStr.LastIndexOf(" ")).Trim().ToLower();
            am = Solar2Lunar(this.day, this.month, this.year);
            switch (am[1])
            {
                case 1:
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Tam Hợp, Lộc Mã";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ, Thiên Quan, Thiên Ân";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Phúc Sinh";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    break;
                case 2:
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức, Tam Hợp";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Thiên Quí, Lộc Mã, Giải Thần";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí, Thiên Ân";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Phúc Sinh";
                    break;
                case 3:
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức, Nguyệt Đức";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Lộc Mã, Phúc Sinh, Giải Thần";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí, Thiên Quan, Thiên Ân";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    break;
                case 4:
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Lộc Mã";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ, Thiên Thành";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí, Tam Hợp";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan, Phúc Sinh";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Ân";
                    break;
                case 5:
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Thiên Hỷ, Lộc Mã";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí, Sinh Khí";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Phúc Sinh";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Ân";
                    break;
                case 6:
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức, Thiên Hỷ, Thiên Ân";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Lộc Mã";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí, Thiên Thành, Phúc Sinh";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    break;
                case 7:
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức, Nguyệt Đức, Thiên Quí";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Sinh Khí, Lộc Mã";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp, Phúc Sinh, Thiên Ân";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    break;
                case 8:
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức, Sinh Khí";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Lộc Mã";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Phúc Sinh, Thiên Ân";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    break;
                case 9:
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Lộc Mã";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ, Thiên Quí";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp, Thiên Quan";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí, Thiên Ân";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Phúc Sinh";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    break;
                case 10:
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Thiên Quí, Lộc Mã";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ, Phúc Sinh";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan, Giải Thần, Thiên Ân";
                    break;
                case 11:
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức, Nguyệt Đức";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Lộc Mã, Phúc Sinh";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ, Thiên Ân";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Thành";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan, Giải Thần";
                    break;
                case 12:
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Đức";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Đức";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Giải, Lộc Mã";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỷ";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quí";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tam Hợp, Thiên Thành";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sinh Khí";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Quan, Phúc Sinh";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Giải Thần";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Ân";
                    break;
            }
            return tmpStr;
        }

        public String badStar()
        {
            int[] am;
            String tmpStr = "", dayStr = dayLunar(), dayFStr = dayLunar();
            dayStr = dayStr.Substring(dayStr.LastIndexOf(" ")).Trim().ToLower();
            dayFStr = dayFStr.Substring(0, dayFStr.IndexOf(" ")).Trim().ToLower();
            am = Solar2Lunar(this.day, this.month, this.year);
            switch (am[1])
            {
                case 1:
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Tiểu Hao, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử, Địa Hỏa, Cô Thần";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ, Thiên Hỏa";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm";
                    if (dayStr.Equals("dần"))
                        tmpStr = "Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Quả Tú";
                    if (dayFStr.Equals("giáp", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("canh", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 2:
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú, Hỏa Tai";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tiểu Hao";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ, Thổ Kỵ, Vãng Vong, Quả Tú";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỏa";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm, Cô Thần";
                    if (dayFStr.Equals("ất", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("tân", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 3:
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Tiểu Hao, Sát Chủ";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử, Thổ Cấm";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú, Địa Hỏa, Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỏa, Quả Tú";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Cô Thần";
                    if (dayFStr.Equals("mậu", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("kỷ", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 4:
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Thổ Cấm";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú, Thiên Hỏa";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tiểu Hao, Hỏa Tai, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa, Quả Tú";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá, Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Cô Thần";
                    if (dayFStr.Equals("bính", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("nhâm", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 5:
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Tiểu Hao";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử, Thiên Hỏa";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ, Quả Tú";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai, Băng Tiêu Ngọa Giải, Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm, Cô Thần";
                    if (dayFStr.Equals("đinh", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("quý", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 6:
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử, Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tiểu Hao, Sát Chủ, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỏa, Cô Thần";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai, Quả Tú";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm";
                    if (dayFStr.Equals("kỷ", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("mậu", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 7:
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Tiểu Hao, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử, Sát Chủ";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỏa";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa, Hỏa Tai, Cô Thần";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Quả Tú";
                    if (dayFStr.Equals("canh", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("giáp", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 8:
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tiểu Hao, Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ, Quả Tú";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỏa";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm, Cô Thần";
                    if (dayFStr.Equals("tân", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("ất", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 9:
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Tiểu Hao";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử, Dia Hao, Tử Khí, Quan Phú, Địa Hỏa";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ, Cô Thần";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỏa, Quả Tú";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai, Thổ Cấm";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá, Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Băng Tiêu Ngọa Giải";
                    if (dayFStr.Equals("kỷ", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang, Trùng Phục";
                        else
                            tmpStr += ", Trùng Tang, Trùng Phục";
                    }
                    break;
                case 10:
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Thụ Tử, Thổ Cấm";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú, Thiên Hỏa";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tiểu Hao, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa, Quả Tú";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Kỵ, Vãng Vong, Cô Thần";
                    if (dayFStr.Equals("nhâm", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("bính", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 11:
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương, Thụ Tử, Tiểu Hao";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú";
                    if (dayStr.Equals("dần", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Sát Chủ, Quả Tú";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Hỏa";
                    if (dayStr.Equals("tí", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa, Hỏa Tai";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm, Cô Thần";
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Kỵ, Vãng Vong";
                    if (dayFStr.Equals("qúy", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang";
                        else
                            tmpStr += ", Trùng Tang";
                    }
                    if (dayFStr.Equals("đinh", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Phục";
                        else
                            tmpStr += ", Trùng Phục";
                    }
                    break;
                case 12:
                    if (dayStr.Equals("tuất", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thiên Cương";
                    if (dayStr.Equals("dậu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thụ Tử, Thiên Hỏa, Cô Thần";
                    if (dayStr.Equals("tỵ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Đại Hao, Tử Khí, Quan Phú";
                    if (dayStr.Equals("thìn", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Tiểu Hao, Sát Chủ, Băng Tiêu Ngọa Giải";
                    if (dayStr.Equals("hợi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Địa Hỏa";
                    if (dayStr.Equals("ngọ", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Hỏa Tai";
                    if (dayStr.Equals("mùi", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Nguyệt Phá";
                    if (dayStr.Equals("thân", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Cấm";
                    if (dayStr.Equals("sửu", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Thổ Kỵ, Vãng Vong";
                    if (dayStr.Equals("mão", StringComparison.OrdinalIgnoreCase))
                        tmpStr = "Quả Tú";
                    if (dayFStr.Equals("mậu", StringComparison.OrdinalIgnoreCase))
                    {
                        if (tmpStr.Equals(""))
                            tmpStr += "Trùng Tang, Trùng Phục";
                        else
                            tmpStr += ", Trùng Tang, Trùng Phục";
                    }
                    break;
            }
            return tmpStr;
        }

        public bool isHoliday()
        {
            bool check = false;
            if (this.day == 1 && this.month == 1) return true;
            if ((this.day == 6 && this.month == 2) || (this.day == 7 && this.month == 2)
                || (this.day == 8 && this.month == 2) || (this.day == 9 && this.month == 2))
                return true;
            if (this.day == 15 && this.month == 4) return true;
            if (this.day == 30 && this.month == 4) return true;
            if (this.day == 1 && this.month == 5) return true;
            if (this.day == 2 && this.month == 9) return true;
            return check;
        }

        public String holiday()
        {
            String hd = "";
            int[] am;
            am = Solar2Lunar(this.day, this.month, this.year);
            if (this.day == 1 && this.month == 1)
                hd += " | Năm Mới";
            if ((this.day == 6 && this.month == 2) || (this.day == 7 && this.month == 2)
                    || (this.day == 8 && this.month == 2) || (this.day == 9 && this.month == 2))
                hd += " | Tết Nguyên Đán";
            if (this.day == 15 && this.month == 4)
                hd += " | Lễ Giỗ Tổ Hùng Vương";
            if (this.day == 30 && this.month == 4)
                hd += " | Thống Nhất Đất Nước";
            if (this.day == 1 && this.month == 5)
                hd += " | Quốc Tế Lao Động";
            if (this.day == 2 && this.month == 9)
                hd += " | Quốc Khánh Việt Nam";
            if (this.day == 3 && this.month == 2)
                hd += " | Thành Lập Đảng Cộng Sản Việt Nam";
            if (this.day == 27 && this.month == 2)
                hd += " | Thầy Thuốc Việt Nam";
            if (this.day == 8 && this.month == 3)
                hd += " | Quốc Tế Phụ Nữ";
            if (this.day == 1 && this.month == 6)
                hd += " | Quốc Tế Thiếu Nhi";
            if (this.day == 27 && this.month == 7)
                hd += " | Thương Binh Liệt Sĩ";
            if (this.day == 10 && this.month == 10)
                hd += " | Giải Phóng Thủ Đô Hà Nội";
            if (this.day == 20 && this.month == 10)
                hd += " | Women in VietNam (Phu Nu Viet Nam)";
            if (this.day == 20 && this.month == 11)
                hd += " | Nhà Giáo Việt Nam";
            if (this.day == 22 && this.month == 12)
                hd += " | Thành Lập Quân Đội Nhân Dân Việt Nam";
            if (this.day == 25 && this.month == 12)
                hd += " | Lễ Giáng Sinh";
            if (this.day == 14 && this.month == 2)
                hd += " | Lễ Tình Nhân";
            if (this.day == 31 && this.month == 10)
                hd += " | Lễ Hội Ma Quỷ";
            if (this.day == 22 && this.month == 11)
                hd += " | Lễ Tạ Ơn";
            if (this.day == 12 && this.month == 11)
                hd += " | Cựu Chiến Binh";
            if (am[0] == 15 && am[1] == 1)
                hd += " | Rằm Tháng Giêng";
            if (am[0] == 14 && am[1] == 4)
                hd += " | Tết Dân Tộc Khơ-me Nam Bộ";
            if (am[0] == 15 && am[1] == 4)
                hd += " | Lễ Phật Đảng";
            if (am[0] == 5 && am[1] == 5)
                hd += " | Tết Đoan Ngọ";
            if (am[0] == 15 && am[1] == 7)
                hd += " | Rằm Tháng Bảy";
            if (am[0] == 1 && am[1] == 8)
                hd += " | Tết Kate - Dân Tộc Chăm";
            if (am[0] == 15 && am[1] == 8)
                hd += " | Tết Trung Thu";
            if (am[0] == 23 && am[1] == 12)
                hd += " | Đưa Ông Táo Về Trời";
            return hd;
        }

        public String color()
        {
            String cl = "";
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            //Red color (From 23/12 to 1/1 ; From 25/6 to 4/7)
            if (((tmp.moreThan(new TuVi(23, 12, this.year))) ||
                    (tmp.equal(new TuVi(23, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(31, 12, this.year))) ||
                    (tmp.equal(new TuVi(31, 12, this.year)))) ||
                    (tmp.equal(new TuVi(1, 1, this.year))) ||
                    ((tmp.moreThan(new TuVi(25, 6, this.year))) ||
                    (tmp.equal(new TuVi(25, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(4, 7, this.year))) ||
                    (tmp.equal(new TuVi(4, 7, this.year)))))
                cl = color20[0];

            //Orange (From 2/1 to 11/1 ; From 5/7 to 14/7)
            if (((tmp.moreThan(new TuVi(2, 1, this.year))) ||
                    (tmp.equal(new TuVi(2, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(11, 1, this.year))) ||
                    (tmp.equal(new TuVi(11, 1, this.year)))) ||
                    ((tmp.moreThan(new TuVi(5, 7, this.year))) ||
                    (tmp.equal(new TuVi(5, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(14, 7, this.year))) ||
                    (tmp.equal(new TuVi(14, 7, this.year)))))
                cl = color20[1];

            //Yellow (From 12/1 to 24/1; From 15/7 to 25/7)
            if (((tmp.moreThan(new TuVi(12, 1, this.year))) ||
                    (tmp.equal(new TuVi(12, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(24, 1, this.year))) ||
                    (tmp.equal(new TuVi(24, 1, this.year)))) ||
                    ((tmp.moreThan(new TuVi(15, 7, this.year))) ||
                    (tmp.equal(new TuVi(15, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(25, 7, this.year))) ||
                    (tmp.equal(new TuVi(25, 7, this.year)))))
                cl = color20[2];

            //Pink (From 25/1 to 3/2 ; From 26/7 to 4/8)
            if (((tmp.moreThan(new TuVi(25, 1, this.year))) ||
                    (tmp.equal(new TuVi(25, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(3, 2, this.year))) ||
                    (tmp.equal(new TuVi(3, 2, this.year)))) ||
                    ((tmp.moreThan(new TuVi(26, 7, this.year))) ||
                    (tmp.equal(new TuVi(26, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(4, 8, this.year))) ||
                    (tmp.equal(new TuVi(4, 8, this.year)))))
                cl = color20[3];

            //Navy Blue (From 4/2 to 8/2 ; From 5/8 to 13/8 ; From 3/9 to 12/9)
            if (((tmp.moreThan(new TuVi(4, 2, this.year))) ||
                    (tmp.equal(new TuVi(4, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(8, 2, this.year))) ||
                    (tmp.equal(new TuVi(8, 2, this.year)))) ||
                    ((tmp.moreThan(new TuVi(5, 8, this.year))) ||
                    (tmp.equal(new TuVi(5, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(13, 8, this.year))) ||
                    (tmp.equal(new TuVi(13, 8, this.year)))) ||
                    ((tmp.moreThan(new TuVi(3, 9, this.year))) ||
                    (tmp.equal(new TuVi(3, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(12, 9, this.year))) ||
                    (tmp.equal(new TuVi(12, 9, this.year)))))
                cl = color20[4];

            //Green (From 9/2 to 18/2 ; From 14/8 to 23/8)
            if (((tmp.moreThan(new TuVi(9, 2, this.year))) ||
                    (tmp.equal(new TuVi(9, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(18, 2, this.year))) ||
                    (tmp.equal(new TuVi(18, 2, this.year)))) ||
                    ((tmp.moreThan(new TuVi(14, 8, this.year))) ||
                    (tmp.equal(new TuVi(14, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 8, this.year))) ||
                    (tmp.equal(new TuVi(23, 8, this.year)))))
                cl = color20[5];

            //Brown (From 19/2 to 28(29)/2 ; From 24/8 to 2/9)
            if (((tmp.moreThan(new TuVi(19, 2, this.year))) ||
                    (tmp.equal(new TuVi(19, 2, this.year)))) &&
                    (isLeapYear() ? ((tmp.lessThan(new TuVi(29, 2, this.year))) ||
                    (tmp.equal(new TuVi(29, 2, this.year)))) : ((tmp.lessThan(new TuVi(28, 2, this.year))) ||
                    (tmp.equal(new TuVi(28, 2, this.year))))) ||
                ((tmp.moreThan(new TuVi(24, 8, this.year))) ||
                    (tmp.equal(new TuVi(24, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(2, 9, this.year))) ||
                    (tmp.equal(new TuVi(2, 9, this.year)))))
                cl = color20[6];

            //Dark Green-Blue (From 1/3 to 10/3 ; 22/12)
            if (((tmp.moreThan(new TuVi(1, 3, this.year))) ||
                    (tmp.equal(new TuVi(1, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(10, 3, this.year))) ||
                    (tmp.equal(new TuVi(10, 3, this.year)))) ||
                    (tmp.equal(new TuVi(22, 12, this.year))))
                cl = color20[7];

            //Green-Yellow / Lemon-Yellow (From 11/3 to 20/3 ; From 13/9 to 22/9)
            if (((tmp.moreThan(new TuVi(11, 3, this.year))) ||
                    (tmp.equal(new TuVi(11, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 3, this.year))) ||
                    (tmp.equal(new TuVi(20, 3, this.year)))) ||
                    ((tmp.moreThan(new TuVi(13, 9, this.year))) ||
                    (tmp.equal(new TuVi(13, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 9, this.year))) ||
                    (tmp.equal(new TuVi(22, 9, this.year)))))
                cl = color20[8];

            //Black (21/3)
            if ((tmp.equal(new TuVi(21, 3, this.year))))
                cl = color20[9];

            //Violet (From 22/3 to 31/3 ; From 24/9 to 3/10)
            if (((tmp.moreThan(new TuVi(22, 3, this.year))) ||
                    (tmp.equal(new TuVi(22, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(31, 3, this.year))) ||
                    (tmp.equal(new TuVi(31, 3, this.year)))) ||
                    ((tmp.moreThan(new TuVi(24, 9, this.year))) ||
                    (tmp.equal(new TuVi(24, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(3, 10, this.year))) ||
                    (tmp.equal(new TuVi(3, 10, this.year)))))
                cl = color20[10];

            //Seaman-Green (From 1/4 to 10/4 ; From 4/10 to 13/10)
            if (((tmp.moreThan(new TuVi(1, 4, this.year))) ||
                    (tmp.equal(new TuVi(1, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(10, 4, this.year))) ||
                    (tmp.equal(new TuVi(10, 4, this.year)))) ||
                    ((tmp.moreThan(new TuVi(4, 10, this.year))) ||
                    (tmp.equal(new TuVi(4, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(13, 10, this.year))) ||
                    (tmp.equal(new TuVi(13, 10, this.year)))))
                cl = color20[11];

            //Silver (From 11/4 to 20/4 ; From 14/10 to 23/10)
            if (((tmp.moreThan(new TuVi(11, 4, this.year))) ||
                    (tmp.equal(new TuVi(11, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 4, this.year))) ||
                    (tmp.equal(new TuVi(20, 4, this.year)))) ||
                    ((tmp.moreThan(new TuVi(14, 10, this.year))) ||
                    (tmp.equal(new TuVi(14, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 10, this.year))) ||
                    (tmp.equal(new TuVi(23, 10, this.year)))))
                cl = color20[12];

            //White (From 21/4 to 30/4 ; From 24/10 to 11/11)
            if (((tmp.moreThan(new TuVi(21, 4, this.year))) ||
                    (tmp.equal(new TuVi(21, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(30, 4, this.year))) ||
                    (tmp.equal(new TuVi(30, 4, this.year)))) ||
                    ((tmp.moreThan(new TuVi(24, 10, this.year))) ||
                    (tmp.equal(new TuVi(24, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(11, 11, this.year))) ||
                    (tmp.equal(new TuVi(11, 11, this.year)))))
                cl = color20[13];

            //Sky-Blue (From 1/5 to 14/5)
            if (((tmp.moreThan(new TuVi(1, 5, this.year))) ||
                    (tmp.equal(new TuVi(1, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(14, 5, this.year))) ||
                    (tmp.equal(new TuVi(14, 5, this.year)))))
                cl = color20[14];

            //Gild (From 15/5 to 24/5 ; From 12/11 to 21/11)
            if (((tmp.moreThan(new TuVi(15, 5, this.year))) ||
                    (tmp.equal(new TuVi(15, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(24, 5, this.year))) ||
                    (tmp.equal(new TuVi(24, 5, this.year)))) ||
                    ((tmp.moreThan(new TuVi(12, 11, this.year))) ||
                    (tmp.equal(new TuVi(12, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 11, this.year))) ||
                    (tmp.equal(new TuVi(21, 11, this.year)))))
                cl = color20[15];

            //Cream (From 25/5 to 3/6 ; From 22/11 to 1/12)
            if (((tmp.moreThan(new TuVi(25, 5, this.year))) ||
                    (tmp.equal(new TuVi(25, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(3, 6, this.year))) ||
                    (tmp.equal(new TuVi(3, 6, this.year)))) ||
                    ((tmp.moreThan(new TuVi(22, 11, this.year))) ||
                    (tmp.equal(new TuVi(22, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(1, 12, this.year))) ||
                    (tmp.equal(new TuVi(1, 12, this.year)))))
                cl = color20[16];

            //Grey (From 4/6 to 13/6 ; 24/6 ; From 2/12 to 11/12)
            if (((tmp.moreThan(new TuVi(4, 6, this.year))) ||
                    (tmp.equal(new TuVi(4, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(13, 6, this.year))) ||
                    (tmp.equal(new TuVi(13, 6, this.year)))) ||
                    (tmp.equal(new TuVi(24, 6, this.year))) ||
                    ((tmp.moreThan(new TuVi(2, 12, this.year))) ||
                    (tmp.equal(new TuVi(2, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(11, 12, this.year))) ||
                    (tmp.equal(new TuVi(11, 12, this.year)))))
                cl = color20[17];

            //Dark-Brown (From 14/6 to 23/6 ; From 12/12 to 21/12)
            if (((tmp.moreThan(new TuVi(14, 6, this.year))) ||
                    (tmp.equal(new TuVi(14, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 6, this.year))) ||
                    (tmp.equal(new TuVi(23, 6, this.year)))) ||
                    ((tmp.moreThan(new TuVi(12, 12, this.year))) ||
                    (tmp.equal(new TuVi(12, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 12, this.year))) ||
                    (tmp.equal(new TuVi(21, 12, this.year)))))
                cl = color20[18];

            //Oliu-Green (23/9)
            if ((tmp.equal(new TuVi(23, 9, this.year))))
                cl = color20[19];
            return cl;
        }

        public String dayZodiacGood()
        {
            String dG = "";
            if (getMonthLunar() == 1 || getMonthLunar() == 7)
                dG = "Tỵ, Sửu, Tí, Mùi";
            if (getMonthLunar() == 2 || getMonthLunar() == 8)
                dG = "Dần, Mão, Mùi, Dậu";
            if (getMonthLunar() == 3 || getMonthLunar() == 9)
                dG = "Thìn, Tỵ, Dậu, Hợi";
            if (getMonthLunar() == 4 || getMonthLunar() == 10)
                dG = "Ngọ, Mùi, Sưu, Dậu";
            if (getMonthLunar() == 5 || getMonthLunar() == 11)
                dG = "Thân, Dậu, Sửu, Mão";
            if (getMonthLunar() == 6 || getMonthLunar() == 12)
                dG = "Tuất, Hợi, Mão, Tỵ";
            return dG;
        }

        public String dayZodiacBad()
        {
            String dB = "";
            if (getMonthLunar() == 1 || getMonthLunar() == 7)
                dB = "Ngọ, Mão, Hợi, Dậu";
            if (getMonthLunar() == 2 || getMonthLunar() == 8)
                dB = "Thân, Tỵ, Sửu, Hợi";
            if (getMonthLunar() == 3 || getMonthLunar() == 9)
                dB = "Tuất, Mùi, Sửu, Hợi";
            if (getMonthLunar() == 4 || getMonthLunar() == 10)
                dB = "Tí, Dậu, Tỵ, Mão";
            if (getMonthLunar() == 5 || getMonthLunar() == 11)
                dB = "Dần, Hợi, Mùi, Tỵ";
            if (getMonthLunar() == 6 || getMonthLunar() == 12)
                dB = "Thìn, Sửu, Dậu, Mùi";
            return dB;
        }

        public String daySolarVietNam()
        {
            int idaySolar = 5;
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            int numDays = getDayBetweenDate(new TuVi(1, 3, 1996));

            if (tmp.lessThan(new TuVi(1, 3, 1996)))
                idaySolar = (idaySolar - numDays % 7 + 7) % 7;
            else
            {
                if (tmp.moreThan(new TuVi(1, 3, 1996)))
                    idaySolar = (idaySolar + numDays % 7) % 7;
            }
            return daySolarVietNamA[idaySolar];
        }

        public String monthSolarVietNam()
        {
            String tmpStr = "";
            switch (this.month)
            {
                case 1:
                    tmpStr = monthSolarVietNamA[0];
                    break;
                case 2:
                    tmpStr = monthSolarVietNamA[1];
                    break;
                case 3:
                    tmpStr = monthSolarVietNamA[2];
                    break;
                case 4:
                    tmpStr = monthSolarVietNamA[3];
                    break;
                case 5:
                    tmpStr = monthSolarVietNamA[4];
                    break;
                case 6:
                    tmpStr = monthSolarVietNamA[5];
                    break;
                case 7:
                    tmpStr = monthSolarVietNamA[6];
                    break;
                case 8:
                    tmpStr = monthSolarVietNamA[7];
                    break;
                case 9:
                    tmpStr = monthSolarVietNamA[8];
                    break;
                case 10:
                    tmpStr = monthSolarVietNamA[9];
                    break;
                case 11:
                    tmpStr = monthSolarVietNamA[10];
                    break;
                case 12:
                    tmpStr = monthSolarVietNamA[11];
                    break;
            }
            return tmpStr;
        }

        public String AMPM()
        {
            String ampm = "";
            int totaltime;

            if ((this.hour == -1 || this.minute == -1) && this.second == -1)
            {
                //MessageBox.Show("Giờ không hợp lệ");
            }

            if (this.second == -1)
            {
                totaltime = this.hour * 60 + this.minute;
                if (totaltime <= 720)
                    ampm = "AM";
                else
                    ampm = "PM";
            }
            else
            {
                totaltime = (this.hour * 60 + this.minute) * 60 + this.second;
                if (totaltime <= 43200)
                    ampm = "AM";
                else
                    ampm = "PM";
            }
            return ampm;
        }

        public bool isAM()
        {
            return AMPM().Equals("am", StringComparison.OrdinalIgnoreCase);
        }

        public String convertSecond(double nSecond)
        {
            double cHour, cMinute, cSecond, cDay, cWeek, cMonth,
                    cYear, cDecade, cCentury;
            String Ch = "";
            if (nSecond < 0)
            {
                //MessageBox.Show("Nhập số giây không hợp lệ");
            }
            cCentury = Math.Floor(nSecond / 2903040000D);
            cDecade = Math.Floor(nSecond / 290304000) % 10;
            cYear = (Math.Floor(nSecond / 29030400)) % 10;
            cMonth = (Math.Floor(nSecond / 2419200)) % 12;
            cWeek = (Math.Floor(nSecond / 604800)) % 4;
            cDay = (Math.Floor(nSecond / 86400)) % 7;
            cHour = (Math.Floor(nSecond / 3600)) % 24;
            cSecond = nSecond % 3600;
            cMinute = (Math.Floor(cSecond / 60));
            cSecond %= 60;

            Ch = (!(cCentury == 0) ? (long)cCentury + " thế kỷ " : "") + (!(cDecade == 0) ? (long)cDecade + " thập kỷ " : "")
            + (!(cYear == 0) ? (long)cYear + " năm " : "") + (!(cMonth == 0) ? (long)cMonth + " tháng " : "")
            + (!(cWeek == 0) ? (long)cWeek + " tuần " : "") + (!(cDay == 0) ? (long)cDay + " ngày " : "")
            + (!(cHour == 0) ? (long)cHour + " giờ " : "") + (!(cMinute == 0) ? (long)cMinute + " phút " : "")
            + (!(cSecond == 0) ? (long)cSecond + " giây" : "");

            return (long)nSecond + "s = " + Ch;
        }

        public String convertDay(double nDay)
        {
            double cYear, cMonth, cWeek, cHour, cMinute, cSecond;
            String Ch = "";
            if (nDay < 0)
            {
                //MessageBox.Show("Nhập ngày không hợp lệ");
            }

            cYear = Math.Floor(nDay / 365);
            cMonth = Math.Floor((nDay / 365) * 12);
            cWeek = Math.Floor(nDay / 7);
            cHour = Math.Round((nDay / 7d) * 168);
            cMinute = cHour * 60;
            cSecond = cMinute * 60;

            Ch = (!(cYear == 0) ? (long)cYear + " năm " : "") + (!(cMonth == 0) ? (long)cMonth + " tháng " : "")
            + (!(cWeek == 0) ? (long)cWeek + " tuần " : "") + (!(cHour == 0) ? (long)cHour + " giờ " : "")
            + (!(cMinute == 0) ? (long)cMinute + " phút " : "") + (!(cSecond == 0) ? (long)cSecond + " giây" : "");

            return Ch;
        }

        public long ticket(long ticket)
        {
            long sum, tmp;

            sum = ticket;

            while (sum > 27)
            {
                tmp = sum;
                sum = 0;

                while (tmp > 0)
                {
                    sum += tmp % 10;
                    tmp /= 10;
                }
            }
            return sum;
        }

        public long phone(long yourPhone, long herPhone)
        {
            long nPhone1, nPhone2, resultA, resultB, sumA = 0, sumB = 0,
                tmp = 0, finalResult = 0;

            nPhone1 = Math.Max(yourPhone, herPhone);
            nPhone2 = Math.Min(yourPhone, herPhone);

            resultA = nPhone1 + nPhone2;
            resultB = nPhone1 - nPhone2;

            while (resultA > 0)
            {
                sumA += resultA % 10;
                resultA /= 10;
            }

            while (resultB > 0)
            {
                sumB += resultB % 10;
                resultB /= 10;
            }

            sumA = long.Parse(sumA.ToString().Substring(0, 1));
            sumB = long.Parse(sumB.ToString().Substring(0, 1));

            finalResult = sumA + sumB;
            while (finalResult >= 10)
            {
                tmp = finalResult;
                finalResult = 0;
                while (tmp > 0)
                {
                    finalResult += tmp % 10;
                    tmp /= 10;
                }
            }
            return finalResult;
        }
       

        public int birthday()
        {
            int sum, tmpNum;
            TuVi hTmp = new TuVi();
            sum = this.day + this.month + this.year + hTmp.year;

            while (sum >= 10)
            {
                tmpNum = sum;
                sum = 0;
                while (tmpNum > 0)
                {
                    sum += tmpNum % 10;
                    tmpNum /= 10;
                }
            }
            return sum;
        }

        public String animal()
        {
            String anl = "";
            TuVi tmp = new TuVi(this.day, this.month, this.year);

            //Goose (From 22/12 to 20/1)
            if (((tmp.moreThan(new TuVi(22, 12, this.year))) ||
                    (tmp.equal(new TuVi(22, 12, this.year)))) &&
                    ((tmp.lessThan(new TuVi(31, 12, this.year))) ||
                    (tmp.equal(new TuVi(31, 12, this.year)))) ||
                    ((tmp.moreThan(new TuVi(1, 1, this.year))) ||
                    (tmp.equal(new TuVi(1, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 1, this.year))) ||
                    (tmp.equal(new TuVi(20, 1, this.year)))))
                anl = animal12[0];

            //Otter (From 21/1 to 18/2)
            if (((tmp.moreThan(new TuVi(21, 1, this.year))) ||
                    (tmp.equal(new TuVi(21, 1, this.year)))) &&
                    ((tmp.lessThan(new TuVi(18, 2, this.year))) ||
                            (tmp.equal(new TuVi(18, 2, this.year)))))
                anl = animal12[1];

            //Panther (From 19/2 to 20/3)
            if (((tmp.moreThan(new TuVi(19, 2, this.year))) ||
                    (tmp.equal(new TuVi(19, 2, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 3, this.year))) ||
                            (tmp.equal(new TuVi(20, 3, this.year)))))
                anl = animal12[2];

            //Salmon (From 21/3 to 19/4)
            if (((tmp.moreThan(new TuVi(21, 3, this.year))) ||
                    (tmp.equal(new TuVi(21, 3, this.year)))) &&
                    ((tmp.lessThan(new TuVi(19, 4, this.year))) ||
                            (tmp.equal(new TuVi(19, 4, this.year)))))
                anl = animal12[3];

            //Beaver (From 20/4 to 20/5)
            if (((tmp.moreThan(new TuVi(20, 4, this.year))) ||
                    (tmp.equal(new TuVi(20, 4, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 5, this.year))) ||
                            (tmp.equal(new TuVi(20, 5, this.year)))))
                anl = animal12[4];

            //Stag (From 21/5 to 20/6)
            if (((tmp.moreThan(new TuVi(21, 5, this.year))) ||
                    (tmp.equal(new TuVi(21, 5, this.year)))) &&
                    ((tmp.lessThan(new TuVi(20, 6, this.year))) ||
                            (tmp.equal(new TuVi(20, 6, this.year)))))
                anl = animal12[5];

            //Woodpecker (From 21/6 to 22/7)
            if (((tmp.moreThan(new TuVi(21, 6, this.year))) ||
                    (tmp.equal(new TuVi(21, 6, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 7, this.year))) ||
                            (tmp.equal(new TuVi(22, 7, this.year)))))
                anl = animal12[6];

            //Hawk (From 23/7 to 22/8)
            if (((tmp.moreThan(new TuVi(23, 7, this.year))) ||
                    (tmp.equal(new TuVi(23, 7, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 8, this.year))) ||
                            (tmp.equal(new TuVi(22, 8, this.year)))))
                anl = animal12[7];

            //Bear (From 23/8 to 22/9)
            if (((tmp.moreThan(new TuVi(23, 8, this.year))) ||
                    (tmp.equal(new TuVi(23, 8, this.year)))) &&
                    ((tmp.lessThan(new TuVi(22, 9, this.year))) ||
                            (tmp.equal(new TuVi(22, 9, this.year)))))
                anl = animal12[8];

            //Corvus (From 23/9 to 23/10)
            if (((tmp.moreThan(new TuVi(23, 9, this.year))) ||
                    (tmp.equal(new TuVi(23, 9, this.year)))) &&
                    ((tmp.lessThan(new TuVi(23, 10, this.year))) ||
                            (tmp.equal(new TuVi(23, 10, this.year)))))
                anl = animal12[9];

            //Snake (From 24/10 to 21/11)
            if (((tmp.moreThan(new TuVi(24, 10, this.year))) ||
                    (tmp.equal(new TuVi(24, 10, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 11, this.year))) ||
                            (tmp.equal(new TuVi(21, 11, this.year)))))
                anl = animal12[10];

            //Deer (From 22/11 to 21/12)
            if (((tmp.moreThan(new TuVi(22, 11, this.year))) ||
                    (tmp.equal(new TuVi(22, 11, this.year)))) &&
                    ((tmp.lessThan(new TuVi(21, 12, this.year))) ||
                            (tmp.equal(new TuVi(21, 12, this.year)))))
                anl = animal12[11];
            return anl;
        }

        //public String starWorship()
        //{
        //    int age = getAge();
        //    String sMW = "";
        //    if (!getGender().Equals(""))
        //    {
        //        if (this.gender == 0) //If you are man
        //        {
        //            if (age == 23 || age == 32 || age == 41 || age == 50 || age == 59 || age == 68)
        //                sMW = "Thái Dương";
        //            if (age == 17 || age == 26 || age == 35 || age == 44 || age == 53 || age == 62 || age == 71)
        //                sMW = "Thái Âm";
        //            if (age == 18 || age == 27 || age == 36 || age == 45 || age == 54 || age == 63 || age == 72)
        //                sMW = "Mộc Đức";
        //            if (age == 24 || age == 33 || age == 42 || age == 51 || age == 60 || age == 69)
        //                sMW = "Vân Hớn";
        //            if (age == 20 || age == 29 || age == 38 || age == 47 || age == 56 || age == 65 || age == 74)
        //                sMW = "Thổ Tú";
        //            if (age == 21 || age == 30 || age == 39 || age == 48 || age == 57 || age == 66 || age == 75)
        //                sMW = "Thủy Diệu";
        //            if (age == 22 || age == 31 || age == 40 || age == 49 || age == 58 || age == 67 || age == 78)
        //                sMW = "Thái Bạch";
        //            if (age == 19 || age == 28 || age == 37 || age == 46 || age == 55 || age == 64 || age == 73)
        //                sMW = "La Hầu";
        //            if (age == 25 || age == 34 || age == 43 || age == 52 || age == 61 || age == 70)
        //                sMW = "Kế Đô";
        //        }
        //        else //If you are woman
        //        {
        //            if (age == 26 || age == 25 || age == 34 || age == 43 || age == 52 || age == 61 || age == 70)
        //                sMW = "Thái Dương";
        //            if (age == 13 || age == 22 || age == 31 || age == 40 || age == 49 || age == 58 || age == 76)
        //                sMW = "Thái Âm";
        //            if (age == 21 || age == 30 || age == 39 || age == 48 || age == 57 || age == 66 || age == 75)
        //                sMW = "Mộc Đức";
        //            if (age == 20 || age == 29 || age == 38 || age == 47 || age == 56 || age == 65 || age == 74)
        //                sMW = "Vân Hớn";
        //            if (age == 14 || age == 23 || age == 32 || age == 41 || age == 50 || age == 59 || age == 68 || age == 77)
        //                sMW = "Thổ Tú";
        //            if (age == 18 || age == 27 || age == 36 || age == 45 || age == 54 || age == 63 || age == 72)
        //                sMW = "Thủy Diệu";
        //            if (age == 17 || age == 26 || age == 35 || age == 44 || age == 53 || age == 62 || age == 71)
        //                sMW = "Thái Bạch";
        //            if (age == 15 || age == 24 || age == 33 || age == 42 || age == 51 || age == 60 || age == 69)
        //                sMW = "La Hầu";
        //            if (age == 19 || age == 28 || age == 37 || age == 46 || age == 55 || age == 64 || age == 73)
        //                sMW = "Kế Đô";
        //        }
        //    }
        //    else
        //        //MessageBox.Show("Chọn Giới tính trước khi dùng chức năng này");
        //    return sMW;
        //}

        public String convertQuantity(int quantity)
        {
            return (quantity / 10) + " lượng " + (quantity % 10 == 0 ? "" : (quantity % 10) + " chỉ");
        }

        public int weightOfYear()
        {
            int wOY = 0;
            if (yearLunar().Equals(yearOf60[0], StringComparison.OrdinalIgnoreCase))
                wOY = 12;
            if (yearLunar().Equals(yearOf60[1], StringComparison.OrdinalIgnoreCase))
                wOY = 2;
            if (yearLunar().Equals(yearOf60[2], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[3], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            if (yearLunar().Equals(yearOf60[4], StringComparison.OrdinalIgnoreCase))
                wOY = 12;
            if (yearLunar().Equals(yearOf60[5], StringComparison.OrdinalIgnoreCase))
                wOY = 5;
            if (yearLunar().Equals(yearOf60[6], StringComparison.OrdinalIgnoreCase))
                wOY = 9;
            if (yearLunar().Equals(yearOf60[7], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[8], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            if (yearLunar().Equals(yearOf60[9], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[10], StringComparison.OrdinalIgnoreCase))
                wOY = 5;
            if (yearLunar().Equals(yearOf60[11], StringComparison.OrdinalIgnoreCase))
                wOY = 9;
            if (yearLunar().Equals(yearOf60[12], StringComparison.OrdinalIgnoreCase))
                wOY = 16;
            if (yearLunar().Equals(yearOf60[13], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[14], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[15], StringComparison.OrdinalIgnoreCase))
                wOY = 19;
            if (yearLunar().Equals(yearOf60[16], StringComparison.OrdinalIgnoreCase))
                wOY = 12;
            if (yearLunar().Equals(yearOf60[17], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[18], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[19], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            if (yearLunar().Equals(yearOf60[20], StringComparison.OrdinalIgnoreCase))
                wOY = 5;
            if (yearLunar().Equals(yearOf60[21], StringComparison.OrdinalIgnoreCase))
                wOY = 15;
            if (yearLunar().Equals(yearOf60[22], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[23], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[24], StringComparison.OrdinalIgnoreCase))
                wOY = 15;
            if (yearLunar().Equals(yearOf60[25], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[26], StringComparison.OrdinalIgnoreCase))
                wOY = 9;
            if (yearLunar().Equals(yearOf60[27], StringComparison.OrdinalIgnoreCase))
                wOY = 12;
            if (yearLunar().Equals(yearOf60[28], StringComparison.OrdinalIgnoreCase))
                wOY = 10;
            if (yearLunar().Equals(yearOf60[29], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            if (yearLunar().Equals(yearOf60[30], StringComparison.OrdinalIgnoreCase))
                wOY = 15;
            if (yearLunar().Equals(yearOf60[31], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[32], StringComparison.OrdinalIgnoreCase))
                wOY = 5;
            if (yearLunar().Equals(yearOf60[33], StringComparison.OrdinalIgnoreCase))
                wOY = 14;
            if (yearLunar().Equals(yearOf60[34], StringComparison.OrdinalIgnoreCase))
                wOY = 14;
            if (yearLunar().Equals(yearOf60[35], StringComparison.OrdinalIgnoreCase))
                wOY = 9;
            if (yearLunar().Equals(yearOf60[36], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            if (yearLunar().Equals(yearOf60[37], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            if (yearLunar().Equals(yearOf60[38], StringComparison.OrdinalIgnoreCase))
                wOY = 9;
            if (yearLunar().Equals(yearOf60[39], StringComparison.OrdinalIgnoreCase))
                wOY = 12;
            if (yearLunar().Equals(yearOf60[40], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[41], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            if (yearLunar().Equals(yearOf60[42], StringComparison.OrdinalIgnoreCase))
                wOY = 13;
            if (yearLunar().Equals(yearOf60[43], StringComparison.OrdinalIgnoreCase))
                wOY = 5;
            if (yearLunar().Equals(yearOf60[44], StringComparison.OrdinalIgnoreCase))
                wOY = 14;
            if (yearLunar().Equals(yearOf60[45], StringComparison.OrdinalIgnoreCase))
                wOY = 5;
            if (yearLunar().Equals(yearOf60[46], StringComparison.OrdinalIgnoreCase))
                wOY = 9;
            if (yearLunar().Equals(yearOf60[47], StringComparison.OrdinalIgnoreCase))
                wOY = 17;
            if (yearLunar().Equals(yearOf60[48], StringComparison.OrdinalIgnoreCase))
                wOY = 5;
            if (yearLunar().Equals(yearOf60[49], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[50], StringComparison.OrdinalIgnoreCase))
                wOY = 12;
            if (yearLunar().Equals(yearOf60[51], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[52], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[53], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[54], StringComparison.OrdinalIgnoreCase))
                wOY = 16;
            if (yearLunar().Equals(yearOf60[55], StringComparison.OrdinalIgnoreCase))
                wOY = 6;
            if (yearLunar().Equals(yearOf60[56], StringComparison.OrdinalIgnoreCase))
                wOY = 8;
            if (yearLunar().Equals(yearOf60[57], StringComparison.OrdinalIgnoreCase))
                wOY = 16;
            if (yearLunar().Equals(yearOf60[58], StringComparison.OrdinalIgnoreCase))
                wOY = 10;
            if (yearLunar().Equals(yearOf60[59], StringComparison.OrdinalIgnoreCase))
                wOY = 7;
            return wOY;
        }

        public int weightOfMonth()
        {
            int[] am;
            int wOM = 0;
            am = Solar2Lunar(this.day, this.month, this.year);
            if (am[1] == 1)
                wOM = 6;
            if (am[1] == 2)
                wOM = 7;
            if (am[1] == 3)
                wOM = 18;
            if (am[1] == 4)
                wOM = 9;
            if (am[1] == 5)
                wOM = 5;
            if (am[1] == 6)
                wOM = 16;
            if (am[1] == 7)
                wOM = 9;
            if (am[1] == 8)
                wOM = 15;
            if (am[1] == 9)
                wOM = 18;
            if (am[1] == 10)
                wOM = 8;
            if (am[1] == 11)
                wOM = 9;
            if (am[1] == 12)
                wOM = 6;
            return wOM;
        }

        public int weightOfDay()
        {
            int[] am;
            int wOD = 0;
            am = Solar2Lunar(this.day, this.month, this.year);
            if (am[0] == 1)
                wOD = 5;
            if (am[0] == 2)
                wOD = 10;
            if (am[0] == 3)
                wOD = 8;
            if (am[0] == 4)
                wOD = 15;
            if (am[0] == 5)
                wOD = 16;
            if (am[0] == 6)
                wOD = 15;
            if (am[0] == 7)
                wOD = 8;
            if (am[0] == 8)
                wOD = 16;
            if (am[0] == 9)
                wOD = 6;
            if (am[0] == 10)
                wOD = 16;
            if (am[0] == 11)
                wOD = 9;
            if (am[0] == 12)
                wOD = 17;
            if (am[0] == 13)
                wOD = 8;
            if (am[0] == 14)
                wOD = 17;
            if (am[0] == 15)
                wOD = 10;
            if (am[0] == 16)
                wOD = 8;
            if (am[0] == 17)
                wOD = 9;
            if (am[0] == 18)
                wOD = 18;
            if (am[0] == 19)
                wOD = 5;
            if (am[0] == 20)
                wOD = 15;
            if (am[0] == 21)
                wOD = 10;
            if (am[0] == 22)
                wOD = 9;
            if (am[0] == 23)
                wOD = 8;
            if (am[0] == 24)
                wOD = 9;
            if (am[0] == 25)
                wOD = 15;
            if (am[0] == 26)
                wOD = 18;
            if (am[0] == 27)
                wOD = 7;
            if (am[0] == 28)
                wOD = 8;
            if (am[0] == 29)
                wOD = 16;
            if (am[0] == 30)
                wOD = 6;
            return wOD;
        }

        public int weightOfTime()
        {
            int wOT = 0;
            if (orientTime().Equals(CHI[0], StringComparison.OrdinalIgnoreCase))
                wOT = 16;
            if (orientTime().Equals(CHI[1], StringComparison.OrdinalIgnoreCase))
                wOT = 6;
            if (orientTime().Equals(CHI[2], StringComparison.OrdinalIgnoreCase))
                wOT = 7;
            if (orientTime().Equals(CHI[3], StringComparison.OrdinalIgnoreCase))
                wOT = 10;
            if (orientTime().Equals(CHI[4], StringComparison.OrdinalIgnoreCase))
                wOT = 9;
            if (orientTime().Equals(CHI[5], StringComparison.OrdinalIgnoreCase))
                wOT = 16;
            if (orientTime().Equals(CHI[6], StringComparison.OrdinalIgnoreCase))
                wOT = 10;
            if (orientTime().Equals(CHI[7], StringComparison.OrdinalIgnoreCase))
                wOT = 8;
            if (orientTime().Equals(CHI[8], StringComparison.OrdinalIgnoreCase))
                wOT = 8;
            if (orientTime().Equals(CHI[9], StringComparison.OrdinalIgnoreCase))
                wOT = 9;
            if (orientTime().Equals(CHI[10]))
                wOT = 6;
            if (orientTime().Equals(CHI[11]))
                wOT = 6;
            return wOT;
        }

        public int weightOfPerson()
        {
            return weightOfYear() + weightOfMonth() + weightOfDay() + weightOfTime();
        }
    }
}
