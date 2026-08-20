namespace ChatStudents_Shapovalov.Models
{
    public class Messages
    {
        /// <summary>Код сообщения</summary>
        public int Id { get; set; }

        /// <summary>Отправитель</summary>
        public int UserFrom { get; set; }

        /// <summary>Получатель</summary>
        public int UserTo { get; set; }

        /// <summary>Текст сообщения</summary>
        public string Message { get; set; }

        /// <summary>Конструктор для сообщения</summary>
        public Messages(int UserFrom, int UserTo, string Message)
        {
            this.UserFrom = UserFrom;
            this.UserTo = UserTo;
            this.Message = Message;
        }
    }
}
