using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.EntidadesDeNegocio
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "Categoria es obligatorio")]
        [Display(Name = "Categoria")]
        public int Idcategoria { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Precio es obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Imagen es obligatorio")]
        [StringLength(200, ErrorMessage = "Maximo 200 caracteres")]
        public string Imagen { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
        public Categoria Categoria { get; set; }
    }
    }
