using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanam
{
    internal class tblGiaoTrinh
    {
        private string _MaGiaoTrinh;
        private string _TenGiaoTrinh;
        private string _MaLoai;
        private string _TenTacGia;
        private string _NhaXuatBan;

        public string MaGiaoTrinh { get => _MaGiaoTrinh; set => _MaGiaoTrinh = value; }
        public string TenGiaoTrinh { get => _TenGiaoTrinh; set => _TenGiaoTrinh = value; }
        public string MaLoai { get => _MaLoai; set => _MaLoai = value; }
        public string TenTacGia { get => _TenTacGia; set => _TenTacGia = value; }
        public string NhaXuatBan { get => _NhaXuatBan; set => _NhaXuatBan = value; }
    }
}
