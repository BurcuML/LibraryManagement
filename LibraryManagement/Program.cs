// See https://aka.ms/new-console-template for more information
using LibraryManagement;

List<Book> books = new List<Book>()
{
    new Book(1,"Germinal","Kömür Madeni",341,"2012 Mayıs"),
    new Book(2,"Suç ve Ceza","Raskolnikov un hayatı",315,"2010 Haziran"),
    new Book(3,"Kumarbaz","Bir Öğretmenin hayatı",210,"2009 Ocak"),
    new Book(4, "Araba Sevdası","Arabayla alakası olmayan Kitap",180,"1999 Ocak"),
    new Book(5,"Ateşten Gömlek","Kurtulu savaşını anlatan kitap",120,"2001 Eylül"),
};


List<Author> authors = new List<Author>()
{
    new Author(1,"Emile","Zola"),
    new Author(2,"Fyodor","Dostoyevski"),
    new Author(3,"Recaizade Mahmut","Ekrem"),
    new Author(4, "Halide Edib","Adıvar"),
    new Author(5,"L.N","Tolstoy"),
};



List<Category> categories = new List<Category>()
{
    new Category(1,"Dünya Klasikleri"),
    new Category(2,"Türk Klasikleri"),
    new Category(3,"Bilim Kurgu"),
    new Category(4,"Fantastik")
};
//GetAllBooksByPageSizeFilter();

//GetAllBooks();
//GetAllAuthors();
//GetAllCategories();
//PageSizeTotalCalculator();

//GetAllBooksByTitleContains();

AddBook();



Book GetBookInputs()
{
    Console.WriteLine("Lütfen kitap id sini giriniz: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    string title = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    string description = Console.ReadLine();

    Console.WriteLine("Lütfen kitap sayfasını giriniz: ");
    int pageSize = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    string publishDate = Console.ReadLine();

    Console.WriteLine("Lütfen kitap ISBN numarasını giriniz: ");
    string isbn = Console.ReadLine();

    Book book = new Book(id, title, description, pageSize, publishDate, isbn);
    return book;
}

bool AddBookValidator(Book book)
{
    bool isUnique = true;

    foreach (Book item in books)
    {
        if (item.Id == book.Id || item.ISBN == book.ISBN)
        {
            isUnique = false;
            break;
        }
    }

    return isUnique;
}

void GetBookInput(out int id,
     out string title,
     out string description,
     out int pageSize,
     out string publishDate,
     out string isbn)
{
    Console.WriteLine("Lütfen kitap id sini giriniz: ");
    id = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    title = Console.ReadLine();

    Console.WriteLine("Lütfen kitap Açıklamasını giriniz: ");
    description = Console.ReadLine();

    Console.WriteLine("Lütfen kitap sayfasını giriniz: ");
    pageSize = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen kitap Yayımlanma Tarihini giriniz: ");
    publishDate = Console.ReadLine();

    Console.WriteLine("Lütfen kitap ISBN numarasını giriniz: ");
    isbn = Console.ReadLine();
}

void AddBook()
{
    //1. Yöntem
    //int id;
    //string title;
    //string description;
    //int pageSize;
    //string publishDate;
    //string isbn;

    //GetBookInputs(out id,out title,out description,out pageSize,out publishDate,out isbn);
    Book book = GetBookInputs();

    bool isUnique = AddBookValidator(book);

    if (!isUnique)
    {
        Console.WriteLine("Girmiş olduğunuz kitap Benzersiz değil.");
        return;
    }
    books.Add(book);
    GetAllBooks();
}
void GetAllBooksByTitleContains()
{
    Console.WriteLine("Lütfen kitap başlığını giriniz: ");
    string text = Console.ReadLine();

    foreach (Book book in books)
    {
        if (book.Title.Contains(text, StringComparison.InvariantCultureIgnoreCase))
        {
            Console.WriteLine(book);
        }
    }
}

void PageSizeTotalCalculator()
{
    int total = 0;
    //for (int i =0;i<books.Count;i++)
    //{
    //    total = books[i].PageSize + total;
    //}

    foreach (var item in books)
    {
        total = total + item.PageSize;
    }


    Console.WriteLine(total);
}

void GetAllBooks()
{
    PrintAyirac("Kitapları Listele:");

    foreach (Book book in books)
    {
        Console.WriteLine(book);
    }
}

void GetAllCategories()
{
    PrintAyirac("Kategorileri Listele");
    foreach (Category category in categories)
    {
        Console.WriteLine(category);
    }
}

void GetAllAuthors()
{
    PrintAyirac("Yazarları Listele: ");

    foreach (Author author in authors)
    {
        Console.WriteLine(author);
    }
}

void PrintAyirac(string metin)
{
    Console.WriteLine(metin);
    Console.WriteLine("----------------------------------------");
}


void GetAllBooksByPageSizeFilter()
{
    PrintAyirac("Sayfa Sayısına göre filtreleme");

    Console.WriteLine("Lütfen minimum değeri giriniz: ");
    int min = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Lütfen maximum değeri giriniz: ");
    int max = Convert.ToInt32(Console.ReadLine());

    foreach (Book book in books)
    {
        if (book.PageSize <= max && book.PageSize >= min)
        {
            Console.WriteLine(book);
        }
    }

}