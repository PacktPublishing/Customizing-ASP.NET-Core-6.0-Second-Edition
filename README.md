


# Customizing ASP.NET Core 6.0 - Second Edition

<a href="https://www.packtpub.com/product/customizing-asp-net-core-6-0-second-edition/9781803233604"><img src="https://static.packt-cdn.com/products/9781803233604/cover/smaller" alt="Customizing ASP.NET Core 6.0" height="256px" align="right"></a>

This is the code repository for [Customizing ASP.NET Core 6.0 - Second Edition](https://www.packtpub.com/product/customizing-asp-net-core-6-0-second-edition/9781803233604), published by Packt.

**Learn to turn the right screws to optimize your ASP.NET Core applications for better performance**

## What is this book about?
ASP.NET Core comes packed full of hidden features for building sophisticated web applications. You’d be missing out on a lot of its capabilities by not customizing it to work for your applications. With Customizing ASP.NET Core 6.0, you’ll discover techniques to help you get the most out of the framework to deliver robust applications.

This book covers the following exciting features: <First 5 What you'll learn points>
* Explore various application configurations and providers in ASP.NET Core 6
* Enable and work with caches to improve the performance of your application
* Understand dependency injection in .NET and learn how to add third-party DI containers
* Discover the concept of middleware and write your middleware for ASP.NET Core apps
* Create various API output formats in your API-driven projects

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1803233605) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>


## Instructions and Navigations
All of the code is organized into folders. For example, Chapter02.

The code will look like the following:
```
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
```

**Following is what you need for this book:**
This .NET 6 book is for .NET developers who need to change the default behaviors of the framework to help improve the performance of their applications. Intermediate-level knowledge of ASP.NET Core and C# is required before getting started with the book.

With the following software and hardware list you can run all code files present in the book (Chapter 1-16).

### Software and Hardware List

| Chapter  | Software required                   | OS required                        |
| -------- | ------------------------------------| -----------------------------------|
| 1-16        | .NET 5.0                   | Windows, Mac OS X, and Linux (Any) |
| 1-16        | Visual Studio code           | Windows, Mac OS X, and Linux (Any) |
| 6       |	Nginx or Apache webserver            |  Linux  |



We also provide a PDF file that has color images of the screenshots/diagrams used in this book. [Click here to download it](https://static.packt-cdn.com/downloads/9781803233604_ColorImages.pdf).


### Related products <Other books you may enjoy>
* ASP.NET Core and Vue.js [[Packt]](https://www.packtpub.com/product/asp-net-core-and-vue-js/9781800206694) [[Amazon]](https://www.amazon.com/dp/1800206690)

* C# 10 and .NET 6 – Modern Cross-Platform Development - Sixth Edition [[Packt]](https://www.packtpub.com/product/c-10-and-net-6-modern-cross-platform-development-sixth-edition/9781801077361) [[Amazon]](https://www.amazon.com/dp/1801077363)

## Get to Know the Author
**Jürgen Gutsch**
is a .NET-addicted web developer. He has worked with .NET and ASP.NET since the early versions in 2002. Before that, he wrote server-side web applications using classic ASP. He is also an active part of the .NET developer community. Jürgen writes for the dotnetpro magazine, one of the most popular German-speaking developer magazines. He also publishes articles in English on his blog ASP.NET Hacker and contributes to several open-source projects. Jürgen has been a Microsoft MVP since 2015.
The best way to contact him is by using Twitter.
He works as a developer, consultant, and trainer for the digital agency YOO Inc., located in Basel, Switzerland. YOO Inc. serves national as well as international clients and specializes in creating custom digital solutions for distinct business needs.

## Other books by the authors
* [Customizing ASP.NET Core 5.0](https://www.packtpub.com/product/customizing-asp-net-core-5-0/9781801077866)


### Download a free PDF

 <i>If you have already purchased a print or Kindle version of this book, you can get a DRM-free PDF version at no cost.<br>Simply click on the link to claim your free PDF.</i>
<p align="center"> <a href="https://packt.link/free-ebook/9781803233604">https://packt.link/free-ebook/9781803233604 </a> </p>