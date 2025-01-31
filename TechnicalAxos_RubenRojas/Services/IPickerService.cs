using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAxos_RubenRojas.Services
{
    public interface IPickerService
    {
        Task<FileResult> PickAsync(PickOptions options);
    }

    public class PickerService : IPickerService
    {
        public async Task<FileResult> PickAsync(PickOptions options)
        {
            return await FilePicker.PickAsync(options);
        }
    }
}
