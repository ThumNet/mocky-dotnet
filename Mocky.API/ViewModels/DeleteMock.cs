using System.ComponentModel.DataAnnotations;

namespace Mocky.API.ViewModels
{
    public class DeleteMock
    {
        [MaxLength(64)]
        public string Secret { get; set; }
    }
}