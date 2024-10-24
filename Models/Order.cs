using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstWebApplication.Models
{
    public enum OrderState
    {
        Обрабатывается,
        Доставляется,
        Доставлен,
        Отменен
    }
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Автоинкремент
        [Key]
        [Column("order_id")]
            public int OrderId { get; set; }

        [Required(ErrorMessage = "Название - обязательное поле!")]
        [Column("user_id")]
            public int UserId { get; set; }

        [Column("date")]
        [Required(ErrorMessage = "Дата - обязательное поле!")]
        public DateTime DateProperty { get; set; }
        

        [Column("state")]
        [Required(ErrorMessage = "Статус - обязательное поле!")]
        [EnumDataType(typeof(OrderState))]
            public OrderState State { get; set; }


        //навигационное свойство
        [NotMapped] //Аннотация, благодарся которой
                    //EF игнорирует это свйоство при работе с БД
        public virtual ICollection<OrderProductConnection> OrderProductConnections { get; set; } 
            = new List<OrderProductConnection>();

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
    }
}
