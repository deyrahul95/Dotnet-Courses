using AdvancedTopics.Extensions;
using AdvancedTopics.Repositories;


string title = "Master the confusing C# constructs: Events, Delegates, Lambda Expressions, LINQ, Async/Await and more!";
Console.WriteLine(title.Shorten(6));

var bookRepo = new BookRepository();
var cheapBooks = bookRepo.GetBooks()
                    .FindAll(b => b.IsCheap())
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

foreach (var book in cheapBooks)
{
    Console.WriteLine(book);
}

// var video = new Video("C# Advanced Topic - Events and Delegate");
// var mailService = new MailService();
// var messageService = new MessageService();

// var videoEncoder = new VideoEncoder();
// videoEncoder.VideoEncoded += mailService.OnVideoEncoded!;
// videoEncoder.VideoEncoded += messageService.OnVideoEncoded!;

// videoEncoder.Encode(video);
