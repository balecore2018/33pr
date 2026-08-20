namespace ChatStudents_Shapovalov.Models
{
    public class Users
    {
        /// <summary>Код</summary>
        public int Id { get; set; }

        /// <summary>Фамилия</summary>
        public string Lastname { get; set; }

        /// <summary>Имя пользователя</summary>
        public string Firstname { get; set; }

        /// <summary>Отчество</summary>
        public string Surname { get; set; }

        /// <summary>Фотография</summary>
        public byte[] Photo { get; set; }

        /// <summary>Конструктор для заполнения объекта</summary>
        public Users(string Lastname, string Firstname, string Surname, byte[] Photo)
        {
            this.Lastname = Lastname;
            this.Firstname = Firstname;
            this.Surname = Surname;
            this.Photo = Photo;
        }

        /// <summary>Получить ФИО пользователя</summary>
        public string ToFIO()
        {
            return $"{Lastname} {Firstname} {Surname}";
        }
    }
}
