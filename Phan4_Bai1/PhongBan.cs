using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Phan4_Bai1
{
    internal class PhongBan
    {
        private int MaPB;
        private string SttPB;
        private string TenPB;
        private string MoTa;

        public PhongBan() { }
        public PhongBan(int maPB, string sttPB, string tenPB, string moTa)
        {
            MaPB = maPB;
            SttPB = sttPB;
            TenPB = tenPB;
            MoTa = moTa;
        }
        public int ma_pb { get => MaPB; set => MaPB = value; }
        public string stt_pb { get => SttPB; set => SttPB = value; }
        public string ten_pb { get => TenPB; set => TenPB = value; }
        public string mota { get => MoTa; set => MoTa = value; }

        public void Input()
        {
            Console.Write("Ma Phong Ban: ");
            ma_pb = Convert.ToInt32(Console.ReadLine());
            Console.Write("So Thu Tu: ");
            stt_pb = Console.ReadLine();
            Console.Write("Ten Phong Ban: ");
            ten_pb = Console.ReadLine();
            Console.Write("Mo Ta PB: ");
            mota = Console.ReadLine();

            Console.Write("----------------------------------\n");
        }

        public void Output()
        {
            Console.Write("---------------------------\n");
            Console.WriteLine("Ma Phong Ban: {0}", ma_pb);
            Console.WriteLine("So Thu Tu: {0}", stt_pb);
            Console.WriteLine("Ten Phong Ban: {0}", ten_pb);
            Console.WriteLine("Mo Ta PB: {0}", mota);
        }
    }
}
