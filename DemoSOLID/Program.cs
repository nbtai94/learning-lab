using System.Reflection.Metadata;
using System.Xml.Serialization;

namespace DemoSOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Liskov");
            var sparrow = new Sparrow2("red");
            var penguin = new Penguin2("black");
            sparrow.Move();
            penguin.Move();

            Console.WriteLine("Depedence inversion");
            var messageService = new MessageService();
            var notification = new Notification(messageService);
            notification.Send("Message sent by Depedence inversion");
        }

        //Single Responsibility Principle => Mỗi class chỉ nên chịu 1 trách nhiệm duy nhất

        public class Invoice
        {
            public Invoice()
            {
            }
        };

        public class InvoicePrinter
        {
            public void PrintInvoice()
            {
                Console.WriteLine("Print invoice");
            }
        }

        public class InvoiceEmail
        {
            public void EmailInvoice()
            {
                Console.WriteLine("Email invoice");
            }
        }

        // Open/Close => Không sửa chữa class củ mà mở rộng bằng cách kế thừa  
        // Ví dụ muốn sửa EmailInvoice thành Send Invoice Confirm
        public class EmailInvoiceConfirm : InvoiceEmail
        {
            public EmailInvoiceConfirm()
            {
            }

            public void SendConfirmInvoice()
            {
                Console.WriteLine("Confirm email was sent");
            }
        }


        // Liskov => Đối tượng của class con có thể thay thế cho đối tượng của class cha mà không bị lỗi

        public abstract class Bird
        {
            public string Color { get; set; }
            public abstract void Fly();
        }

        public class Sparrow : Bird
        {
            public override void Fly()
            {
                Console.WriteLine("Sparrow fly");
            }
        }

        public class Penguin : Bird
        {
            // => Error cánh cụt k thể bay => Vi phạm nguyên tắc
            public override void Fly()
            {
                throw new NotImplementedException();
            }
        }

        // Cách xử lý

        public abstract class Bird2
        {
            protected Bird2(string color)
            {
                Color = color;
            }
            public string Color { get; set; }
            public abstract void Move();
        }

        public class Sparrow2 : Bird2
        {
            public Sparrow2(string color) : base(color)
            {

            }
            public override void Move()
            {
                Fly();
            }

            public void Fly()
            {
                Console.WriteLine($"{Color} Sparrow fly");
            }
        }

        public class Penguin2 : Bird2
        {
            public Penguin2(string color) : base(color)
            {
            }

            public override void Move()
            {
                Run();
            }

            public void Run()
            {
                Console.WriteLine($"{Color} Penguin Run");
            }
        }

        // Interface Segregration => Interface lớn nên tách thành nhiều interface nhỏ với mục đích cụ thể
        // => Không được bắc buộc class con phải thực thi những phương thức không cần thiết

        public interface ManagerDevice
        {
            void Print(Document doc);
            void Scan(Document doc);
            void Fax(Document doc);
        }

        // => Vi phạm nguyên tắc vì printer phải thực thi fax & scan
        public class Printer : ManagerDevice
        {
            public void Fax(Document doc)
            {
                throw new NotImplementedException();
            }

            public void Print(Document doc)
            {
                throw new NotImplementedException();
            }

            public void Scan(Document doc)
            {
                throw new NotImplementedException();
            }
        }
        //Cách Xử lý

        public interface IPrinter
        {
            void Print(Document doc);
        }

        public interface IScan
        {
            void Scan(Document doc);
        }

        public interface IFax
        {
            void Fax(Document doc);
        }

        public class Printer2 : IPrinter
        {
            public void Print(Document doc)
            {
                throw new NotImplementedException();
            }
        }

        // Depedence Inversion => Module cấp cao không nên phụ thuộc vào module cấp thấp => cả 2 nên phụ thuộc vào abstraction
        // Interface không nên phụ thuộc vào chi tiết => mà ngược lại

        public class Notification
        {
            private readonly IMessageService _messageService;

            public Notification(IMessageService messageService)
            {
                _messageService = messageService;
            }

            public void Send(string message)
            {
                _messageService.Send(message);
            }
        }

        public interface IMessageService
        {
            void Send(string message);
        }
        public class MessageService : IMessageService
        {
            public MessageService()
            {
            }

            public void Send(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
