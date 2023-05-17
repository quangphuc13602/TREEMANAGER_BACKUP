using QuanLyCayXanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Services
{
     public interface IPersonRepository
     {
        List<NhanVienModel> GetById(string CMND);
        List<NhanVVienCongViec> GetWorkByID(string CMND);
    }
}
