using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using Http.News.Data.Contracts.Entities;

namespace Http.News.Data.EntityFramework.Migrations
{
    public class NewsDbMigrationsConfiguration : DbMigrationsConfiguration<NewsDbContext>
    {
        public NewsDbMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewsDbContext context)
        {
            base.Seed(context);
#if DEBUG
            if (!context.Categories.Any())
            {
                var item1 = new Item
                {
                    CreatedBy = "Roman Vasilyev",
                    CreatedDate = DateTime.UtcNow,
                    ItemContent =
                                    new ItemContent
                                    {
                                        CreatedBy = "Roman Vasilyev",
                                        CreatedDate = DateTime.UtcNow,
                                        BigImage = "/Upload/img/Cshpacman.png",
                                        SmallImage = "/Upload/img/Csh.png",
                                        MediumImage = "/Upload/img/Csh.png",
                                        NumOfView = 100,
                                        Title = "C# language",
                                        ShortDescription =
                                            "C# — объектно-ориентированный язык программирования.",
                                        Content =
                                            "C# (произносится си шарп) — объектно-ориентированный язык программирования. Разработан в 1998—2001 годах группой инженеров компании Microsoft под руководством Андерса Хейлсберга и Скотта Вильтаумота как язык разработки приложений для платформы Microsoft .NET Framework."
                                    },
                    Rating = 0,
                    TotalRaters = 0,
                    TotalLikes = 1121,
                    TotalDislikes = 12,
                    AverageRating = 0,
                };

                var item2 = new Item
                {
                    CreatedBy = "Roman Vasilyev",
                    CreatedDate = DateTime.UtcNow,
                    ItemContent =
                                    new ItemContent
                                    {
                                        CreatedBy = "Roman Vasilyev",
                                        CreatedDate = DateTime.UtcNow,
                                        BigImage = "/Upload/img/CppBig.png",
                                        SmallImage = "/Upload/img/CppSmall.png",
                                        MediumImage = "/Upload/img/CppSmall.png",
                                        NumOfView = 200,
                                        Title = "C++ programming",
                                        ShortDescription =
                                            "C++ — компилируемый, статически типизированный язык программирования общего назначения.",
                                        Content =
                                            "C++ (читается си-плюс-плюс) — компилируемый, статически типизированный язык программирования общего назначения. Поддерживает такие парадигмы программирования, как процедурное программирование, объектно - ориентированное программирование, обобщённое программирование.Язык имеет богатую стандартную библиотеку, которая включает в себя распространённые контейнеры и алгоритмы, ввод - вывод, регулярные выражения, поддержку многопоточности и другие возможности.C++ сочетает свойства как высокоуровневых, так и низкоуровневых языков.[3][4] В сравнении с его предшественником — языком C, — наибольшее внимание уделено поддержке объектно - ориентированного и обобщённого программирования. C++ широко используется для разработки программного обеспечения, являясь одним из самых популярных языков программирования[мнения 1][мнения 2].Область его применения включает создание операционных систем, разнообразных прикладных программ, драйверов устройств, приложений для встраиваемых систем, высокопроизводительных серверов, а также игр.Существует множество реализаций языка C++, как бесплатных, так и коммерческих и для различных платформ.Например, на платформе x86 это GCC, Visual C++, Intel C++ Compiler, Embarcadero(Borland) C++ Builder и другие.C++ оказал огромное влияние на другие языки программирования, в первую очередь на Java и C#. Синтаксис C++ унаследован от языка C.Одним из принципов разработки было сохранение совместимости с C.Тем не менее, C++ не является в строгом смысле надмножеством C; множество программ, которые могут одинаково успешно транслироваться как компиляторами C, так и компиляторами C++, довольно велико, но не включает все возможные программы на C."
                                    },
                    Rating = 0,
                    TotalRaters = 0,
                    TotalLikes = 455,
                    TotalDislikes = 15,
                    AverageRating = 0,
                };

                var item3 = new Item
                {
                    CreatedBy = "Roman Vasilyev",
                    CreatedDate = DateTime.UtcNow,
                    ItemContent =
                        new ItemContent
                        {
                            CreatedBy = "Roman Vasilyev",
                            CreatedDate = DateTime.UtcNow,
                            BigImage = "/Upload/img/Java.png",
                            SmallImage = "/Upload/img/Java.png",
                            MediumImage = "/Upload/img/Java.png",
                            NumOfView = 150,
                            Title = "Java programming language",
                            ShortDescription =
                                "Java — сильно типизированный объектно-ориентированный язык программирования, разработанный компанией Sun Microsystems. В настоящее время проект принадлежит OpenSource и распространяется по лицензии GPL. В OpenJDK вносят вклад крупные компании, такие как — Oracle, RedHat, IBM, Google, JetBrains.",
                            Content =
                                "Java — сильно типизированный объектно-ориентированный язык программирования, разработанный компанией Sun Microsystems. В настоящее время проект принадлежит OpenSource и распространяется по лицензии GPL. В OpenJDK вносят вклад крупные компании, такие как — Oracle, RedHat, IBM, Google, JetBrains."
                        },
                    Rating = 0,
                    TotalRaters = 0,
                    TotalLikes = 1234,
                    TotalDislikes = 123,
                    AverageRating = 0,

                };

                var item4 = new Item
                {
                    CreatedBy = "Roman Vasilyev",
                    CreatedDate = DateTime.UtcNow,
                    ItemContent =
                        new ItemContent
                        {
                            CreatedBy = "Roman Vasilyev",
                            CreatedDate = DateTime.UtcNow,
                            BigImage = "/Upload/img/Algorithm.png",
                            SmallImage = "/Upload/img/Algorithm.png",
                            MediumImage = "/Upload/img/Algorithm.png",
                            NumOfView = 500,
                            Title = "Algorithms and etc.",
                            ShortDescription =
                                "Процесс или набор правил, необходимых для проведения расчета или выполнения какой-либо задачи.",
                            Content =
                                "Алгори́тм (лат. algorithmi — от арабского имени математика Аль-Хорезми) — конечная совокупность точно заданных правил решения произвольного класса задач или набор инструкций, описывающих порядок действий исполнителя для решения некоторой задачи."
                        },
                    Rating = 0,
                    TotalRaters = 0,
                    TotalLikes = 12345,
                    TotalDislikes = 1234,
                    AverageRating = 0,
                };

                var item5 = new Item
                {
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.UtcNow,
                    ItemContent =
                                new ItemContent
                                {
                                    CreatedBy = "Admin",
                                    CreatedDate = DateTime.UtcNow,
                                    BigImage = "/Upload/img/machineLearning3.png",
                                    SmallImage = "/Upload/img/machineLearning3.png",
                                    MediumImage = "/Upload/img/machineLearning3.png",
                                    NumOfView = 500,
                                    Title = "Machine Learning Test",
                                    ShortDescription =
                                        "Machine learning (ML) is the scientific study of algorithms and statistical models that computer systems use to effectively perform a specific task without using explicit instructions, relying on patterns and inference instead. It is seen as a subset of artificial intelligence.",
                                    Content =
                                        "Machine learning (ML) is the scientific study of algorithms and statistical models that computer systems use to effectively perform a specific task without using explicit instructions, relying on patterns and inference instead. It is seen as a subset of artificial intelligence."
                                },
                    Rating = 10,
                    TotalRaters = 3,
                    TotalLikes = 0,
                    TotalDislikes = 0,
                    AverageRating = 4.7,
                };

                var cat1 = new Category { Name = "C#", CreatedDate = DateTime.UtcNow, CreatedBy = "Roman Vasilyev", Items = new Collection<Item> { item1 } };
                var cat2 = new Category { Name = "C++", CreatedDate = DateTime.UtcNow, CreatedBy = "Roman Vasilyev", Items = new Collection<Item> { item2 } };
                var cat3 = new Category { Name = "Java", CreatedDate = DateTime.UtcNow, CreatedBy = "Roman Vasilyev", Items = new Collection<Item> { item3 } };
                var cat4 = new Category { Name = "Algorithms", CreatedDate = DateTime.UtcNow, CreatedBy = "Roman Vasilyev", Items = new Collection<Item> { item4 } };
                var cat5 = new Category { Name = "Machine Learning", CreatedDate = DateTime.UtcNow, CreatedBy = "Admin", Items = new Collection<Item> { item5 } };

                context.Categories.Add(cat1);
                context.Categories.Add(cat2);
                context.Categories.Add(cat3);
                context.Categories.Add(cat4);
                context.Categories.Add(cat5);

                context.Tags.AddRange(new List<Tag>
                {
                    new Tag { Text = "C#" },
                    new Tag { Text = "C++" },
                    new Tag { Text = "Java"},
                    new Tag { Text = "Algorithms" },
                    new Tag { Text = "Machine Learning"},
                    new Tag { Text = "Category"},
                    new Tag { Text = "Test tag"},
                    new Tag { Text = "Wow!"}
                });

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO: write log here
                    var message = ex.Message;
                }
            }
#endif
        }
    }
}