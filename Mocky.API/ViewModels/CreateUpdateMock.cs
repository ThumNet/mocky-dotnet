using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mocky.API.ViewModels
{
    public class CreateUpdateMock
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(1000000)]
        public string Content { get; set; }

        [MaxLength(200)]
        public string ContentType { get; set; }

        [Range(100, 999)]
        public int Status { get; set; }

        public string Charset { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        [MaxLength(64)]
        public string Secret { get; set; }

        public Expiration Expiration { get; set; }
    }
}
