using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string ClientName { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        public decimal Value { get; set; }


        [Display(Name = "Disponível")]
        public bool Active { get; set; }

        public int IdClient { get; set; }
        public  List<SelectListItem> ClientViewModels { get; set; }

        public List<SelectListItem> CategoryViewModels { get; set; }

        public ClientViewModel Client { get; set; }
        public int IdCategory { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }
    }
}
