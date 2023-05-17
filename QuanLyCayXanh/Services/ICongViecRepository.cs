using QuanLyCayXanh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCayXanh.Services
{
    public interface ICongViecRepository
    {
        CongViecModel UpdateStatus(CongViecModel congViecModel);
        List<CongViecModel> GetAll();

    }
}
