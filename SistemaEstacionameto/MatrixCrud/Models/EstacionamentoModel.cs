using System.ComponentModel.DataAnnotations;

namespace MatrixCrud.Models
{
    public class EstacionamentoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Cliente!")]
        public string Proprietario { get; set; }

        [Required(ErrorMessage = "Digite o Modelo do Carro!")]
        public string Modelo { get; set;}

        [Required(ErrorMessage = "Digite a Placa!")]
        public string placa { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de Horas!")]
        public int ValolHora { get; set; }
    }
}
