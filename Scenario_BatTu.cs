using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SDKTemplate
{
    public sealed partial class Scenario_BatTu : Page
    {
        public Scenario_BatTu()
        {
            this.InitializeComponent();
        }
        TuVi tv = new TuVi();
        String[] Kham = { "1,2,7", "3,4,3", "4,5,11", "6,7,3", "2,1,7", "8,6,10", "7,8,3", "5,9,6" };
        String[] Khon = { "8,8,10", "7,6 ,3", "2,9,9", "5,1 ,13", "4,7,12", "1 ,4,11", "9,2,9", "6 ,5,7 " };
        String[] Chan = { "4,7,12", "6,5,7", "1 ,4,11", "9,2,9", "8,8,10", "2,9,9", "5,1 ,11", "7,6,13" };
        String[] Ton = { "5,1,2", "2,9,9 ", "7,6,13", "8,8,10 ", "9,2,9 ", "6,5,7 ", "4,7,12", "1,4,11" };
        String[] Trung = { "8,5,7", "7,7,12", "2,2,10", "5,4,11", "4,6,6", "1,1,2", "9,9,7", "6,8,10" };
        String[] _Can = { "9,6,9", "1,8,8", "6,1,8", "4,9,5", "5,5,2", "7,2,4", "8,4,7 ", "2,7,5" };
        String[] Doai = { "2,4,7", "5,2,6", "8,7,4", "7,5,12", "1,9,5", "4,8,6", "6,6 ,10", "9,1,6" };
        String[] __Can = { "6,5,6", "4,7,12", "9,2,9", "1,4,11", "7,6,4", "5,1,1", "2,9,9", "8,8,10" };
        String[] Ly = { "7,9,11", "8,1,7 ", "5,8,6", "2,6,10 ", "6,4,7", "9,7,11", "1,5,1", "4,2,5" };
        String[] LuTai = { "", "Du hồn", "Sanh khí", "Phục vì", "Ngũ quỷ", "Tuyệt thể", "Thiên y", "Tuyệt mạng", "Phước đức", "Quy hồn" };
        String[] Nhanxet = { "", "Hung = kiết", "Nửa tốt nửa xấu", "3 phần tốt", "4 phần tốt", "5 phần tốt", "6 phần tốt", "7 phần tốt", "8 phần tốt", "9 phần tốt", "10 phần tốt", "Thứ hung", "Đại hung", "Hạ kiết" };
        String[] cungphi = { "Khôn,Tốn", "Khảm,Cấn", "Ly,Càn", "Cấn,Đoài", "Đoài,Cấn", "Càn,Ly", "Khôn,Khảm", "Tốn,Khôn", "Chấn,Chấn" };
        public String KetQua(String[] BattuChong, String BattuVo)
        {
            CungPhi cp = new CungPhi();
            int iBattuVo = cp.Battu.IndexOf(BattuVo);
            return BattuChong[iBattuVo];
        }
        private void ShowResults()
        {
            CungPhi cp = new CungPhi(true);
            int index = 0;
            String CungChong = "";
            String CungVo = "";
            index = TinhCung(dtNamsinhChong.Date.Day, dtNamsinhChong.Date.Month, dtNamsinhChong.Date.Year, true);
            if (isTrungCung(lbCungChong, index, true)) CungChong = "Trung cung";
            else CungChong = lbCungChong.Text;
            index = TinhCung(dtNamsinhVo.Date.Day, dtNamsinhVo.Date.Month, dtNamsinhVo.Date.Year, false);
            if (isTrungCung(lbCungVo, index, false)) CungVo = "Cấn";
            else CungVo = lbCungVo.Text;
            XemHonNhan(CungChong, CungVo);
        }
        public void XemHonNhan(String cungChong, String cungVo)
        {
            if (cungChong == "" || cungVo == "")
            {
                return;
            }
            String KQ = "";
            switch (cungChong)
            {
                case "Khảm":
                    KQ = KetQua(Kham, cungVo);
                    break;
                case "Khôn":
                    KQ = KetQua(Khon, cungVo);
                    break;
                case "Chẩn":
                    KQ = KetQua(Chan, cungVo);
                    break;
                case "Tốn":
                    KQ = KetQua(Ton, cungVo);
                    break;
                case "Trung cung":
                    KQ = KetQua(Trung, cungVo);
                    break;
                case "Càn":
                    KQ = KetQua(_Can, cungVo);
                    break;
                case "Đoài":
                    KQ = KetQua(Doai, cungVo);
                    break;
                case "Cấn":
                    KQ = KetQua(__Can, cungVo);
                    break;
                case "Ly":
                    KQ = KetQua(Ly, cungVo);
                    break;
            }
            String[] nx = KQ.Split(',');
            nx[0] = LuTai[(Convert.ToInt32(nx[0]))];
            nx[1] = LuTai[(Convert.ToInt32(nx[1]))];
            nx[2] = Nhanxet[(Convert.ToInt32(nx[2]))];
            String S = "";
            S += "- Ngày sinh của chồng: " + dtNamsinhChong.Date.Day + "/" + dtNamsinhChong.Date.Month + "/" + dtNamsinhChong.Date.Year + " -------- " + NgayAl(dtNamsinhChong.Date) + "\n- Tuổi: " + TinhTuoi(dtNamsinhChong.Date) + " - Cung phi: " + cungChong + "\n";
            S += "- Ngày sinh của vợ:    " + dtNamsinhVo.Date.Day + "/" + dtNamsinhVo.Date.Month + "/" + dtNamsinhVo.Date.Year + " -------- " + NgayAl(dtNamsinhVo.Date) + "\n- Tuổi: " + TinhTuoi(dtNamsinhVo.Date) + " - Cung phi: " + cungVo + "\n";
            DienGiaiHonNhan dg = new DienGiaiHonNhan();
            tb2.Text = nx[0];
            tb4.Text = nx[1];
            tb3.Text = dg.FindDienGiaiByIndex(dg.LuTaiIndex(nx[0]));
            tb5.Text = dg.FindDienGiaiByIndex(dg.LuTaiIndex(nx[1]));
            richTextBox1.Text = S;
        }
        public bool isTrungCung(TextBlock lb, int index, bool isMale)
        {
            CungPhi cp = new CungPhi(true);
            if (index == 4)
            {
                lb.Text = "Trung cung " + (isMale ? "Khôn" : "Cấn");
                return true;
            }
            else
            {
                lb.Text = cp.Battu[index];
                return false;
            }
        }
        public int TinhTuoi(DateTimeOffset date)
        {
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;
            tv.setDate(day, month, year);
            int[] am;
            am = tv.Solar2Lunar(tv.getDay(), tv.getMonth(), tv.getYear());
            tv.setDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            int[] amNow;
            amNow = tv.Solar2Lunar(tv.getDay(), tv.getMonth(), tv.getYear());
            int tuoi = amNow[2] - am[2] + 1;
            return tuoi;
        }
        public String NgayAl(DateTimeOffset date)
        {
            int day = date.Day;
            int month = date.Month;
            int year = date.Year;
            tv.setDate(day, month, year);
            int[] am;
            am = tv.Solar2Lunar(tv.getDay(), tv.getMonth(), tv.getYear());
            String canChi = tv.CanChi(am[0], am[1], am[2], am[3]);
            tv.setDate(day, month, am[2]);
            return ("Ngày " + am[0].ToString() + " Tháng " + am[1].ToString() + " Năm " + tv.yearLunar() + " (ÂL)");
        }
        public int TinhCung(int day, int month, int year, bool isMale)
        {
            tv.setDate(day, month, year);
            int[] am;
            am = tv.Solar2Lunar(tv.getDay(), tv.getMonth(), tv.getYear());
            tv.setDate(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            int[] amNow;
            amNow = tv.Solar2Lunar(tv.getDay(), tv.getMonth(), tv.getYear());
            int tuoi = amNow[2] - am[2] + 1;
            int namtinhCung = amNow[2];
            int startAge = namtinhCung % 9;
            int battuIndex = TinhCungBanTayTrai(tuoi, startAge, isMale);
            return battuIndex;
        }
        public int TinhCungBanTayTrai(int Age, int StartAge, bool isMale)
        {
            int start = 0;
            if (!isMale) start = 4;
            while (StartAge < Age)
            {
                if (isMale)
                {
                    start++;
                    if (start > 8) start = 0;
                    StartAge += 10;
                }
                else
                {
                    start--;
                    if (start < 0) start = 8;
                    StartAge += 10;
                }
            }
            if (StartAge == Age)
                return start;
            while (StartAge != Age)
            {
                if (isMale)
                {
                    start--;
                    StartAge--;
                    if (start < 0) start = 8;
                }
                else
                {
                    start++;
                    if (start > 8) start = 0;
                    StartAge--;
                }
            }
            return start;
        }
        public class CungPhi
        {
            public List<String> Battu = new List<string>();
            public CungPhi()
            {
                Battu.Add("Càn");
                Battu.Add("Khảm");
                Battu.Add("Cấn");
                Battu.Add("Chẩn");
                Battu.Add("Tốn");
                Battu.Add("Ly");
                Battu.Add("Khôn");
                Battu.Add("Đoài");
                Battu.Add("Trung");
            }
            public CungPhi(bool init)
            {
                Battu.Add("Khảm");
                Battu.Add("Khôn");
                Battu.Add("Chẩn");
                Battu.Add("Tốn");
                Battu.Add("Trung cung");
                Battu.Add("Càn");
                Battu.Add("Đoài");
                Battu.Add("Cấn");
                Battu.Add("Ly");
            }
            public int vitriBattu(String s)
            {
                return Battu.IndexOf(s);
            }
        }
        public class DienGiaiHonNhan
        {
            private List<String> LuTai = new List<string>();
            private List<String> DienGiai = new List<string>();
            public DienGiaiHonNhan()
            {
                LuTai.Add("");
                LuTai.Add("Du hồn");
                LuTai.Add("Sanh khí");
                LuTai.Add("Phục vì");
                LuTai.Add("Ngũ quỷ");
                LuTai.Add("Tuyệt thể");
                LuTai.Add("Thiên y");
                LuTai.Add("Tuyệt mạng");
                LuTai.Add("Phước đức");
                LuTai.Add("Quy hồn");

                DienGiai.Add("");
                DienGiai.Add("");
                DienGiai.Add("      Là cát khí, là thông suốt, là sinh sôi, nảy nở. Sinh Khí là kết quả tiến hành thuận lợi, hanh thông. Sinh Khí chủ về phát phúc, chủ sự hoà hợp, thăng tiến, lại cũng chủ về sự thông minh sáng suốt, trí tuệ, hiếu lễ, sự trung hậu, trước sau cẩn thận");
                DienGiai.Add("      Là khí biến ngang hoà. Gặp Quẻ biến thành Phục Vị là trở lại vị trí ban đầu của khí chất quẻ gốc, quẻ biến. Vì vậy khí Phục Vị là khí quân bình cát hung.");
                DienGiai.Add("      Là năm thứ tà khí quấy rối sự sống, quấy rối quan hệ con người. Khí ra Ngũ Quỷ là hung; là kết quả tiến hành gặp nhiều trắc trở, lận đận khó thành; là bất nhất trước sau, là vô tiền khoáng hậu. Gặp Ngũ Quỷ dễ gây ra tai vạ, tranh cãi, thị phi khẩu thiệt, gặp những sự quấy rối, phá ngang");
                DienGiai.Add("");
                DienGiai.Add("      Là cát khí, biểu hiện sự tăng tài tiến lộc; là sự gia tăng sinh khí; là sự hoá giải các vướng mắc trong đời sống mọi mặt. Quẻ biến thành Thiên Y là cát, là được hộ trì. Thiên Y là có giao, hợp, chính, hoà; là có sự hà gắn, liền lạc và may mắn, là gia đạo bình an, sức khoẻ tăng tiến, mưu sự thành đạt.");
                DienGiai.Add("      Là hung khí. Tuyệt Mệnh là hết đường, là sự chia cắt, ly xa, là tai ương, tật ách. Gặp Tuyệt Mệnh khí là kết quả tiến hành gặp trở ngại, không thành. Bệnh tật nguy khốn, hôn nhân, sinh sản, gia đạo bất an, gặp sự chẳng lành, quan hệ tình duyên, giao dịch trì trệ ngưng đọng, gặp nhiều phiền phức, hối cữu, công việc, kinh doanh, mưu sự vướng mắc, gẫy đoạn, khó thành.");
                DienGiai.Add("");
                DienGiai.Add("");
            }
            public int LuTaiIndex(string S)
            {
                return LuTai.IndexOf(S);
            }
            public string FindDienGiaiByIndex(int i)
            {
                return DienGiai[i];
            }
        }
    }
}
